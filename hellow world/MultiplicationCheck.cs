using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    class MultiplicationCheck
    {
        /// <summary>
        ///  попытка преобразовать введённую строку в целое число и, в случае успеха, проверить верен ли ответ
        /// </summary>
        /// <param name="input">введённая пользователем строка</param>
        public void AnswerCheck(string userInput, int num1, int num2)
        {
            if (userInput == "exit" || userInput == "Exit") //проверка на ввод команды "выход"
                Environment.Exit(0);

            UIHelper uiHelper = new UIHelper();
            try 
            {
                int numResult = int.Parse(userInput);
                if (numResult == num1 * num2)//правильный ответ?
                    uiHelper.ShowCorrectAnswer(num1, num2, numResult);
                else
                    uiHelper.ShowWrongAnswer(num1, num2, numResult);

            }
            catch //при провале преобразования(введено некорректное число\ничего не введено\символы) сообщение об ошибке
            {
                uiHelper.ShowErrorMessage();
            }
            finally
            { }

            
        }
        /// <summary>
        ///   показывает приветственное сообщеие и затем уходит в бесконечный цикл выполнения программы
        /// </summary>
        public void CyclePart()
        {
            var uiHelper = new UIHelper();
            var randNum = new Random();
            uiHelper.ShowGreetingMessage();
            while (true) //бесконечный цикл, программа завершится только в случае команды "выход"        
            {//при каждом прохождении цикла меняются исходные значения
                int num1 = randNum.Next(1, 10);
                int num2 = randNum.Next(1, 10);
                Console.Write("{0} * {1}= ", num1, num2);
                string userInput = uiHelper.GetUserAnswer();
                AnswerCheck(userInput, num1, num2);
            }
        }
    }
}
