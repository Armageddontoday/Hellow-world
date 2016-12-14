using System.Collections;
using System;
using HellowWorld;
using Moq;
using NUnit;

//namespace HelloWorld
namespace NUnit.Framework.Tests
{
    /// <summary>
    /// тесты методов Result для классов мат опреаций
    /// </summary>
    [TestFixture]
    public class MathOperationGetResultTests
    {        
        [Test]
        public void AddMathResult()
        {
            var add = new AddMathOperation();
            double result = add.GetResult(8, 2);
            Assert.AreEqual(10, result);
        }

        [Test]
        public void SubstractMathResult()
        {
            var substract = new SubstractMathOperation();
            double result = substract.GetResult(8, 2);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void MultiplicateMathResult()
        {
            var multiplicate = new MultiplicateMathOperation();
            double result = multiplicate.GetResult(8, 2);
            Assert.AreEqual(16, result);
        }

        [Test]
        public void DivideMathResult()
        {
            var divide = new DivideMathOperation();
            double result = divide.GetResult(8, 2);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void DegreeMathResult()
        {
            var degree = new DegreeMathOperation();
            double result = degree.GetResult(2, 5);
            Assert.AreEqual(32, result);
        }
    }   
}
