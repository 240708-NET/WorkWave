using Moq;
using System.Collections.Generic;
using Xunit;
using Models;
using Services;
using Repository;

namespace WorkWave.Tests;

public class TagServiceTests
{
    [Fact]
    public void GetAll_CorrectOutput()
    {
        // Arrange
        Mock<IRepository<Tag>> repo = new Mock<IRepository<Tag>>();
        List<Tag> expectedTags = new List<Tag>
            {
                new Tag { ID = 1, Description = "Tag 1", Color = "Red", Cards = new List<Card>() },
                new Tag { ID = 2, Description = "Tag 2", Color = "Blue", Cards = new List<Card>() }
            };

        repo.Setup(x => x.List()).Returns(expectedTags);
        TagService tagService = new TagService(repo.Object);

        // Act
        var result = tagService.GetAll();

        // Assert
        Assert.Equal(expectedTags, result);
    }

    [Fact]
    public void GetAll_EmptyList()
    {
        // Arrange
        Mock<IRepository<Tag>> repo = new Mock<IRepository<Tag>>();
        repo.Setup(x => x.List()).Returns(new List<Tag>());
        TagService tagService = new TagService(repo.Object);

        // Act
        var result = tagService.GetAll();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetAll_ReturnNull()
    {
        // Assert
        Mock<IRepository<Tag>> repo = new Mock<IRepository<Tag>>();
        repo.Setup(x => x.List()).Returns((List<Tag>)null);
        TagService tagService = new TagService(repo.Object);

        // Act
        var result = tagService.GetAll();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Save_Successful()
    {
        // Arrange
        Mock<IRepository<Tag>> repo = new Mock<IRepository<Tag>>();
        Tag newTag = new Tag { ID = 1, Description = "Tag 1", Color = "Red", Cards = new List<Card>() };
        repo.Setup(x => x.Save(newTag)).Returns(newTag).Verifiable();
        TagService tagService = new TagService(repo.Object);

        // Act
        var result = tagService.Save(newTag);

        // Assert
        Assert.Equal(newTag, result);
        repo.Verify(x => x.Save(newTag), Times.Once);
    }

    [Fact]
    public void GetById_Successful()
    {
        // Arrange
        Mock<IRepository<Tag>> repo = new Mock<IRepository<Tag>>();
        Tag expectedTag = new Tag { ID = 1, Description = "Tag 1", Color = "Red", Cards = new List<Card>() };
        repo.Setup(x => x.GetById(1)).Returns(expectedTag);
        TagService tagService = new TagService(repo.Object);

        // Act
        var result = tagService.GetById(1);

        // Assert
        Assert.Equal(expectedTag, result);
    }

    [Fact]
    public void DeleteById_Successful()
    {
        // Arrange
        Mock<IRepository<Tag>> repo = new Mock<IRepository<Tag>>();
        Tag existingTag = new Tag { ID = 1, Description = "Tag 1", Color = "Red", Cards = new List<Card>() };

        repo.Setup(x => x.GetById(existingTag.ID)).Returns(existingTag);
        repo.Setup(x => x.Delete(existingTag)).Verifiable();
        TagService tagService = new TagService(repo.Object);

        // Act
        tagService.DeleteById(existingTag.ID);

        // Assert
        repo.Verify(x => x.GetById(existingTag.ID), Times.Once);
        repo.Verify(x => x.Delete(existingTag), Times.Once);
    }

    [Fact]
    public void Update_Successful()
    {
        // Arrange
        Mock<IRepository<Tag>> repo = new Mock<IRepository<Tag>>();
        Tag existingTag = new Tag { ID = 1, Description = "Tag to delete", Color = "Red", Cards = new List<Card>() };
        Tag updatedTag = new Tag { ID = 1, Description = "Tag to update", Color = "Purple", Cards = new List<Card>() };

        repo.Setup(x => x.Update(existingTag.ID, updatedTag)).Returns(updatedTag).Verifiable();
        TagService tagService = new TagService(repo.Object);

        // Act
        var result = tagService.Update(existingTag.ID, updatedTag);

        // Assert
        Assert.Equal(updatedTag, result);
        repo.Verify(x => x.Update(existingTag.ID, updatedTag), Times.Once);
    }
}