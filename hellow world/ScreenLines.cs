using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    class ScreenLines
    {
        public void FirstLines()
        {
            Console.WriteLine("Hellow, User!");
            Console.WriteLine("Type answer or \"Exit\" to exit");
            Console.WriteLine();
        } // Набор строк, которые висят в верхней части экрана
        public void ErrorLines()
        {
            Console.Clear();
            FirstLines();
            Console.WriteLine("Input rror!");
            Console.WriteLine("You have to enter number or \"Exit\" command");
            Console.WriteLine("Let's try another one:");
        } // Набор сообщений об ошибочном вводе
        public void SuccessLines()
        {
            Console.WriteLine("Correct!");
            Console.WriteLine("Lets play again!");
        } //Набор строк о правильном ответе
        //Очищает экран, выводит первые строки
        //показывает выражение и введённый ответ, выдает сообщение об успехе
        public void CorrectAnswer(int x, int y, int z)
        {
            Console.Clear();
            FirstLines();
            Console.WriteLine("{0} * {1} = {2}!", x, y, z);
            SuccessLines();
            Console.WriteLine();
        }
        //Аналогично, но выдаёт сообщение об ошибочном ответе
        public void WrongAnswer(int x, int y, int z)
        {
            Console.Clear();
            FirstLines();
            Console.WriteLine("{0} * {1} isn't = {2}!", x, y, z);
            Console.WriteLine("Your answer is incorrect!");
            Console.WriteLine("Try again:");
            Console.WriteLine();
        } 

    }
}
