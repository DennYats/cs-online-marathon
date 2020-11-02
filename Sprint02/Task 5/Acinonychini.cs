using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint02.Task_5
{
    class Acinonychini
    {
        bool isThatCat;
        bool hasTwoEyes;

        public Acinonychini(bool isThatCat, bool hasTwoEyes)
        {
            this.isThatCat = isThatCat;
            this.hasTwoEyes = hasTwoEyes;
        }
    }

    sealed class Acinonyx : Acinonychini
    {
        public Acinonyx(bool isThatCat, bool hasTwoEyes) : base(isThatCat, hasTwoEyes) { }
    }

    class Puma : Acinonychini
    {
        public Puma(bool isThatCat, bool hasTwoEyes) : base(isThatCat, hasTwoEyes) { }
    }
}
