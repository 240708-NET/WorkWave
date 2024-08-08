using Moq;
using System.Collections.Generic;
using Xunit;
using Models;
using Services;
using Repository;

namespace WorkWave.Tests;

public class UserServiceTests
{
    [Fact]
    public void GetAll_CorrectOutput()
    {
        // Arrange
        Mock<IRepository<User>> repo = new Mock<IRepository<User>>();
        List<User> expectedUsers = new List<User>
            {
                new User { ID = 1, FullName = "John Doe", Email = "john.doe@revature.com", Password = "password123!", Boards = new List<Board>(), Cards = new List<Card>() },
                new User { ID = 2, FullName = "Jane Smith", Email = "jane.smith@revature.com", Password = "password456?", Boards = new List<Board>(), Cards = new List<Card>() }
            };

        repo.Setup(x => x.List()).Returns(expectedUsers);
        UserService userService = new UserService(repo.Object);

        // Act
        var result = userService.GetAll();

        // Assert
        Assert.Equal(expectedUsers, result);
    }

    [Fact]
    public void GetAll_EmptyList()
    {
        // Arrange
        Mock<IRepository<User>> repo = new Mock<IRepository<User>>();
        repo.Setup(x => x.List()).Returns(new List<User>());
        UserService userService = new UserService(repo.Object);

        // Act
        var result = userService.GetAll();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetAll_ReturnNull()
    {
        // Assert
        Mock<IRepository<User>> repo = new Mock<IRepository<User>>();
        repo.Setup(x => x.List()).Returns((List<User>)null);
        UserService userService = new UserService(repo.Object);

        // Act
        var result = userService.GetAll();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Save_Successful()
    {
        // Arrange
        Mock<IRepository<User>> repo = new Mock<IRepository<User>>();
        User newUser = new User { ID = 1, FullName = "John Doe", Email = "john.doe@revature.com", Password = "password123!", Boards = new List<Board>(), Cards = new List<Card>() };
        repo.Setup(x => x.Save(newUser)).Returns(newUser).Verifiable();
        UserService userService = new UserService(repo.Object);

        // Act
        var result = userService.Save(newUser);

        // Assert
        Assert.Equal(newUser, result);
        repo.Verify(x => x.Save(newUser), Times.Once);
    }

    [Fact]
    public void GetById_Successful()
    {
        // Arrange
        Mock<IRepository<User>> repo = new Mock<IRepository<User>>();
        User expectedUser = new User { ID = 1, FullName = "John Doe", Email = "john.doe@revature.com", Password = "password123!", Boards = new List<Board>(), Cards = new List<Card>() };
        repo.Setup(x => x.GetById(1)).Returns(expectedUser);
        UserService userService = new UserService(repo.Object);

        // Act
        var result = userService.GetById(1);

        // Assert
        Assert.Equal(expectedUser, result);
    }

    [Fact]
    public void DeleteById_Successful()
    {
        // Arrange
        Mock<IRepository<User>> repo = new Mock<IRepository<User>>();
        User existingUser = new User { ID = 1, FullName = "John Doe", Email = "john.doe@revature.com", Password = "password123!", Boards = new List<Board>(), Cards = new List<Card>() };

        repo.Setup(x => x.GetById(existingUser.ID)).Returns(existingUser);
        repo.Setup(x => x.Delete(existingUser)).Verifiable();
        UserService userService = new UserService(repo.Object);

        // Act
        userService.DeleteById(existingUser.ID);

        // Assert
        repo.Verify(x => x.GetById(existingUser.ID), Times.Once);
        repo.Verify(x => x.Delete(existingUser), Times.Once);
    }

    [Fact]
    public void Update_Successful()
    {
        // Arrange
        Mock<IRepository<User>> repo = new Mock<IRepository<User>>();
        User existingUser = new User { ID = 1, FullName = "John Doe", Email = "john.doe@revature.com", Password = "password123!", Boards = new List<Board>(), Cards = new List<Card>() };
        User updatedUser = new User { ID = 1, FullName = "John Tractor Doe", Email = "john.doe@revature.net", Password = "password123!", Boards = new List<Board>(), Cards = new List<Card>() };

        repo.Setup(x => x.Update(existingUser.ID, updatedUser)).Returns(updatedUser).Verifiable();
        UserService userService = new UserService(repo.Object);

        // Act
        var result = userService.Update(existingUser.ID, updatedUser);

        // Assert
        Assert.Equal(updatedUser, result);
        repo.Verify(x => x.Update(existingUser.ID, updatedUser), Times.Once);
    }
}