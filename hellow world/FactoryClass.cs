using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    public class TaskFactory
    {       
        Random random = new Random();
        private IMathOpFactory RandomMathOp;
        public TaskFactory()
        {             
        }       
        public Task PrepareNewTask(Task previousTask)
        {
            IMathOpFactory[] MathOperationsMassive = { new AddCreator(), new SubstractCreator(), new MultiplicateCreator(), new DivideCreator(), new PowerCreator() };
            RandomMathOp = MathOperationsMassive[random.Next(0, 5)];
            return new Task(random.Next(1, 10), random.Next(1, 10), RandomMathOp.Create(), previousTask);
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

    public interface IMathOpFactory
    {
        IMathOperation Create();
    }
    public abstract class AbstractMathOpFactory : IMathOpFactory
    {
        public abstract IMathOperation Create();
    }
    public class AddCreator : AbstractMathOpFactory
    {
        public override IMathOperation Create()
        {
            return new AddMathOperation();
        }
    }
    public class SubstractCreator : AbstractMathOpFactory
    {
        public override IMathOperation Create()
        {
            return new SubstractMathOperation();
        }
    }
    public class MultiplicateCreator : AbstractMathOpFactory
    {
        public override IMathOperation Create()
        {
            return new MultiplicateMathOperation();
        }
    }
    public class DivideCreator : AbstractMathOpFactory
    {
        public override IMathOperation Create()
        {
            return new DivideMathOperation();
        }
    }
    public class PowerCreator : AbstractMathOpFactory
    {
        public override IMathOperation Create()
        {
            return new PowerMathOperation();
        }
    }
}
