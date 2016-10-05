using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    class MultiplicationTester
    {
        /// <summary>
        ///  попытка преобразовать введённую строку в целое число и, в случае успеха, проверить верен ли ответ
        ///  в случае неправильного ответа программа не будет менять исходные значения num1 и num2, предлагая ввести их верное произведение
        ///  но можно изменить их командой "next"
        /// </summary>
        /// <param name="input">введённая пользователем строка</param>
        private void AnswerCheck(int num1, int num2)
        {
            var uiHelper = new UIHelper();
            int numResult = 0;
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
                {numResult = int.Parse(userInput);}
              catch //при провале преобразования(введено некорректное число\ничего не введено\символы) сообщение об ошибке
                {
                 uiHelper.ShowErrorMessage(); //в случае неправильного ответа покаывается сообщение и запрашивается повторный ввод при тех же исходных num1 и num2
                 Console.Write("{0} * {1}= ", num1, num2);
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
                    Console.Write("{0} * {1}= ", num1, num2);//в случае неправильного ответа покаывается сообщение и запрашивается повторный ввод при тех же исходных num1 и num2
                }
            }

        }
        /// <summary>
        ///   показывает приветственное сообщеие и затем уходит в бесконечный цикл выполнения программы
        /// </summary>
        public void StartTest()
        {
            var uiHelper = new UIHelper();
            var randNum = new Random();
            uiHelper.ShowGreetingMessage();
            while (true) //бесконечный цикл, программа завершится только в случае команды "выход"        
            {//при каждом прохождении цикла меняются исходные значения
                int num1 = randNum.Next(1, 10);
                int num2 = randNum.Next(1, 10);
                Console.Write("{0} * {1}= ", num1, num2);
                AnswerCheck(num1, num2);
            }
        }
    }
}
