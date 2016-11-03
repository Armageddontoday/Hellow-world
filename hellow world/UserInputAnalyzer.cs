using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    class UserInputAnalyzer
    {
        public bool UserInputIsNext(string userInput)
        {
            if (userInput == "Next" || userInput == "next")
                return true;
            return false;
        }
        public bool UserInputIsExit(string userInput)
        {
            if (userInput == "Exit" || userInput == "exit")
                return true;
            return false;
        }
        public bool UserInputIsNumber(string userInput)
        {
            try
            {
                int.Parse(userInput);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UserInputIsCorrectAnswer(Task task, string userInput)
        {
            if (int.Parse(userInput) == task.op1 * task.op2)
                return true;
            return false;
        }
    }
}
