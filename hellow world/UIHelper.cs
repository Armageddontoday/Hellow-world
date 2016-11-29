using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    class UIHelper
    {
        public void ShowMessage(Task task, RoundStatuses status, string userAnswer)
        {
            switch (status)
            {
                case RoundStatuses.Initial:
                    ShowGreetingMessage();
                    ShowCurrentTask(task);
                    break;
                case RoundStatuses.CorrectAnswer:                    
                    ShowNewCorrectAnswer(task);
                    ShowCurrentTask(task);
                    break;
                case RoundStatuses.IncorrectAnswer:
                    ShowGreetingMessage();
                    ShowWrongAnswer(task, double.Parse(userAnswer));
                    ShowCurrentTask(task);
                    break;
                case RoundStatuses.Next:
                    ShowGreetingMessage();
                    ShowCurrentTask(task);
                    break;
                case RoundStatuses.InvalidInput:
                    ShowGreetingMessage();
                    ShowErrorMessage();
                    ShowCurrentTask(task);
                    break; 

            }
        }
        /// <summary>
        /// Набор строк, которые висят в верхней части экрана
        /// </summary>
        public void ShowGreetingMessage()
        {
            Console.Clear();
            Console.WriteLine("Hellow, User!");
            Console.WriteLine("Type answer or use commands\"Exit\" to exit or \"Next\" for another task.");
            Console.WriteLine("In case of a fractional answer type number rounded to the hundredths");
            Console.WriteLine();            
        }
        /// <summary>
        ///  Набор сообщений об ошибочном вводе
        /// </summary>
        public void ShowErrorMessage()
        {
            Console.Clear();
            ShowGreetingMessage();
            Console.WriteLine("Input error!");
            Console.WriteLine("You have to enter number or use \"Exit\" / \"Next\" command.");
            Console.WriteLine("In case of a fractional answer type number rounded to the hundredths");
            Console.WriteLine("Let's try again:");            

        }
        /// <summary>
        /// Набор строк о правильном ответе. Очищает экран, выводит первые строки. 
        /// Показывает выражение и введённый ответ, выдает сообщение об успехе.
        /// </summary>
        public void ShowNewCorrectAnswer(Task task)
        {
            Console.Clear();
            ShowGreetingMessage();
            Console.WriteLine("{0} {2} {1} = {3}!", task.PreviousTask.Operand1, task.PreviousTask.Operand2, GetMathOperationChar(task.PreviousTask.MathOperation.CurrentMathOperation), task.PreviousTask.CorrectAnswer);
            Console.WriteLine("Correct!");
            Console.WriteLine("Lets play another one!");
            Console.WriteLine();            
        }
        /// <summary>
        /// Аналогично ShowCorrectAnswer, но выдаёт сообщение об ошибочном ответе
        /// </summary>
        public void ShowWrongAnswer(Task task, double answer)
        {
            Console.Clear();
            ShowGreetingMessage();
            Console.WriteLine("{0} {2} {1} isn't = {3}!", task.Operand1, task.Operand2, GetMathOperationChar(task.MathOperation.CurrentMathOperation), answer);
            Console.WriteLine("Your answer is incorrect!");
            Console.WriteLine("Try again:");
            Console.WriteLine();            
        }
        /// <summary>
        /// запрос на ввод пользователем ответа, ответ в формате строки проверяется 
        /// </summary>
        public string GetUserAnswer()
        {
            return Console.ReadLine();
        }
        /// <summary>
        /// вывод на экран  текущего задания
        /// </summary>
        public void ShowCurrentTask(Task task)
        {
            Console.Write("{0} {2} {1} = ", task.Operand1, task.Operand2, GetMathOperationChar(task.MathOperation.CurrentMathOperation));
        }
        /// <summary>
        /// возвращает символ текущей операции для UIHelper'a
        /// </summary>

        private char GetMathOperationChar(MathOperations mathOperation)
        {
            switch (mathOperation)
            {
                case MathOperations.Add:
                    return '+';
                case MathOperations.Substract:
                    return '-';
                case MathOperations.Multiplicate:
                    return '*';
                case MathOperations.Divide:
                    return '/';
                case MathOperations.Degree:
                    return '^';
            }
            return '0';
        }
    }
}
    