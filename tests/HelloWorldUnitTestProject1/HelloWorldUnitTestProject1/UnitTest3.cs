using System.Collections;
using System;
using HellowWorld;
using Moq;
using NUnit;
using NUnit.Framework;

namespace HelloWorld
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
            Assert.AreEqual(new AddMathOperation().MathOperation, MathOperations.Add);
        }
        [Test]
        public void SubstractMathOpInitialization()
        {
            Assert.AreEqual(new SubstractMathOperation().MathOperation, MathOperations.Substract);
        }
        [Test]
        public void MultiplicateMathOpInitialization()
        {
            Assert.AreEqual(new MultiplicateMathOperation().MathOperation, MathOperations.Multiplicate);
        }
        [Test]
        public void DivideMathOpInitialization()
        {
            Assert.AreEqual(new DivideMathOperation().MathOperation, MathOperations.Divide);
        }
        [Test]
        public void DegreeMathOpInitialization()
        {
            Assert.AreEqual(new PowerMathOperation().MathOperation, MathOperations.Power);
        }
    }
}
