using Business;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

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
                var tag = Tag.Create("Label", new Data.Domain.User());
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
                var tag = Tag.Create("Label", new Data.Domain.User());
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
                var firstTag = Tag.Create("Label1", new Data.Domain.User());
                var secondTag = Tag.Create("Label2", new Data.Domain.User());
                var thirdTag = Tag.Create("Label3", new Data.Domain.User());
                var forthTag = Tag.Create("Label4", new Data.Domain.User());
                var fiftsTag = Tag.Create("Label5", new Data.Domain.User());
                tagRepository.CreateTag(firstTag);
                tagRepository.CreateTag(secondTag);
                tagRepository.CreateTag(thirdTag);
                tagRepository.CreateTag(forthTag);
                tagRepository.CreateTag(fiftsTag);
                tagRepository.GetAllTags().Should().HaveCount(5);
            });
        }
        [TestMethod]
        public void Given_TagRepository_When_GettingATagById_Then_ShouldGetIt()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var firstTag = Tag.Create("Label1", new Data.Domain.User());
                var secondTag = Tag.Create("Label2", new Data.Domain.User());
                var thirdTag = Tag.Create("Label3", new Data.Domain.User());
                var forthTag = Tag.Create("Label4", new Data.Domain.User());
                var fiftsTag = Tag.Create("Label5", new Data.Domain.User());
                tagRepository.CreateTag(firstTag);
                tagRepository.CreateTag(secondTag);
                tagRepository.CreateTag(thirdTag);
                tagRepository.CreateTag(forthTag);
                tagRepository.CreateTag(fiftsTag);
                tagRepository.GetTagById(thirdTag.Id).Should().Equals(thirdTag);
            });
        }
        [TestMethod]
        public void Given_TagRepository_When_GettingATagByLabel_Then_ShouldGetIt()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var firstTag = Tag.Create("Label1", new Data.Domain.User());
                var secondTag = Tag.Create("Label2", new Data.Domain.User());
                var thirdTag = Tag.Create("Label3", new Data.Domain.User());
                var forthTag = Tag.Create("Label4", new Data.Domain.User());
                var fiftsTag = Tag.Create("Label5", new Data.Domain.User());
                tagRepository.CreateTag(firstTag);
                tagRepository.CreateTag(secondTag);
                tagRepository.CreateTag(thirdTag);
                tagRepository.CreateTag(forthTag);
                tagRepository.CreateTag(fiftsTag);
                tagRepository.GetTagByLabel(thirdTag.Label).Should().Equals(thirdTag);
            });
        }
        [TestMethod]
        public void Given_TagRepository_When_UpdatingATag_Then_ShouldUpdateIt()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var tag = Tag.Create("Label", new Data.Domain.User());
                tagRepository.CreateTag(tag);
                tag.Update(tag.Label, true, new Data.Domain.User());
                tagRepository.UpdateTag(tag);
                tagRepository.GetTagById(tag.Id).Should().Equals(tag);
            });
        }

    }
}
