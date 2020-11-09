using System.Collections.Generic;

namespace Sprint03.Task_3
{
    class ListProgram
    {
        public static List<int> ListWithPositive(List<int> list) =>
            list.FindAll(e => e > 0 && e <= 10);
    }
}
