using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    public interface IMathOperationInterface
    {
        MathOperations CurrentMathOperation { get; }
        double GetResult(int operand1, int operand2);       
    }
    public abstract class AbstractMathOperationClass:IMathOperationInterface
    {
        public MathOperations CurrentMathOperation { get; private set; }
        public AbstractMathOperationClass(MathOperations mathOperation)
        {
            CurrentMathOperation = mathOperation;
        }
        public abstract double GetResult(int operand1, int operand2);        
    }
    public class Add : AbstractMathOperationClass
    {
        public Add() : base(MathOperations.Add)
        { }
        
        public override double GetResult(int operand1, int operand2)
        {
            return operand1 + operand2;
        }
    }
    public class Substract : AbstractMathOperationClass
    {
        public Substract() : base(MathOperations.Substract)
        { }
        public override double GetResult(int operand1, int operand2)
        {
            return operand1 - operand2;
        }
    }
    public class Multiplicate : AbstractMathOperationClass
    {
        public Multiplicate() : base(MathOperations.Multiplicate)
        { }
        public override double GetResult(int operand1, int operand2)
        {
            return operand1 * operand2;
        }
    }
    public class Divide : AbstractMathOperationClass
    {
        public Divide() : base(MathOperations.Divide)
        { }
        public override double GetResult(int operand1, int operand2)
        {
            return Math.Round((double)operand1 / operand2,2);
        }
    }
    public class Degree : AbstractMathOperationClass
    {
        public Degree() : base(MathOperations.Degree)
        { }
        public override double GetResult(int operand1, int operand2)
        {
            return Math.Pow(operand1, operand2);
        }
    }
}
