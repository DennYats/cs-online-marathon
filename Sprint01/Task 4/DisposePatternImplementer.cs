using System;

namespace Sprint01.Task_4
{
    public class DisposePatternImplementer : CloseableResource, IDisposable
    {
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
}
