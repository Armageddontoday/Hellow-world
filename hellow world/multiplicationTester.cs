using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{

    class MultiplicationTester
    {
        //т.к. эти переменные постоянно используются в разных методах, вынес их в общий доступ для всего класса
        private UIHelper uiHelper = new UIHelper();
        private int num1;
        private int num2;
        private int numResult;
        private Random randNum = new Random();
        private string userInput;
        /// <summary>
        ///   показывает приветственное сообщеие и затем уходит в бесконечный цикл выполнения программы         
        /// </summary>
        public void StartTest()
        {
            
            uiHelper.ShowGreetingMessage();
            RandomizeCurrentNums();
            uiHelper.ShowCurrentTask(num1, num2);
            while (true) //бесконечный цикл, программа завершится только в случае команды "выход"        
            {//при каждом полном прохождении цикла меняются исходные значения
                GetUserInput();
                numResult = int.Parse(userInput);
                CheckAnswer();
            }
        }
        
        /// <summary>
        /// проверка введённой пользователем строки на соответствие командам
        /// </summary>
        /// <param name="userInput"></param>
        private void CheckCommand()
        {
            if (userInput == "exit" || userInput == "Exit") //проверка на ввод команды "выход"
                Environment.Exit(0);
            if (userInput == "next" || userInput == "Next")
            {               
                uiHelper.ShowGreetingMessage();
                StartTest();                
            }            
        }
        /// <summary>
        /// проверка возможности преобразования 
        /// </summary>
        private bool StringToIntConvertionPossibility(string userInput)
        {
                 
            {
                try
                {
                    int.Parse(userInput);
                    return true;
                }
                catch //при провале преобразования(введено некорректное число\ничего не введено\символы) сообщение об ошибке
                {
                    return false;
                }
            }
           
        }
        /// <summary>
        /// проверка ответа на правильность 
        /// </summary>
        private void CheckAnswer()
        {
            if (numResult == num1 * num2)
            {
                uiHelper.ShowGreetingMessage();
                uiHelper.ShowCorrectAnswer(num1, num2, numResult);
                RandomizeCurrentNums();
                uiHelper.ShowCurrentTask(num1, num2);
            }
            else
            {
                uiHelper.ShowWrongAnswer(num1, num2, numResult);
                uiHelper.ShowCurrentTask(num1, num2);
            }
        }
        /// <summary>
        /// метод рандомизирующий значение исходных данных
        /// </summary>
        private void RandomizeCurrentNums()
        {
            num1 = randNum.Next(1, 10);
            num2 = randNum.Next(1, 10);
        }
        /// <summary>
        /// цикл, в ходе которого вводится ответ пользователя в формате строки, идёт проверка на команды и возможность его преобразования в число
        /// </summary>
        private void GetUserInput()
        {
            while (true) 
            {
                userInput = uiHelper.GetUserAnswer();//запрос ответа
                CheckCommand();//проверка на возможный ввод команд и их последующее выполнение
                if (StringToIntConvertionPossibility(userInput) == false) //проверка на возможность преобразования строки в число, при невозможности- сообщение об ошибке и повторный запрос
                {
                    uiHelper.ShowGreetingMessage();
                    uiHelper.ShowErrorMessage();
                    uiHelper.ShowCurrentTask(num1, num2);
                    continue;
                }
                else //в случае возможного корректного преобразования - выход из цикла запросов и проверка ответа на правильность
                {
                    break;
                   
                }
            }
        }

    }
}