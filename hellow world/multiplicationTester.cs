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
            Task currentTask = null;            
            var status = RoundStatuses.Initial;

            while (true) 
            {
                if (status == RoundStatuses.Initial)
                    currentTask = PrepareNewTask(0,0);
                else
                    currentTask =  PrepareNewTask(currentTask.Operand1, currentTask.Operand2);                
                status = StartTestRound(currentTask, status);
                if (status == RoundStatuses.Next)
                    continue; //при "next"- новая итерация
                if (status == RoundStatuses.Exit)
                {
                    return 1;
                }               
            }           
        }        
        public enum RoundStatuses //
        {
            Initial,                        
            Next,
            CorrectAnswer,            
            IncorrectAnswer,
            InvalidInput,
            Exit
        }

        private RoundStatuses StartTestRound(Task task, RoundStatuses status)
        {
            var analyzer = new UserInputAnalyzer();
            string userInput = null;
            while (true)
            {
                uiHelper.ShowMessage(task, status, userInput);
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
                        status=RoundStatuses.IncorrectAnswer;                        
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


        private Task PrepareNewTask(int previousOperand1, int previousOperand2)
        {
            var rand = new Random();           
            int operand1 = rand.Next(1, 10);
            int operand2 = rand.Next(1, 10);
            return new Task(operand1, operand2, previousOperand1, previousOperand2);
        }
    }
}