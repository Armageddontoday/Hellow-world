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
            var status = RoundStatuses.initial;
            while (true) 
            {                     
                var newTask =  PrepareNewTask();                
                status = StartTestRound(newTask, status);
                if (status == RoundStatuses.next)
                    continue; //при "next"- новая итерация
                if (status == RoundStatuses.exit)
                {
                    return 1;
                }
                if (status == RoundStatuses.correctAnswer)
                {
                    uiHelper.ShowCorrectAnswer(newTask);                    
                    continue;
                }
            }           
        }        
        private enum RoundStatuses //
        {
            initial,                        
            next,
            correctAnswer,
            exit
        }

        private RoundStatuses StartTestRound(Task task, RoundStatuses status)
        {
            var userInputAnalyzer = new UserInputAnalyzer();                       
            if (status !=RoundStatuses.correctAnswer)
            {
                
                uiHelper.ShowGreetingMessage();
                uiHelper.ShowCurrentTask(task);
            }
            else
                uiHelper.ShowCurrentTask(task);
            while (true)
            {    
                string userInput = uiHelper.GetUserAnswer();//запрос ответа
                if (userInputAnalyzer.UserInputIsExit(userInput))//проверка на команду выход
                {
                    return RoundStatuses.exit;
                }
                if (userInputAnalyzer.UserInputIsNext(userInput))//проверка на команду следующего варианта
                {
                    return RoundStatuses.next;
                }
                if (userInputAnalyzer.UserInputIsNumber(userInput))//проверка введено ли число
                {
                    if (userInputAnalyzer.UserInputIsCorrectAnswer(task, userInput))//если да, то правильный ли ответ
                    {                         
                        return RoundStatuses.correctAnswer;
                        //при правильном ответе нужны новые значение Task, поэтому  используется
                        //тот же механизм, что и при  команде Next, только в данном случае 
                        //выводится сообщение о успехе 
                    }
                    else
                    {
                        uiHelper.ShowWrongAnswer(task, int.Parse(userInput));
                        continue;
                    }
                }
                else
                {
                    uiHelper.ShowErrorMessage();
                    uiHelper.ShowCurrentTask(task);
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