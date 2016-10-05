using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    
    class MultiplicationTester
    {
        private int AnswerCheck(int num1,int num2)
        {
            
            var uiHelper = new UIHelper();
            string userInput = uiHelper.GetUserAnswer();
            int numResult = 0;
            if (userInput == "exit" || userInput == "Exit") //проверка на ввод команды "выход"
                Environment.Exit(0);
            if (userInput == "next" || userInput == "Next")
            {
                Console.Clear();
                StartTest();
             }
            try
            {
                numResult = int.Parse(userInput);
                return numResult;
            }
            catch //при провале преобразования(введено некорректное число\ничего не введено\символы) сообщение об ошибке
            {
                uiHelper.ShowErrorMessage(); //в случае неправильного ответа покаывается сообщение и запрашивается повторный ввод при тех же исходных num1 и num2
                Console.Write("{0} * {1}= ", num1, num2);
                numResult= AnswerCheck(num1, num2);
            }
            return numResult;

        } 
       
        /// <summary>
        ///   показывает приветственное сообщеие и затем уходит в бесконечный цикл выполнения программы
        /// </summary>
        public void StartTest()
        {
            var uiHelper = new UIHelper();
            var randNum = new Random();
            int numResult = 0;
            uiHelper.ShowGreetingMessage();
            while (true) //бесконечный цикл, программа завершится только в случае команды "выход"        
            {//при каждом прохождении цикла меняются исходные значения
                int num1 = randNum.Next(1, 10);
                int num2 = randNum.Next(1, 10);
                
                Console.Write("{0} * {1}= ", num1, num2);
                do
                {
                    numResult = AnswerCheck(num1, num2);
                    if (numResult != num1 * num2)
                    {
                        uiHelper.ShowWrongAnswer(num1, num2, numResult);
                        Console.Write("{0} * {1}= ", num1, num2);
                    }
                } while (numResult != num1 * num2);
                Console.Clear();
                uiHelper.ShowCorrectAnswer(num1, num2, numResult);

          }
        }
    }
}
