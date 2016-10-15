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
        UIHelper uiHelper = new UIHelper();
        /// <summary>
        ///   показывает приветственное сообщеие и затем уходит в бесконечный цикл выполнения программы         
        /// </summary>
        public int StartTest()
        {
            int num1;
            int num2;
            int numResult = 0;
            NewTesterIteration(out num1, out num2);

            while (true) //бесконечный цикл, программа завершится только в случае команды "выход"     
                         //при каждом полном прохождении цикла меняются исходные значения        
            {
                string userInput = GetUserInput(num1, num2);
                //если я правильно понял, то использования меток и goto крайне не приветствуются, поэтому команды "next" и "exit" "всплывают" из метода проверки команд(CheckCommand) через (GetUserInput)
                //в основной метод, а дальше уже проверяются, сделал так потому что не придумал как можно корректно завершить основной метод и вызываемых без goto и Enviroment.Exit
                if (userInput== "exitCommand")//проверка на возможный ввод команд и их последующее выполнение                                                    
                    return 0; //при команде "exit" завершение метода StartTest
                if (userInput == "nextCommand")//при "Next"- новая итерация
                {
                    NewTesterIteration(out num1, out num2);
                    continue; 
                }
                //т.к. проверка на команды и возможность на преобразование введённой строки в число уже проверялась, здесь в ней нет  небходимости
                numResult = int.Parse(userInput);
                CheckAnswer(numResult, num1, num2, out num1, out num2);
                }
            return 0;
        }
        
        /// <summary>
        /// проверка введённой пользователем строки на соответствие командам
        /// если в строке содержится команда, то функция вернёт положительное знаячение, иначе-0
       
        /// </summary>
        /// <param name="userInput"></param>
        private string CheckCommand(string userInput)
        {
            switch (userInput)
            {
                case "next":
                    return "nextCommand";
                case "Next":
                    return "nextCommand";
                case "exit":
                    return "exitCommand";
                case "Exit":
                    return "exitCommand";
                default:
                    return userInput;
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
        private void CheckAnswer(int numResult, int x, int y, out int  num1, out int num2)
        {
            num1 = x;//копирование текущих входных параметров в выходные
            num2 = y;//в слчае правильгого ответа эти параметры перед передачей из метода рандомизируются, если ответ неправильный- то их значения сохраняются
            if (numResult == x * y)
            {                
                uiHelper.ShowGreetingMessage();
                uiHelper.ShowCorrectAnswer(x, y, numResult);
                RandomizeCurrentNums(out num1, out num2);
                uiHelper.ShowCurrentTask(num1, num2);
            }
            else
            {
                uiHelper.ShowWrongAnswer(x, y, numResult);
                uiHelper.ShowCurrentTask(x, y);
            }
        }
        /// <summary>
        /// метод рандомизирующий значение исходных данных
        /// </summary>
        private void RandomizeCurrentNums(out int num1, out int num2)
        {
            Random randNum = new Random();
            num1 = randNum.Next(1, 10);
            num2 = randNum.Next(1, 10);
        }
        /// <summary>
        /// цикл, в ходе которого вводится ответ пользователя в формате строки, идёт проверка на команды и возможность его преобразования в число
        /// </summary>
        private string GetUserInput(int num1, int num2)
        {
            string userInput;
            while (true)
            {
                userInput = uiHelper.GetUserAnswer();
                if (CheckCommand(userInput) == "nextCommand")
                    return "nextCommand"; //т.к. в программе пока всего две команды, обе из которых не подразумевают сохранение текущего введённого значения,  GetUserInput возвращает значение этих комнд
                //в переменную userInput основного метода  
                if (CheckCommand(userInput) == "exitCommand")
                    return "exitCommand"; 
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
            return userInput;
        }
        /// <summary>
        /// набор действий, которые нужны для запуска нового теста, т.к. очитска экрана, вывод приветственного сообщения, рандомизация условий
        /// </summary>
        private void NewTesterIteration(out int num1, out int num2)
        {
            RandomizeCurrentNums(out num1, out num2);
            uiHelper.ShowGreetingMessage();
            uiHelper.ShowCurrentTask(num1, num2);
        }

    }
}