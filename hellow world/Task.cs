using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    public class Task
    {
        public int operand1 { get; private set; }
        public int operand2 { get; private set; }
        public Task(int Operand1, int Operand2)
        {
            operand1 = Operand1;
            operand2 = Operand2;
        }
    }
}
