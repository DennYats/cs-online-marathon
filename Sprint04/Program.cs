using Sprint04.Task_3;
using System;

namespace Sprint04
{
    class Program
    {
        static void Main(string[] args)
        {
            IDocument doc = new ColouredDocument { Pages = 10 };
            doc.AddPages(5);
            Console.WriteLine(doc.Pages);
        }
    }
}
