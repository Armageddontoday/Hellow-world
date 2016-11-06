using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    public class Task
    {
        public int Operand1 { get; private set; }
        public int Operand2 { get; private set; }
        public int PreviousOperand1 { get; private set; }
        public int PreviousOperand2 { get; private set; }       
        public Task(int operand1, int operand2,int previousOperand1, int previousOperand2)
        {
            PreviousOperand1 = previousOperand1;
            PreviousOperand2 = previousOperand2;
            Operand1 = operand1;
            Operand2 = operand2;                       
        }       
    }
}
