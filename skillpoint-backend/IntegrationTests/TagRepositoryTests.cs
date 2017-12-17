using Business.Repositories.Implementations;
using CreatingModels;
using Data.Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests
{
    [TestClass]
    public class TagRepositoryTests : BaseIntegrationTest
    {

//        [TestMethod]
//        public void Given_TagRepository_When_CreatingATag_Then_ShouldCreateIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var tagRepository = new TagsRepository(sut);
//                var currentTagsInDatabase = tagRepository.GetAllTags().Count;
//
//                var tag = Tag.Create(new TagCreatingModel(){Label = "cola"});
//                tagRepository.CreateTag(tag);
//                tagRepository.GetAllTags().Should().HaveCount(currentTagsInDatabase+1);
//            });
//
//    }
//
//        [TestMethod]
//        public void Given_TagRepository_When_DeletingATag_Then_ShouldDeleteIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var tagRepository = new TagsRepository(sut);
//                var tag = Tag.Create(new TagCreatingModel() { Label = "cola" });
//                tagRepository.CreateTag(tag);
//                var currentTagsInDatabase = tagRepository.GetAllTags().Count;
//                tagRepository.DeleteTag(tag.Label);
//                tagRepository.GetAllTags().Should().HaveCount(currentTagsInDatabase-1);
//            });
//        }
//        [TestMethod]
//        public void Given_TagRepository_When_GettingAllTags_Then_ShouldGetAllTags()
//        {
//            RunOnDatabase(sut =>
//            {
//
//                var tagRepository = new TagsRepository(sut);
//
//                var currentTagsInDatabase = tagRepository.GetAllTags().Count;
//
//                var firstTag = Tag.Create(new TagCreatingModel(){Label = "Label1"});
//                var secondTag = Tag.Create(new TagCreatingModel() { Label = "Label2" });
//                var thirdTag = Tag.Create(new TagCreatingModel() { Label = "Label3" });
//                var forthTag = Tag.Create(new TagCreatingModel() { Label = "Label4" });
//                var fifthTag = Tag.Create(new TagCreatingModel() { Label = "Label5" });
//                tagRepository.CreateTag(firstTag);
//                tagRepository.CreateTag(secondTag);
//                tagRepository.CreateTag(thirdTag);
//                tagRepository.CreateTag(forthTag);
//                tagRepository.CreateTag(fifthTag);
//                tagRepository.GetAllTags().Should().HaveCount(currentTagsInDatabase + 5);
//            });
//        }
//
//        [TestMethod]
//        public void Given_TagRepository_When_GettingATagByLabel_Then_ShouldGetIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var tagRepository = new TagsRepository(sut);
//                var firstTag = Tag.Create(new TagCreatingModel() { Label = "Label1" });
//                var secondTag = Tag.Create(new TagCreatingModel() { Label = "Label2" });
//                var thirdTag = Tag.Create(new TagCreatingModel() { Label = "Label3" });
//                var forthTag = Tag.Create(new TagCreatingModel() { Label = "Label4" });
//                var fifthTag = Tag.Create(new TagCreatingModel() { Label = "Label5" });
//                tagRepository.CreateTag(firstTag);
//                tagRepository.CreateTag(secondTag);
//                tagRepository.CreateTag(thirdTag);
//                tagRepository.CreateTag(forthTag);
//                tagRepository.CreateTag(fifthTag);
//                tagRepository.GetTagByLabel(thirdTag.Label).Should().Be(thirdTag);
//            });
//        }
//        [TestMethod]
//        public void Given_TagRepository_When_UpdatingATag_Then_ShouldUpdateIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var tagRepository = new TagsRepository(sut);
//                var tag = Tag.Create(new TagCreatingModel() { Label = "Label1" });
//                tagRepository.CreateTag(tag);
//                var initialVerifiedValue = tag.Verified;
//                tag.Update(tag.Label, true);
//                tagRepository.UpdateTag(tag);
//
//                tagRepository.GetTagByLabel(tag.Label).Should().NotBe(initialVerifiedValue);
//
//            });
//        }

    }
}
