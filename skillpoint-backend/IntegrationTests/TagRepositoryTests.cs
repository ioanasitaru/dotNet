using Data.Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Repositories.Implementations;

namespace IntegrationTests
{
    [TestClass]
    public class TagRepositoryTests : BaseIntegrationTest
    {
        [TestMethod]
        public void Given_TagRepository_When_CreatingATag_Then_ShouldCreateIt()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var tag = Tag.Create("Label");
                tagRepository.CreateTag(tag);
                tagRepository.GetAllTags().Should().HaveCount(1);
            });

           }
        [TestMethod]
        public void Given_TagRepository_When_DeletingATag_Then_ShouldDeleteIt()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var tag = Tag.Create("Label");
                tagRepository.CreateTag(tag);
                tagRepository.DeleteTag(tag.Id);
                tagRepository.GetAllTags().Should().HaveCount(0);
            });
        }
        [TestMethod]
        public void Given_TagRepository_When_GettingAllTags_Then_ShouldGetAllTags()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var firstTag = Tag.Create("Label1");
                var secondTag = Tag.Create("Label2");
                var thirdTag = Tag.Create("Label3");
                var forthTag = Tag.Create("Label4");
                var fifthTag = Tag.Create("Label5");
                tagRepository.CreateTag(firstTag);
                tagRepository.CreateTag(secondTag);
                tagRepository.CreateTag(thirdTag);
                tagRepository.CreateTag(forthTag);
                tagRepository.CreateTag(fifthTag);
                tagRepository.GetAllTags().Should().HaveCount(5);
            });
        }
        [TestMethod]
        public void Given_TagRepository_When_GettingATagById_Then_ShouldGetIt()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var firstTag = Tag.Create("Label1");
                var secondTag = Tag.Create("Label2");
                var thirdTag = Tag.Create("Label3");
                var forthTag = Tag.Create("Label4");
                var fiftsTag = Tag.Create("Label5");
                tagRepository.CreateTag(firstTag);
                tagRepository.CreateTag(secondTag);
                tagRepository.CreateTag(thirdTag);
                tagRepository.CreateTag(forthTag);
                tagRepository.CreateTag(fiftsTag);
                tagRepository.GetTagById(thirdTag.Id).Should().Be(thirdTag);
            });
        }
        [TestMethod]
        public void Given_TagRepository_When_GettingATagByLabel_Then_ShouldGetIt()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var firstTag = Tag.Create("Label1");
                var secondTag = Tag.Create("Label2");
                var thirdTag = Tag.Create("Label3");
                var forthTag = Tag.Create("Label4");
                var fiftsTag = Tag.Create("Label5");
                tagRepository.CreateTag(firstTag);
                tagRepository.CreateTag(secondTag);
                tagRepository.CreateTag(thirdTag);
                tagRepository.CreateTag(forthTag);
                tagRepository.CreateTag(fiftsTag);
                tagRepository.GetTagByLabel(thirdTag.Label).Should().Be(thirdTag);
            });
        }
        [TestMethod]
        public void Given_TagRepository_When_UpdatingATag_Then_ShouldUpdateIt()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var tag = Tag.Create("Label");
                tagRepository.CreateTag(tag);
                tag.Update(tag.Label, true);
                tagRepository.UpdateTag(tag);
                tagRepository.GetTagById(tag.Id).Should().Be(tag);
            });
        }

    }
}
