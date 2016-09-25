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
            int num1;
            int num2; 
            string userInput;
            UIHelper uiHelper = new UIHelper();
            MultiplicationCheck multCheck = new MultiplicationCheck();          
            Random RandNum = new Random();
            uiHelper.ShowGreetingMessage();
            while(0==0) //бесконечный цикл, программа завершится только в случае команды "выход"        
            {//при каждом прохождении цикла меняются исходные значения
                num1 = RandNum.Next(1, 10);
                num2 = RandNum.Next(1, 10);
                Console.Write("{0} * {1}= ", num1, num2);
                userInput = uiHelper.GetUserAnswer();
                multCheck.AnswerCheck(userInput, num1, num2);
            }
        }
    }
}
