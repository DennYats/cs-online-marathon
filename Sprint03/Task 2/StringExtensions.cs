using System;

namespace Sprint03.Task_2
{
    public static class StringExtensions
    {
        public static int WordCount(this string text) =>
            text.Split(new char[] { ' ', '.', '?', '!', '-', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
