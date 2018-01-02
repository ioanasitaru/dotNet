using System;
//using CreatingModels;
using Data.Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TagModelTests
    {
        [TestMethod]
        public void Given_TagModel_When_LabelIsNull_Then_ShouldThrowException()
        {
            Action a = () => Tag.Create(null);
            a.ShouldThrow<Exception>();
        }
//        [TestMethod]
//        public void Given_TagModel_When_LabelIsNotNull_Then_ShouldNotThrowException()
//        {
//            Action a = () => Tag.Create(new TagCreatingModel {Label = "test"});
//            a.ShouldNotThrow<Exception>();
//        }

    }
}