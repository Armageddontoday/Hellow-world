using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hellow_world
{
    class Program
    {
        static void FirstLines()
        {
            Console.WriteLine("Hellow, User!");
            Console.WriteLine("Type answer or \"Exit\" to exit");
            Console.WriteLine();
        } // Набор строк, которые висят в верхней части экрана
        static void ErrorLines()
        {
            Console.Clear();
            FirstLines();
            Console.WriteLine("Input rror!");
            Console.WriteLine("You have to enter number or \"Exit\" command");
            Console.WriteLine("Let's try another one:");
        } // Набор сообщений об ошибочном вводе
        static void SuccessLines() 
        {
            Console.WriteLine("Correct!");
            Console.WriteLine("Lets play again!");
        } //Набор строк о правильном ответе
        //Очищает экран, выводит первые строки
        //показывает выражение и введённый ответ, выдает сообщение об успехе
        static void CorrectAnswer(int x, int y, int z)
        {
            Console.Clear();
            FirstLines();            
            Console.WriteLine("{0} * {1} = {2}!", x, y, z);
            SuccessLines();
            Console.WriteLine();
        }
        //Аналогично, но выдаёт сообщение об ошибочном ответе
        static void WrongAnswer(int x, int y, int z)
        {
            Console.Clear();
            FirstLines();
            Console.WriteLine("{0} * {1} isn't = {2}!", x, y, z);
            Console.WriteLine("Your answer is incorrect!");
            Console.WriteLine("Try again:");
            Console.WriteLine();
        } //

        static void Main(string[] args)
        {
            int num1, num2, NumResult;
            string input;
            //
            Random RandNum = new Random();
            FirstLines();
            for (;;) //бесконечный цикл, программа завершится только в случае команды "выход"        
            {//при каждом прохождении цикла меняются исходные значения
                num1 = RandNum.Next(1, 10);
                num2 = RandNum.Next(1, 10);
                
                Console.Write("{0} * {1}= ", num1, num2);
                input = Console.ReadLine(); //
                    if (input == "exit" || input == "exit") //проверка на ввод команды "выход"
                     Environment.Exit(0); 
                try //попытка преобразовать введённую строку в целое число и, в случае успеха, проверить верен ли ответ
                {
                    NumResult = int.Parse(input);
                    if (NumResult == num1 * num2)//правильный ответ?
                    {
                        CorrectAnswer(num1,num2,NumResult);
                        //в случае успеха программа выводит об этом сообщение и начинается следующая итерация
                    }
                    else 
                    WrongAnswer(num1,num2,NumResult);
                    //если число преобразовано успешно, но ответ неверен- сообщение об этом и новая итерация
                }
                catch //при провале преобразования(введено некорректное число\ничего не введено\символы) сообщение об ошибке
                {
                    ErrorLines();
                }
                finally
                { }
            }
        }
    }
}
