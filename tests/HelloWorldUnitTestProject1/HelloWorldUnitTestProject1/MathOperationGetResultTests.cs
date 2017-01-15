using System.Collections;
using System;
using HellowWorld;
using Moq;
using NUnit;
using NUnit.Framework;

namespace HelloWorld
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
            Assert.AreEqual(10, new AddMathOperation().GetResult(8, 2));
        }

        [Test]
        public void SubstractMathResult()
        {
            Assert.AreEqual(6, new SubstractMathOperation().GetResult(8, 2));
        }

        [Test]
        public void MultiplicateMathResult()
        {            
            Assert.AreEqual(16, new MultiplicateMathOperation().GetResult(8, 2));
        }

        [Test]
        public void DivideMathResult()
        {
            Assert.AreEqual(4, new DivideMathOperation().GetResult(8, 2));
        }

        [Test]
        public void PowerMathResult()
        {            
            Assert.AreEqual(32, new PowerMathOperation().GetResult(2, 5));
        }
    }   
}
