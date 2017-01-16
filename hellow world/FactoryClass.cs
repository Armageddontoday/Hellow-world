using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    public class TaskFactory
    {
        private IMathOperationsFactory _randomMathOp;
        private Random _random;
        private IMathOperationsFactory[] _mathOperationsFactoryArray = new IMathOperationsFactory[5];

        public TaskFactory()
        {
            _random = new Random();
            _mathOperationsFactoryArray[0] = new AddFactory();
            _mathOperationsFactoryArray[1] = new SubstractFactory();
            _mathOperationsFactoryArray[2] = new MultiplicateFactory();
            _mathOperationsFactoryArray[3] = new DivideFactory();
            _mathOperationsFactoryArray[4] = new PowerFactory();
        }
    
        public Task PrepareNewTask(Task previousTask)
        {
            _randomMathOp = _mathOperationsFactoryArray[_random.Next(0, 5)];
            return new Task(_random.Next(1, 10), _random.Next(1, 10), _randomMathOp.Create(), previousTask);
        }
    }

    public interface IMathOperation
    {
        MathOperations MathOperation { get; }
        double GetResult(int operand1, int operand2);       
    }
    public abstract class AbstractMathOperation : IMathOperation
    {
        public MathOperations MathOperation { get; private set; }
        public AbstractMathOperation(MathOperations mathOperation)
        {
            MathOperation = mathOperation;
        }
        public abstract double GetResult(int operand1, int operand2);        
    }
    public class AddMathOperation : AbstractMathOperation
    {
        public AddMathOperation() : base(MathOperations.Add)
        { }
        
        public override double GetResult(int operand1, int operand2)
        {
            return operand1 + operand2;
        }
        public override string ToString()
        {
            return "+" ;
        }
    }
    public class SubstractMathOperation : AbstractMathOperation
    {
        public SubstractMathOperation() : base(MathOperations.Substract)
        { }
        public override double GetResult(int operand1, int operand2)
        {
            return operand1 - operand2;
        }
        public override string ToString()
        {
            return "-";
        }
    }
    public class MultiplicateMathOperation : AbstractMathOperation
    {
        public MultiplicateMathOperation() : base(MathOperations.Multiplicate)
        { }
        public override double GetResult(int operand1, int operand2)
        {
            return operand1 * operand2;
        }
        public override string ToString()
        {
            return "*";
        }
    }
    public class DivideMathOperation : AbstractMathOperation
    {
        public DivideMathOperation() : base(MathOperations.Divide)
        { }
        public override double GetResult(int operand1, int operand2)
        {
            return Math.Round((double)operand1 / operand2,2);
        }
        public override string ToString()
        {
            return "/";
        }
    }
    public class PowerMathOperation : AbstractMathOperation
    {
        public PowerMathOperation() : base(MathOperations.Power)
        { }
        public override double GetResult(int operand1, int operand2)
        {
            return Math.Pow(operand1, operand2);
        }
        public override string ToString()
        {
            return "^";
        }
    }

    public interface IMathOperationsFactory
    {
        IMathOperation Create();
    }   
    public class AddFactory : IMathOperationsFactory
    {
        public  IMathOperation Create()
        {
            return new AddMathOperation();
        }
    }
    public class SubstractFactory : IMathOperationsFactory
    {
        public  IMathOperation Create()
        {
            return new SubstractMathOperation();
        }
    }
    public class MultiplicateFactory : IMathOperationsFactory
    {
        public  IMathOperation Create()
        {
            return new MultiplicateMathOperation();
        }
    }
    public class DivideFactory : IMathOperationsFactory
    {
        public  IMathOperation Create()
        {
            return new DivideMathOperation();
        }
    }
    public class PowerFactory : IMathOperationsFactory
    {
        public  IMathOperation Create()
        {
            return new PowerMathOperation();
        }
    }
}
