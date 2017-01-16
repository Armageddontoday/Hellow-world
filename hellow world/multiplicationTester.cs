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
        private TaskFactory _taskFactory;
        private UIHelper _uiHelper = new UIHelper();
        private RoundStatuses _status;
        private Task _currentTask;
        private  UserInputAnalyzer _userInputAnalyzer;
        private string _userInput;

        public MultiplicationTester()
        {
            _taskFactory = new TaskFactory();
            _status = RoundStatuses.Initial;
            _currentTask = null;
        }

        public int StartTest()
        {            
            
            while (true)
            {
                _currentTask = _taskFactory.PrepareNewTask(_currentTask);
                _status = StartTestRound(_currentTask, _status);
                if (_status == RoundStatuses.Exit)
                {
                    return 1;
                }
            }                    
        }
       
        private RoundStatuses StartTestRound(Task task, RoundStatuses status)
        {
            _userInputAnalyzer = new UserInputAnalyzer();
            _userInput = null;
            
            while (true)
            {
                _uiHelper.ShowMessage(task, status, _userInput);
                _userInput = _uiHelper.GetUserAnswer();//запрос ответа
                if (_userInputAnalyzer.IsExit(_userInput))//проверка на команду выход
                {
                    return RoundStatuses.Exit;
                }
                if (_userInputAnalyzer.IsNext(_userInput))//проверка на команду следующего варианта
                {
                    return RoundStatuses.Next;
                }
                if (!_userInputAnalyzer.IsNumber(_userInput))//проверка введено ли число
                {
                    status = RoundStatuses.InvalidInput;
                    continue;
                }
                if (_userInputAnalyzer.IsCorrectAnswer(task, _userInput))//если да, то правильный ли ответ
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