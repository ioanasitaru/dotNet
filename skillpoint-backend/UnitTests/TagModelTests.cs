using System;
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
            Action a = () => Tag.Create(null,null);
            a.ShouldThrow<Exception>();
        }
        [TestMethod]
        public void Given_TagModel_When_LabelIsNotNull_Then_ShouldNotThrowsException()
        {
            Action a = () => Tag.Create("Label", null);
            a.ShouldNotThrow<Exception>();
        }

    }
}