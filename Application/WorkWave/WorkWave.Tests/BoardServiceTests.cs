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

        /*
        var mockRepo = new MockBoardRepo();
        var boardService = new BoardService(mockRepo);
        var expectedBoards = new List<Board>
            {
                new Board {ID = 1, Name = "Board 1", Description = "This is the first board.", Users = new List<User>()},
                new Board {ID = 2, Name = "Board 2", Description = "This is the second board.", Users = new List<User>()}
            };

        */

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




}