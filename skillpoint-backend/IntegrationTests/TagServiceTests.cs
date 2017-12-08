﻿using Business;
using Data.Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

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
                var tagRepository = new TagsRepository(sut);
                var tagService = new TagsService(tagRepository);
                var tag = Tag.Create("Label", new Data.Domain.User());
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
                var tag = Tag.Create("Label", new Data.Domain.User());
                tagService.CreateTag(tag);
                tagService.DeleteTag(tag.Id);
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
                var firstTag = Tag.Create("Label1", new Data.Domain.User());
                var secondTag = Tag.Create("Label2", new Data.Domain.User());
                var thirdTag = Tag.Create("Label3", new Data.Domain.User());
                var forthTag = Tag.Create("Label4", new Data.Domain.User());
                var fiftsTag = Tag.Create("Label5", new Data.Domain.User());
                tagService.CreateTag(firstTag);
                tagService.CreateTag(secondTag);
                tagService.CreateTag(thirdTag);
                tagService.CreateTag(forthTag);
                tagService.CreateTag(fiftsTag);
                tagService.GetAllTags().Should().HaveCount(5);
            });
        }
        [TestMethod]
        public void Given_TagService_When_GettingATagById_Then_ShouldGetIt()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var tagService = new TagsService(tagRepository);
                var firstTag = Tag.Create("Label1", new Data.Domain.User());
                var secondTag = Tag.Create("Label2", new Data.Domain.User());
                var thirdTag = Tag.Create("Label3", new Data.Domain.User());
                var forthTag = Tag.Create("Label4", new Data.Domain.User());
                var fiftsTag = Tag.Create("Label5", new Data.Domain.User());
                tagService.CreateTag(firstTag);
                tagService.CreateTag(secondTag);
                tagService.CreateTag(thirdTag);
                tagService.CreateTag(forthTag);
                tagService.CreateTag(fiftsTag);
                tagService.GetTagById(thirdTag.Id).Should().Equals(thirdTag);
            });
        }
        [TestMethod]
        public void Given_TagService_When_GettingATagByLabel_Then_ShouldGetIt()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var tagService = new TagsService(tagRepository);
                var firstTag = Tag.Create("Label1", new Data.Domain.User());
                var secondTag = Tag.Create("Label2", new Data.Domain.User());
                var thirdTag = Tag.Create("Label3", new Data.Domain.User());
                var forthTag = Tag.Create("Label4", new Data.Domain.User());
                var fiftsTag = Tag.Create("Label5", new Data.Domain.User());
                tagService.CreateTag(firstTag);
                tagService.CreateTag(secondTag);
                tagService.CreateTag(thirdTag);
                tagService.CreateTag(forthTag);
                tagService.CreateTag(fiftsTag);
                tagService.GetTagByLabel(thirdTag.Label).Should().Equals(thirdTag);
            });
        }
        [TestMethod]
        public void Given_TagService_When_UpdatingATag_Then_ShouldUpdateIt()
        {
            RunOnDatabase(sut =>
            {
                var tagRepository = new TagsRepository(sut);
                var tagService = new TagsService(tagRepository);
                var tag = Tag.Create("Label", new Data.Domain.User());
                tagService.CreateTag(tag);
                tag.Update(tag.Label, true, new Data.Domain.User());
                tagService.UpdateTag(tag);
                tagService.GetTagById(tag.Id).Should().Equals(tag);
            });
        }

    }
}