using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint01.Task_4
{
    public abstract class CloseableResource
    {
        public void Close()
        {
            Console.WriteLine("Closing Resource");
        }
    }
}
