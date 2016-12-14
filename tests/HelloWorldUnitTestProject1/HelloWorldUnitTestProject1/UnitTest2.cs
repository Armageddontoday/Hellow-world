using System.Collections;
using System;
using HellowWorld;
using Moq;
using NUnit;

//namespace HelloWorld
namespace NUnit.Framework.Tests
{

    /// <summary>
    /// тесты правильности возвращаемого символа
    /// </summary>
    [TestFixture]
    public class GetMathOperationCharTests
    {
        [Test]
        public void AddOperationCharGetting()
        {
            var add = new AddMathOperation();
            Assert.AreEqual(add.ToString(), "+");
        }

        [Test]
        public void SubstractOperationCharGetting()
        {
            var substract = new SubstractMathOperation();
            Assert.AreEqual(substract.ToString(), "-");
        }

        [Test]
        public void MultiplicateOperationCharGetting()
        {
            var multiplicate = new MultiplicateMathOperation();
            Assert.AreEqual(multiplicate.ToString(), "*");
        }

        [Test]
        public void DivideOperationCharGetting()
        {
            var divide = new DivideMathOperation();
            Assert.AreEqual(divide.ToString(), "/");
        }

        [Test]
        public void DegreeOperationCharGetting()
        {
            var degree = new DegreeMathOperation();
            Assert.AreEqual(degree.ToString(), "^");
        }
    }
}
