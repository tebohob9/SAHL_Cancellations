using Cancellations_Tests.BasePage;
using NUnit.Framework;
using System;

namespace Cancellations_Tests.Tests
{
    [TestFixture]
    public class SimpleTest
    {
        [Test]
        public void TestMethod()
        {
            Console.WriteLine("This is a simple test");
            Assert.Pass("Test passed!");
        }
    }
}

