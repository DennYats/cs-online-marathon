using System;

namespace Sprint01.Task_4
{
    public class DisposePatternImplementer : CloseableResource, IDisposable
    {
        public void Close()
        {
            Console.WriteLine("Closing resource");
        }
        private bool disposed = false;
        
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Disposing by developer");
                    Close();
                }
                else
                {
                    Console.WriteLine("Disposing by GC");
                    Close();
                }
                disposed = true;
            }
        }
        ~DisposePatternImplementer()
        {
            Dispose(false);
        }
    }

    /*private bool disposed = false;
    ~DisposePatternImplementer()
    {
        Console.WriteLine("Disposing by GC");
    }
    public void Dispose()
    {
        Dispose(true);
        Console.WriteLine("Disposing by developer");
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {

            }
            disposed = true;
        }
    }*/
}
