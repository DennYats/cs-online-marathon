using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace Sprint08
{
    class ParallelUtils<T, TR>
    {
        public TR Result { get; set; }

        private T op1;
        private T op2;
        private Func<T, T, TR> func;

        public ParallelUtils(Func<T, T, TR> func, T operand1, T operand2)
        {
            this.func = func;
            this.op1 = operand1;
            this.op2 = operand2;
        }

        public void StartEvaluation()
        {
            Thread thread = new Thread(Evaluate);
            thread.Start();
        }
        public void Evaluate() =>
            Result = func(op1, op2);
    }
}