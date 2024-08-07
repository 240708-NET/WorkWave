using Moq;
using System.Collections.Generic;
using Xunit;
using Models;
using Services;
using Repository;

namespace WorkWave.Tests;

public class SectionServiceTests
{
    [Fact]
    public void GetAll_CorrectOutput()
    {
        // Arrange
        Mock<IRepository<Section>> repo = new Mock<IRepository<Section>>();
        Board board1 = new Board { ID = 1, Name = "Board 1", Users = new List<User>() };
        List<Section> expectedSections = new List<Section>
            {
                new Section { ID = 1, Name = "Section 1", Board = board1, Cards = new List<Card>() },
                new Section { ID = 2, Name = "Section 2", Board = board1, Cards = new List<Card>() }
            };

        repo.Setup(x => x.List()).Returns(expectedSections);
        SectionService sectionService = new SectionService(repo.Object);

        // Act
        var result = sectionService.GetAll();

        // Assert
        Assert.Equal(expectedSections, result);
    }

    [Fact]
    public void GetAll_EmptyList()
    {
        // Arrange
        Mock<IRepository<Section>> repo = new Mock<IRepository<Section>>();
        repo.Setup(x => x.List()).Returns(new List<Section>());
        SectionService sectionService = new SectionService(repo.Object);

        // Act
        var result = sectionService.GetAll();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetAll_ReturnNull()
    {
        // Assert
        Mock<IRepository<Section>> repo = new Mock<IRepository<Section>>();
        repo.Setup(x => x.List()).Returns((List<Section>)null);
        SectionService sectionService = new SectionService(repo.Object);

        // Act
        var result = sectionService.GetAll();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Save_Successful()
    {
        // Arrange
        Mock<IRepository<Section>> repo = new Mock<IRepository<Section>>();
        Board board1 = new Board { ID = 1, Name = "Board 1", Users = new List<User>() };
        Section newSection= new Section { ID = 1, Name = "Section 1", Board = board1, Cards = new List<Card>() };
        repo.Setup(x => x.Save(newSection)).Returns(newSection).Verifiable();
        SectionService sectionService = new SectionService(repo.Object);

        // Act
        var result = sectionService.Save(newSection);

        // Assert
        Assert.Equal(newSection, result);
        repo.Verify(x => x.Save(newSection), Times.Once);
    }

    [Fact]
    public void GetById_Successful()
    {
        // Arrange
        Mock<IRepository<Section>> repo = new Mock<IRepository<Section>>();
        Board board1 = new Board { ID = 1, Name = "Board 1", Users = new List<User>() };
        Section expectedSection= new Section { ID = 1, Name = "Section 1", Board = board1, Cards = new List<Card>() };
        repo.Setup(x => x.GetById(1)).Returns(expectedSection);
        SectionService sectionService = new SectionService(repo.Object);

        // Act
        var result = sectionService.GetById(1);

        // Assert
        Assert.Equal(expectedSection, result);
    }

    [Fact]
    public void DeleteById_Successful()
    {
        // Arrange
        Mock<IRepository<Section>> repo = new Mock<IRepository<Section>>();
        Board board1 = new Board { ID = 1, Name = "Board 1", Users = new List<User>() };
        Section existingSection= new Section { ID = 1, Name = "Section 1", Board = board1, Cards = new List<Card>() };
       
        repo.Setup(x => x.GetById(existingSection.ID)).Returns(existingSection);
        repo.Setup(x => x.Delete(existingSection)).Verifiable();
        SectionService sectionService = new SectionService(repo.Object);

        // Act
        sectionService.DeleteById(existingSection.ID);

        // Assert
        repo.Verify(x => x.GetById(existingSection.ID), Times.Once);
        repo.Verify(x => x.Delete(existingSection), Times.Once);
    }

    [Fact]
    public void Update_Successful()
    {
        // Arrange
        Mock<IRepository<Section>> repo = new Mock<IRepository<Section>>();
        Board board1 = new Board { ID = 1, Name = "Board 1", Users = new List<User>() };
        Section existingSection= new Section { ID = 1, Name = "Section to delete", Board = board1, Cards = new List<Card>() };
        Section updatedSection= new Section { ID = 1, Name = "Section to update", Board = board1, Cards = new List<Card>() };
        
        repo.Setup(x => x.Update(existingSection.ID, updatedSection)).Returns(updatedSection).Verifiable();
        SectionService sectionService = new SectionService(repo.Object);

        // Act
        var result = sectionService.Update(existingSection.ID, updatedSection);

        // Assert
        Assert.Equal(updatedSection, result);
        repo.Verify(x => x.Update(existingSection.ID, updatedSection), Times.Once);
    }
}