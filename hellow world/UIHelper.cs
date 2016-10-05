using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    class UIHelper
    {
        /// <summary>
        /// Набор строк, которые висят в верхней части экрана
        /// </summary>
        public void ShowGreetingMessage()
        {
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
            Console.WriteLine("Input rror!");
            Console.WriteLine("You have to enter number or use \"Exit\" / \"Next\" command.");
            Console.WriteLine("Let's try again:");
        }
        /// <summary>
        /// Набор строк о правильном ответе. Очищает экран, выводит первые строки. 
        /// Показывает выражение и введённый ответ, выдает сообщение об успехе.
        /// </summary>
        public void ShowCorrectAnswer(int x, int y, int z)
        {
            Console.Clear();
            ShowGreetingMessage();
            Console.WriteLine("{0} * {1} = {2}!", x, y, z);
            Console.WriteLine("Correct!");
            Console.WriteLine("Lets play another one!");
            Console.WriteLine();
        }
        /// <summary>
        /// Аналогично ShowCorrectAnswer, но выдаёт сообщение об ошибочном ответе
        /// </summary>
        public void ShowWrongAnswer(int x, int y, int z)
        {
            Console.Clear();
            ShowGreetingMessage();
            Console.WriteLine("{0} * {1} isn't = {2}!", x, y, z);
            Console.WriteLine("Your answer is incorrect!");
            Console.WriteLine("Try again:");
            Console.WriteLine();
        }
        /// <summary>
        /// запрос на ввод пользователем ответа, ответ в формате строки проверяется 
        /// </summary>
        public string GetUserAnswer()
        {return Console.ReadLine();}
    }
}
