﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    class UserInputAnalyzer
    {
        public bool IsNext(string userInput)
        {
            if (userInput == "Next" || userInput == "next")
                return true;
            return false;
        }
        public bool IsExit(string userInput)
        {
            if (userInput == "Exit" || userInput == "exit")
                return true;
            return false;
        }
        public bool IsNumber(string userInput)
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
        public bool IsCorrectAnswer(Task task, string userInput)
        {
            if (int.Parse(userInput) == task.Operand1 * task.Operand2)
                return true;
            return false;
        }
    }
}
