using Moq;
using System.Collections.Generic;
using Xunit;
using Models;
using Services;
using Repository;

namespace WorkWave.Tests;

public class BoardServiceTests
{
    [Fact]
    public void GetAll_CorrectOutput()
    {
        // Arrange
        Mock<IRepository<Board>> repo = new Mock<IRepository<Board>>();
        var expectedBoards = new List<Board>
            {
                new Board {ID = 1, Name = "Board 1", Description = "This is the first board.", Users = new List<User>()},
                new Board {ID = 2, Name = "Board 2", Description = "This is the second board.", Users = new List<User>()}
            };

        repo.Setup(x => x.List()).Returns(expectedBoards);
        BoardService boardService = new BoardService(repo.Object);

        // Act
        var result = boardService.GetAll();

        // Assert
        Assert.Equal(expectedBoards, result);
    }

    [Fact]
    public void GetAll_EmptyTable()
    {
        // Arrange
        Mock<IRepository<Board>> repo = new Mock<IRepository<Board>>();
        repo.Setup(x => x.List()).Returns(new List<Board>());
        BoardService boardService = new BoardService(repo.Object);
        List<Board> expected = new List<Board>();

        // Act
        var result = boardService.GetAll();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetAll_ReturnNull()
    {
        // Assert
        Mock<IRepository<Board>> repo = new Mock<IRepository<Board>>();
        repo.Setup(x => x.List()).Returns((List<Board>)null);
        BoardService boardService = new BoardService(repo.Object);

        // Act
        var result = boardService.GetAll();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Save_Successful()
    {
        // Arrange
        Mock<IRepository<Board>> repo = new Mock<IRepository<Board>>();
        var newBoard = new Board { ID = 1, Name = "New Board", Description = "This is a new board for testing.", Users = new List<User>() };
        repo.Setup(x => x.Save(It.IsAny<Board>())).Returns(newBoard).Verifiable();
        BoardService boardService = new BoardService(repo.Object);

        // Act
        var result = boardService.Save(newBoard);

        // Assert
        Assert.Equal(newBoard, result);
        repo.Verify(x => x.Save(It.IsAny<Board>()), Times.Once);
        repo.Verify();
    }

    [Fact]
    public void GetById_Successful()
    {
        // Arrange
        var repo = new Mock<IRepository<Board>>();
        var board = new Board { ID = 1, Name = "Board 1", Description = "This is the first board.", Users = new List<User>() };

        repo.Setup(x => x.GetById(board.ID)).Returns(board);
        var boardService = new BoardService(repo.Object);

        // Act
        var result = boardService.GetById(board.ID);

        // Assert
        Assert.Equal(board, result);
        repo.Verify(x => x.GetById(board.ID), Times.Once);
    }

    [Fact]
    public void DeleteById_Successful()
    {
        // Arrange
        var repo = new Mock<IRepository<Board>>();
        var boardToDelete = new Board { ID = 1, Name = "Board to Delete", Description = "This board will be deleted.", Users = new List<User>() };
        repo.Setup(x => x.GetById(boardToDelete.ID)).Returns(boardToDelete);
        repo.Setup(x => x.Delete(boardToDelete)).Verifiable();
        var boardService = new BoardService(repo.Object);

        // Act
        boardService.DeleteById(boardToDelete.ID);

        // Assert
        repo.Verify(x => x.GetById(boardToDelete.ID), Times.Once);
        repo.Verify(x => x.Delete(boardToDelete), Times.Once);
    }

    [Fact]
    public void Update_Successful()
    {
        // Arrange
        var repo = new Mock<IRepository<Board>>();
        var existingBoard = new Board { ID = 1, Name = "Existing Board", Description = "This is an existing board.", Users = new List<User>() };
        var updatedBoard = new Board { ID = 1, Name = "Updated Board", Description = "This board has been updated.", Users = new List<User>() };

        // Setup the mock repository
        repo.Setup(x => x.Update(existingBoard.ID, updatedBoard)).Returns(updatedBoard).Verifiable();
        var boardService = new BoardService(repo.Object);

        // Act
        var result = boardService.Update(existingBoard.ID, updatedBoard);

        // Assert
        Assert.Equal(updatedBoard, result);
        repo.Verify(x => x.Update(existingBoard.ID, updatedBoard), Times.Once);
    }


}