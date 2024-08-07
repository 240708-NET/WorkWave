using Moq;
using System.Collections.Generic;
using Xunit;
using Models;
using Services;
using Repository;

namespace WorkWave.Tests;

public class CardServiceTests
{
    [Fact]
    public void GetAll_CorrectOutput()
    {
        // Arrange
        Mock<IRepository<Card>> repo = new Mock<IRepository<Card>>();

        Section section1 = new Section { ID = 1, Name = "Section 1" };
        Section section2 = new Section { ID = 2, Name = "Section 2" };
        Section section3 = new Section { ID = 3, Name = "Section 3" };

        var expectedCards = new List<Card>
            {
                new Card { ID = 1, Title = "Card 1", Description = "This is the first card.", Section = section1, Tags = new List<Tag>(), UsersAssigned = new List<User>() },
                new Card {ID = 2, Title = "Card 2", Description = "This is the second card.", Section = section2, Tags = new List<Tag>(), UsersAssigned = new List<User>()},
                new Card {ID = 3, Title = "Card 3", Description = "This is the third card.", Section = section3, Tags = new List<Tag>(), UsersAssigned = new List<User>()}
            };

        repo.Setup(x => x.List()).Returns(expectedCards);
        CardService cardService = new CardService(repo.Object);

        // Act
        var result = cardService.GetAll();

        // Assert
        Assert.Equal(expectedCards, result);
    }

    [Fact]
    public void GetAll_EmptyList()
    {
        // Arrange
        Mock<IRepository<Card>> repo = new Mock<IRepository<Card>>();
        repo.Setup(x => x.List()).Returns(new List<Card>());
        CardService cardService = new CardService(repo.Object);

        // Act
        var result = cardService.GetAll();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetAll_ReturnNull()
    {
        // Assert
        Mock<IRepository<Card>> repo = new Mock<IRepository<Card>>();
        repo.Setup(x => x.List()).Returns((List<Card>)null);
        CardService cardService = new CardService(repo.Object);

        // Act
        var result = cardService.GetAll();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Save_Successful()
    {
        // Arrange
        Mock<IRepository<Card>> repo = new Mock<IRepository<Card>>();
        Section section1 = new Section { ID = 1, Name = "Section 1" };
        Card newCard = new Card { ID = 1, Title = "New Card", Description = "This is a new card.", Section = section1, Tags = new List<Tag>(), UsersAssigned = new List<User>() };
        repo.Setup(x => x.Save(newCard)).Returns(newCard).Verifiable();
        CardService cardService = new CardService(repo.Object);

        // Act
        var result = cardService.Save(newCard);

        // Assert
        Assert.Equal(newCard, result);
        repo.Verify(x => x.Save(newCard), Times.Once);
    }

    [Fact]
    public void GetById_Successful()
    {
        // Arrange
        Mock<IRepository<Card>> repo = new Mock<IRepository<Card>>();
        Section section1 = new Section { ID = 1, Name = "Section 1" };
        Card expectedCard = new Card { ID = 1, Title = "Card 1", Description = "This is the first card.", Section = section1, Tags = new List<Tag>(), UsersAssigned = new List<User>() };
        repo.Setup(x => x.GetById(1)).Returns(expectedCard);
        CardService cardService = new CardService(repo.Object);

        // Act
        var result = cardService.GetById(1);

        // Assert
        Assert.Equal(expectedCard, result);
    }

    [Fact]
    public void DeleteById_Successful()
    {
        // Arrange
        Mock<IRepository<Card>> repo = new Mock<IRepository<Card>>();
        Section section1 = new Section { ID = 1, Name = "Section 1" };
        Card existingCard = new Card { ID = 1, Title = "Card to Delete", Description = "This card will be deleted.", Section = section1, Tags = new List<Tag>(), UsersAssigned = new List<User>() };

        repo.Setup(x => x.GetById(existingCard.ID)).Returns(existingCard);
        repo.Setup(x => x.Delete(existingCard)).Verifiable();
        CardService cardService = new CardService(repo.Object);

        // Act
        cardService.DeleteById(existingCard.ID);

        // Assert
        repo.Verify(x => x.GetById(existingCard.ID), Times.Once);
        repo.Verify(x => x.Delete(existingCard), Times.Once);
    }

    [Fact]
    public void Update_Successful()
    {
        // Arrange
        Mock<IRepository<Card>> repo = new Mock<IRepository<Card>>();
        Section section1 = new Section { ID = 1, Name = "Section 1" };
        Card existingCard = new Card { ID = 1, Title = "Card to Delete", Description = "This card will be deleted.", Section = section1, Tags = new List<Tag>(), UsersAssigned = new List<User>() };
        Card updatedCard = new Card { ID = 1, Title = "Updated Card", Description = "This card has been updated.", Section = section1, Tags = new List<Tag>(), UsersAssigned = new List<User>() };

        // Setup the mock repository
        repo.Setup(x => x.Update(existingCard.ID, updatedCard)).Returns(updatedCard).Verifiable();
        CardService cardService = new CardService(repo.Object);

        // Act
        var result = cardService.Update(existingCard.ID, updatedCard);

        // Assert
        Assert.Equal(updatedCard, result);
        repo.Verify(x => x.Update(existingCard.ID, updatedCard), Times.Once);
    }
}