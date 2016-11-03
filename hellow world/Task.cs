using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    public class Task
    {
        public int num1 { get; private set; }
        public int num2 { get; private set; }
        public Task(int oper1, int oper2)
        {
            num1 = oper1;
            num2 = oper2;
        }
    }
}
