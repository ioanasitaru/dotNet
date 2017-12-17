using System.Collections.Generic;
using Business.Repositories.Implementations;
using Business.Repositories.Interfaces;
using Business.Services.Implementations;
using Business.Services.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests
{
    [TestClass]
    public class TagServiceTests : BaseIntegrationTest
    {
        [TestMethod]
        public void Given_TagService_When_CreatingATag_Then_ShouldCreateIt()
        {
            RunOnDatabase(sut =>
            {
                ITagsRepository tagRepository = new TagsRepository(sut);
                ITagsService tagService = new TagsService(tagRepository);
                var tag = Tag.Create(new TagCreatingModel(){Label = "Label"});
                tagService.CreateTag(tag);
                tagService.GetAllTags().Should().HaveCount(1);
            });

        }
        [TestMethod]
        public void Given_TagService_When_DeletingATag_Then_ShouldDeleteIt()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var tagService = new TagsService(tagRepository);
                var tag = Tag.Create(new TagCreatingModel(){Label = "Label"});
                tagService.CreateTag(tag);
                tagService.DeleteTag(tag.Label);
                tagService.GetAllTags().Should().HaveCount(0);
            });
        }
        [TestMethod]
        public void Given_TagService_When_GettingAllTags_Then_ShouldGetAllTags()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var tagService = new TagsService(tagRepository);
                var firstTag = Tag.Create(new TagCreatingModel() { Label = "Label1" });
                var secondTag = Tag.Create(new TagCreatingModel() { Label = "Label2" });
                var thirdTag = Tag.Create(new TagCreatingModel() { Label = "Label3" });
                var forthTag = Tag.Create(new TagCreatingModel() { Label = "Label4" });
                var fifthTag = Tag.Create(new TagCreatingModel() { Label = "Label5" });
                tagService.CreateTag(firstTag);
                tagService.CreateTag(secondTag);
                tagService.CreateTag(thirdTag);
                tagService.CreateTag(forthTag);
                tagService.CreateTag(fifthTag);
                tagService.GetAllTags().Should().HaveCount(5);
            });
        }
        [TestMethod]
        public void Given_TagService_When_GettingATagByLabel_Then_ShouldGetIt()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var tagService = new TagsService(tagRepository);
                var firstTag = Tag.Create(new TagCreatingModel() { Label = "Label1" });
                var secondTag = Tag.Create(new TagCreatingModel() { Label = "Label2" });
                var thirdTag = Tag.Create(new TagCreatingModel() { Label = "Label3" });
                var forthTag = Tag.Create(new TagCreatingModel() { Label = "Label4" });
                var fifthTag = Tag.Create(new TagCreatingModel() { Label = "Label5" });
                tagService.CreateTag(firstTag);
                tagService.CreateTag(secondTag);
                tagService.CreateTag(thirdTag);
                tagService.CreateTag(forthTag);
                tagService.CreateTag(fifthTag);
                tagService.GetTagByLabel(thirdTag.Label).Should().Be(thirdTag);
            });
        }
        [TestMethod]
        public void Given_TagService_When_UpdatingATag_Then_ShouldUpdateIt()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var tagService = new TagsService(tagRepository);
                var tag = Tag.Create(new TagCreatingModel() { Label = "Label1" });
                tagService.CreateTag(tag);
                tag.Update(tag.Label, true);
                tagService.UpdateTag(tag);
                
            });
        }

        [TestMethod]
        public void Given_TagService_When_TagsFromCreatingModels_Then_ShouldReturnListOfTagEntities()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var tagService = new TagsService(tagRepository);

                List<TagCreatingModel> creatingModels = new List<TagCreatingModel>();

                creatingModels.Add(new TagCreatingModel() { Label = "Label1" });
                creatingModels.Add(new TagCreatingModel() { Label = "Label2" });
                creatingModels.Add(new TagCreatingModel() { Label = "Label3" });



                var tagList = tagService.TagsFromCreatingModels(creatingModels);

                bool existsFlag = false;
                foreach (var entity in tagList)
                {
                     existsFlag = false;

                    foreach (var creatingModel in creatingModels)
                    {
                        if (entity.Label.Equals(creatingModel.Label))
                        {
                            existsFlag = true;
                            break;
                        }
                    }

                    if (existsFlag.Equals(false))
                    {
                        break;
                    }
                }

                existsFlag.Should().BeTrue();


            });
        }

        // + Perciun Adrian
    }
}
