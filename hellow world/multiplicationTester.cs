using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    public enum RoundStatuses 
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
        Power
    }

    class MultiplicationTester
    {
        UIHelper uiHelper = new UIHelper();       
        public int StartTest()
        {            
            var taskFactory = new TaskFactory();         
            var status = RoundStatuses.Initial;
            Task currentTask = null;     
            while (true)
            {               
                currentTask= taskFactory.PrepareNewTask(currentTask);
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
    }
}