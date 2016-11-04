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
       
        public int StartTest()
        {
            Task newTask;
            Task previousTask=null;
            var status = RoundStatuses.Initial;
            while (true) 
            {                     
                newTask =  PrepareNewTask();                
                status = StartTestRound(newTask, previousTask, status);
                if (status == RoundStatuses.Next)
                    continue; //при "next"- новая итерация
                if (status == RoundStatuses.Exit)
                {
                    return 1;
                }
                if (status==RoundStatuses.CorrectAnswer)
                {
                    previousTask = newTask;
                }
            }           
        }        
        public enum RoundStatuses //
        {
            Initial,                        
            Next,
            CorrectAnswer,            
            InCorrectAnswer,
            InvalidInput,
            Exit
        }

        private RoundStatuses StartTestRound(Task task, Task previousTask, RoundStatuses status)
        {
            var analyzer = new Analyzer();
            string userInput = "";
            while (true)
            {
                uiHelper.ShowMessage(task, previousTask, status, userInput);
                userInput = uiHelper.GetUserAnswer();//запрос ответа
                if (analyzer.IsExit(userInput))//проверка на команду выход
                {
                    return RoundStatuses.Exit;
                }
                if (analyzer.IsNext(userInput))//проверка на команду следующего варианта
                {
                    return RoundStatuses.Next;
                }
                if (analyzer.IsNumber(userInput))//проверка введено ли число
                {
                    if (analyzer.IsCorrectAnswer(task, userInput))//если да, то правильный ли ответ
                    {                        
                            return RoundStatuses.CorrectAnswer;
                        
                        //при правильном ответе нужны новые значение Task, поэтому  используется
                        //тот же механизм, что и при  команде Next, только в данном случае 
                        //выводится сообщение о успехе 
                    }
                    else
                    {
                        status=RoundStatuses.InCorrectAnswer;                        
                        continue;
                    }
                }
                else
                {
                    status = RoundStatuses.InvalidInput;
                    continue;
                }
                
            }       

        }
        
             
        private Task PrepareNewTask()
        {
            var rand = new Random();
            int num1 = rand.Next(1, 10);
            int num2 = rand.Next(1, 10);            
            return new Task(num1, num2);
        }
    }
}