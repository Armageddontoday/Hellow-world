using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    public class Task
    {
        public int op1 { get; private set; }
        public int op2 { get; private set; }
        public Task(int oper1, int oper2)
        {
            op1 = oper1;
            op2 = oper2;
        }
    }
}
