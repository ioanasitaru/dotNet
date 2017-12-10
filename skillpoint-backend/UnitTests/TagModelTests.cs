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
        public void Given_TagModel_When_LabelIsNull_Then_ShouldThrowException()
        {
            Action a = () => Tag.Create(null);
            a.ShouldThrow<Exception>();
        }

    }
}