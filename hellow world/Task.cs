using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    public class Task
    {
        public Task PreviousTask { get; private set; }
        public int Operand1 { get; private set; }
        public int Operand2 { get; private set; }
        public Task(int operand1, int operand2, Task previousTask)
        {           
            Operand1 = operand1;
            Operand2 = operand2;
            PreviousTask = previousTask;
        }       
    }
}
