using System.Collections;
using System;
using HellowWorld;
using Moq;
using NUnit;
using NUnit.Framework;

namespace HelloWorld
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
            Assert.AreEqual(new AddMathOperation().ToString(), "+");
        }

        [Test]
        public void SubstractOperationCharGetting()
        {
            Assert.AreEqual(new SubstractMathOperation().ToString(), "-");
        }

        [Test]
        public void MultiplicateOperationCharGetting()
        {
            Assert.AreEqual(new MultiplicateMathOperation().ToString(), "*");
        }

        [Test]
        public void DivideOperationCharGetting()
        {
            Assert.AreEqual(new DivideMathOperation().ToString(), "/");
        }

        [Test]
        public void DegreeOperationCharGetting()
        {
            Assert.AreEqual(new PowerMathOperation().ToString(), "^");
        }
    }
}
