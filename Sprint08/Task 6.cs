using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sprint08
{
    internal class PersonInTheShop
    {
    }
    class Buyer : PersonInTheShop
    {
        static Semaphore semaphore = new Semaphore(10, 10);
        Thread thread;
        int count = 10;
        public Buyer(string threadName)
        {
            thread = new Thread(Shopping);
            thread.Name = threadName;
            thread.Start();
        }

        private void Shopping()
        {
            semaphore.WaitOne();

            /*Enter();

            SelectGroceries();

            Pay();
            Leave();*/

            semaphore.Release();
        }
    }
}
