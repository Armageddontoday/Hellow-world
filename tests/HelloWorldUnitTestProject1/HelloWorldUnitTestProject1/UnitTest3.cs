using System.Collections;
using System;
using HellowWorld;
using Moq;
using NUnit;

//namespace HelloWorld
namespace NUnit.Framework.Tests
{

    /// <summary>
    /// тесты присваивания значения поля MathOperation в классах мат. операций
    /// </summary>
    [TestFixture]
    public class MathOperationsInitializationTests
    {
        [Test]
        public void AddMathOpInitialization()
        {
            var add = new AddMathOperation();
            Assert.AreEqual(add.MathOperation, MathOperations.Add);
        }
        [Test]
        public void SubstractMathOpInitialization()
        {
            var substract = new SubstractMathOperation();
            Assert.AreEqual(substract.MathOperation, MathOperations.Substract);
        }
        [Test]
        public void MultiplicateMathOpInitialization()
        {
            var multiplication = new MultiplicateMathOperation();
            Assert.AreEqual(multiplication.MathOperation, MathOperations.Multiplicate);
        }
        [Test]
        public void DivideMathOpInitialization()
        {
            var divide = new DivideMathOperation();
            Assert.AreEqual(divide.MathOperation, MathOperations.Divide);
        }
        [Test]
        public void DegreeMathOpInitialization()
        {
            var degre = new DegreeMathOperation();
            Assert.AreEqual(degre.MathOperation, MathOperations.Degree);
        }
    }
}
