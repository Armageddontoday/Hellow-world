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
                currentTask =  PrepareNewTask(currentTask);                
                status = StartTestRound(currentTask,  status);
                if (status == RoundStatuses.Next)
                    continue; //при "next"- новая итерация
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
                        
                        //при правильном ответе нужны новые значение Task, поэтому  используется
                        //тот же механизм, что и при  команде Next, только в данном случае 
                        //выводится сообщение о успехе 
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
            var rand = new Random();           
            int operand1 = rand.Next(1, 10);
            int operand2 = rand.Next(1, 10);
            return new Task(operand1, operand2, RandomMathOperation(), previousTask);
        }
        private MathOperations RandomMathOperation()
        {
            var rand = new Random();
            int mathOperationNumber = rand.Next(1, 6);
            switch(mathOperationNumber)
            {
                case 1:
                    return MathOperations.Add;                    
                case 2:
                    return MathOperations.Substract;                    
                case 3:
                    return MathOperations.Multiplicate;
                case 4:
                    return MathOperations.Divide;
                case 5:
                    return MathOperations.Degree;
            }
            return 0;
        }
    }
}