using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Domain.Entities;

namespace UnitTests
{
    [TestClass]
    public class TagModelTests
    {
        [TestMethod]
        public void Given_TagModel_When_LabelIsNull_Then_ShouldThrowsException()
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