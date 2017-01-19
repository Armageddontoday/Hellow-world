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
        private UIHelper _uiHelper;
        private RoundStatuses _status;         
        private UserInputAnalyzer _userInputAnalyzer;
        public MultiplicationTester()
        {
            _uiHelper = new UIHelper();
            _taskFactory = new TaskFactory();
            _status = RoundStatuses.Initial;            
        }

        public int StartTest()
        {
            Task  _currentTask = null; ;
            while (true)
            {
                _currentTask = _taskFactory.CreateNewTask(_currentTask);
                _status = StartTestRound(_currentTask, _status);
                if (_status == RoundStatuses.Exit)
                {
                    return 1;
                }
            }                    
        }
       
        private RoundStatuses StartTestRound(Task task, RoundStatuses status)
        {
            string _userInput = null;
            _userInputAnalyzer = new UserInputAnalyzer(); 
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