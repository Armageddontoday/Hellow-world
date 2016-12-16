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
    public class TaskTest
    {
        [Test]
        public void TaskInitialization()
        {
            var iMathOperationMock = new Mock<IMathOperation>();
            iMathOperationMock.Setup(a => a.GetResult(2,3)).Returns(5);           
            var task = new Task(2,3, iMathOperationMock.Object, null);
            Assert.AreEqual(task.Operand1, 2);
            Assert.AreEqual(task.Operand2, 3);
            Assert.AreEqual(task.CorrectAnswer, 5);
        }        
    }
}