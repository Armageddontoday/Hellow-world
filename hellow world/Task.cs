using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    public class Task
    {        
        public int Operand1 { get; private set; }
        public int Operand2 { get; private set; }        
        public MathOperations MathOperation;      
        public double CorrectAnswer;
        public Task PreviousTask { get; private set; }
        public Task(int operand1, int operand2, MathOperations mathOperation, Task previousTask)
        {           
            Operand1 = operand1;
            Operand2 = operand2;            
            MathOperation = mathOperation;
            CorrectAnswer = CurrentCorrectAnswer(Operand1, Operand2, MathOperation);
            PreviousTask = previousTask;
        }
        /// <summary>
        /// возващает правильный ответ на текущее задание
        /// для дробей в случае деления округление до сотых
        /// </summary>        
        private double CurrentCorrectAnswer(int operand1, int operand2, MathOperations MathOperation)
        {   
            switch (MathOperation)
            {
                case MathOperations.Add:
                    return (operand1 + operand2);
                case MathOperations.Substract:
                    return (operand1 - operand2);
                case MathOperations.Multiplicate:
                    return (operand1 * operand2);
                case MathOperations.Divide:
                    double result = (double)operand1 / operand2;
                    return Math.Round(result, 2);
                case MathOperations.Degree:
                    return Math.Pow(operand1, operand2);
            }
            return 0;
        }       
    }
}
