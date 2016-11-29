using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    public enum RoundStatuses //
    {
        Initial,
        Next,
        CorrectAnswer,
        IncorrectAnswer,
        InvalidInput,
        Exit
    }
    public enum MathOperations
    {
        Add,
        Substract,
        Multiplicate,
        Divide,
        Degree
    }

    class MultiplicationTester
    {
        //т.к. эти переменные постоянно используются в разных методах, вынес их в общий доступ для всего класса
        UIHelper uiHelper = new UIHelper();
       
        public int StartTest()
        {
            Task currentTask = null;            
            var status = RoundStatuses.Initial;
            while (true)
            {
                currentTask = PrepareNewTask(currentTask);
                status = StartTestRound(currentTask, status);
                if (status == RoundStatuses.Exit)
                {
                    return 1;
                }
            }                    
        }        
        

        private RoundStatuses StartTestRound(Task task, RoundStatuses status)
        {
            var userInputAnalyzer = new UserInputAnalyzer();
            string userInput = null;
            
            while (true)
            {                
                uiHelper.ShowMessage(task, status, userInput);
                userInput = uiHelper.GetUserAnswer();//запрос ответа
                if (userInputAnalyzer.IsExit(userInput))//проверка на команду выход
                {
                    return RoundStatuses.Exit;
                }
                if (userInputAnalyzer.IsNext(userInput))//проверка на команду следующего варианта
                {
                    return RoundStatuses.Next;
                }
                if (!userInputAnalyzer.IsNumber(userInput))//проверка введено ли число
                {
                    status = RoundStatuses.InvalidInput;
                    continue;
                }
                if (userInputAnalyzer.IsCorrectAnswer(task, userInput))//если да, то правильный ли ответ
                {
                    return RoundStatuses.CorrectAnswer;   
                }
                else
                {
                        status=RoundStatuses.IncorrectAnswer;                        
                        continue;
                }     
            }       

        }


        private Task PrepareNewTask(Task previousTask)
        {
            var random = new Random();
            int mathOperationNumber = random.Next(1, 6);
            switch(mathOperationNumber)
            {
                case 1:
                    return new Task(random.Next(1, 10), random.Next(1, 10), new Add(), previousTask);                     
                case 2:
                    return new Task(random.Next(1, 10), random.Next(1, 10), new Substract(), previousTask);
                case 3:
                    return new Task(random.Next(1, 10), random.Next(1, 10), new Divide(), previousTask);
                case 4:
                    return new Task(random.Next(1, 10), random.Next(1, 10), new Multiplicate(), previousTask);
                case 5:
                    return new Task(random.Next(1, 10), random.Next(1, 10), new Degree(), previousTask);
            }
            return null;
        }
    }
}