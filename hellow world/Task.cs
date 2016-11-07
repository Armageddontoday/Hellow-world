using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    public class Task
    {        
        public int Operand1 { get; private set; }//два текущих операнда
        public int Operand2 { get; private set; }        
        public MathOperation MathOperation;//текущая операция
        public char MathOpSign { get; private set; }//знак текущей операции(для UIHelper'a)
        public double CorrectAnswer;//правильный ответ на текущее задание
        public Task PreviousTask { get; private set; }
        public Task(int operand1, int operand2, MathOperation mathOperation, Task previousTask)
        {           
            Operand1 = operand1;
            Operand2 = operand2;            
            MathOperation = mathOperation;
            MathOpSign = CurrentMathOpSign(MathOperation);
            CorrectAnswer = CurrentCorrectAnswer(Operand1, Operand2, MathOperation);
            PreviousTask = previousTask;
        }
        private double CurrentCorrectAnswer(int operand1, int operand2, MathOperation MathOperation)
        {
            //возващает правильный ответ на текущее задание
            //для дробей в случае деления округление до сотых
            switch (MathOperation)
            {
                case MathOperation.Add:
                    return (operand1+operand2);
                case MathOperation.Substract:
                    return (operand1 - operand2);
                case MathOperation.Multiplicate:
                    return (operand1 * operand2);
                case MathOperation.Divide:
                    double result = (double)operand1 / operand2;
                    return Math.Round(result,2);
                case MathOperation.Degree:
                    return Math.Pow(operand1,  operand2);
            }
            return 0;
        }
        private char CurrentMathOpSign(MathOperation MathOperation)
        {//возвращает символ текущей операции для UIHelper'a
            switch (MathOperation)
            {
                case MathOperation.Add:
                    return '+';
                case MathOperation.Substract:
                    return '-';
                case MathOperation.Multiplicate:
                    return '*';
                case MathOperation.Divide:
                    return '/';
                case MathOperation.Degree:
                    return '^';
            }
            return '0';
        }
    }
}
