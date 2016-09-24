using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HellowWorld
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int num1, num2, NumResult;
            string input;
            ScreenLines ScrLines = new ScreenLines();             
            Random RandNum = new Random();
            ScrLines.FirstLines();
            while(0==0) //бесконечный цикл, программа завершится только в случае команды "выход"        
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
                        ScrLines.CorrectAnswer(num1,num2,NumResult);
                        //в случае успеха программа выводит об этом сообщение и начинается следующая итерация
                    }
                    else
                        ScrLines.WrongAnswer(num1,num2,NumResult);
                    //если число преобразовано успешно, но ответ неверен- сообщение об этом и новая итерация
                }
                catch //при провале преобразования(введено некорректное число\ничего не введено\символы) сообщение об ошибке
                {
                    ScrLines.ErrorLines();
                }
                finally
                { }
            }
        }
    }
}
