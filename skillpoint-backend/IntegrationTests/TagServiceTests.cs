using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Repositories.Implementations;
using Business.Repositories.Interfaces;
using Business.Services.Implementations;
using Business.Services.Interfaces;
using Data.Domain.Entities;

namespace IntegrationTests
{
    [TestClass]
    public class TagServiceTests : BaseIntegrationTest
    {
//        [TestMethod]
//        public void Given_TagService_When_CreatingATag_Then_ShouldCreateIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                ITagsRepository tagRepository = new TagsRepository(sut);
//                ITagsService tagService = new TagsService(tagRepository);
//                var tag = Tag.Create("Label");
//                tagService.CreateTag(tag);
//                tagService.GetAllTags().Should().HaveCount(1);
//            });
//
//        }
//        [TestMethod]
//        public void Given_TagService_When_DeletingATag_Then_ShouldDeleteIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var tagRepository = new TagsRepository(sut);
//                var tagService = new TagsService(tagRepository);
//                var tag = Tag.Create("Label");
//                tagService.CreateTag(tag);
//                
//                tagService.GetAllTags().Should().HaveCount(0);
//            });
//        }
//        [TestMethod]
//        public void Given_TagService_When_GettingAllTags_Then_ShouldGetAllTags()
//        {
//            RunOnDatabase(sut =>
//            {
//                var tagRepository = new TagsRepository(sut);
//                var tagService = new TagsService(tagRepository);
//                var firstTag = Tag.Create("Label1");
//                var secondTag = Tag.Create("Label2");
//                var thirdTag = Tag.Create("Label3");
//                var forthTag = Tag.Create("Label4");
//                var fiftsTag = Tag.Create("Label5");
//                tagService.CreateTag(firstTag);
//                tagService.CreateTag(secondTag);
//                tagService.CreateTag(thirdTag);
//                tagService.CreateTag(forthTag);
//                tagService.CreateTag(fiftsTag);
//                tagService.GetAllTags().Should().HaveCount(5);
//            });
//        }
//        [TestMethod]
//        public void Given_TagService_When_GettingATagById_Then_ShouldGetIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var tagRepository = new TagsRepository(sut);
//                var tagService = new TagsService(tagRepository);
//                var firstTag = Tag.Create("Label1");
//                var secondTag = Tag.Create("Label2");
//                var thirdTag = Tag.Create("Label3");
//                var forthTag = Tag.Create("Label4");
//                var fiftsTag = Tag.Create("Label5");
//                tagService.CreateTag(firstTag);
//                tagService.CreateTag(secondTag);
//                tagService.CreateTag(thirdTag);
//                tagService.CreateTag(forthTag);
//                tagService.CreateTag(fiftsTag);
//                
//            });
//        }
//        [TestMethod]
//        public void Given_TagService_When_GettingATagByLabel_Then_ShouldGetIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var tagRepository = new TagsRepository(sut);
//                var tagService = new TagsService(tagRepository);
//                var firstTag = Tag.Create("Label1");
//                var secondTag = Tag.Create("Label2");
//                var thirdTag = Tag.Create("Label3");
//                var forthTag = Tag.Create("Label4");
//                var fiftsTag = Tag.Create("Label5");
//                tagService.CreateTag(firstTag);
//                tagService.CreateTag(secondTag);
//                tagService.CreateTag(thirdTag);
//                tagService.CreateTag(forthTag);
//                tagService.CreateTag(fiftsTag);
//                tagService.GetTagByLabel(thirdTag.Label).Should().Be(thirdTag);
//            });
//        }
//        [TestMethod]
//        public void Given_TagService_When_UpdatingATag_Then_ShouldUpdateIt()
//        {
//            RunOnDatabase(sut =>
//            {
//                var tagRepository = new TagsRepository(sut);
//                var tagService = new TagsService(tagRepository);
//                var tag = Tag.Create("Label");
//                tagService.CreateTag(tag);
//                tag.Update(tag.Label, true);
//                tagService.UpdateTag(tag);
//                
//            });
//        }
    }
}
