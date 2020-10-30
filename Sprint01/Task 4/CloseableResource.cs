using System;

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
