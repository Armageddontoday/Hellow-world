using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    class UIHelper
    {
        public void ShowMessage(Task task, Task previousTask, MultiplicationTester.RoundStatuses status, string userAnswer)
        {
            switch (status)
            {
                case MultiplicationTester.RoundStatuses.Initial:
                    ShowGreetingMessage();
                    ShowCurrentTask(task);
                    break;
                case MultiplicationTester.RoundStatuses.CorrectAnswer:                    
                    ShowNewCorrectAnswer(previousTask);
                    ShowCurrentTask(task);
                    break;
                case MultiplicationTester.RoundStatuses.InCorrectAnswer:
                    ShowGreetingMessage();
                    ShowWrongAnswer(task, int.Parse(userAnswer));
                    ShowCurrentTask(task);
                    break;
                case MultiplicationTester.RoundStatuses.Next:
                    ShowGreetingMessage();
                    ShowCurrentTask(task);
                    break;
                case MultiplicationTester.RoundStatuses.InvalidInput:
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
            Console.WriteLine("Type answer or \"Exit\" to exit.");
            Console.WriteLine("Type \"Next\" for another task.");
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
            Console.WriteLine("Let's try again:");
            Console.WriteLine();
        }
        /// <summary>
        /// Набор строк о правильном ответе. Очищает экран, выводит первые строки. 
        /// Показывает выражение и введённый ответ, выдает сообщение об успехе.
        /// </summary>
        public void ShowNewCorrectAnswer(Task task)
        {
            Console.Clear();
            ShowGreetingMessage();
            Console.WriteLine("{0} * {1} = {2}!", task.operand1, task.operand2, task.operand1 * task.operand2);
            Console.WriteLine("Correct!");
            Console.WriteLine("Lets play another one!");
            Console.WriteLine();
        }
        /// <summary>
        /// Аналогично ShowCorrectAnswer, но выдаёт сообщение об ошибочном ответе
        /// </summary>
        public void ShowWrongAnswer(Task task, int answer)
        {
            Console.Clear();
            ShowGreetingMessage();
            Console.WriteLine("{0} * {1} isn't = {2}!", task.operand1, task.operand2, answer);
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
            Console.Write("{0} * {1}= ", task.operand1, task.operand2);
        }
        public void ShowCorrectAnswer()
        {            
            Console.WriteLine("Correct!");
            Console.WriteLine("Lets play another one!");
            Console.WriteLine();
        }
    }
}
