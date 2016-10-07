using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{

    class MultiplicationTester
    {
        private UIHelper uiHelper = new UIHelper();

        /*   private int CheckAnswer(int num1,int num2)
           {

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
               }
               catch //при провале преобразования(введено некорректное число\ничего не введено\символы) сообщение об ошибке
               {
                   uiHelper.ShowErrorMessage(); //в случае неправильного ответа покаывается сообщение и запрашивается повторный ввод при тех же исходных num1 и num2
                   uiHelper.ShowCurrentTask(num1, num2);
                   numResult = CheckAnswer(num1, num2);
               }
               return numResult;

           } */
        // private int CheckAnswer(int num1, int num2)
        /// <summary>
        ///   показывает приветственное сообщеие и затем уходит в бесконечный цикл выполнения программы
        /// </summary>
        public void StartTest()
        {
            var randNum = new Random();
            int numResult = 0;
            uiHelper.ShowGreetingMessage();
            while (true) //бесконечный цикл, программа завершится только в случае команды "выход"        
            {//при каждом прохождении цикла меняются исходные значения

                int num1 = randNum.Next(1, 10);
                int num2 = randNum.Next(1, 10);
                uiHelper.ShowCurrentTask(num1, num2);
                while (true)
                {
                    string userInput = uiHelper.GetUserAnswer();
                    if (userInput == "exit" || userInput == "Exit") //проверка на ввод команды "выход"
                        Environment.Exit(0);
                    if (userInput == "next" || userInput == "Next")
                    {
                        Console.Clear();
                        uiHelper.ShowGreetingMessage();
                        break;
                    }
                    try
                    { numResult = int.Parse(userInput); }
                    catch //при провале преобразования(введено некорректное число\ничего не введено\символы) сообщение об ошибке
                    {
                        uiHelper.ShowErrorMessage(); //в случае неправильного ответа покаывается сообщение и запрашивается повторный ввод при тех же исходных num1 и num2
                        uiHelper.ShowCurrentTask(num1, num2);
                        continue;
                    }
                    if (numResult == num1 * num2)//правильный ответ?
                    {
                        uiHelper.ShowCorrectAnswer(num1, num2, numResult);
                        break;//при правильном ответе- сообщение и новые num1, num2
                    }
                    else
                    {
                        uiHelper.ShowWrongAnswer(num1, num2, numResult);
                        uiHelper.ShowCurrentTask(num1, num2);//в случае неправильного ответа покаывается сообщение и запрашивается повторный ввод при тех же исходных num1 и num2
                    }

                }
            }
        }


    }
}