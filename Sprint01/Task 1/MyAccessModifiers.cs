using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint01.Task_1
{
    class MyAccessModifiers
    {
        private int birthYear;
        protected string personalInfo;
        private protected string IdNumber;
        public MyAccessModifiers(int birthYear, string IdNumber, string personalInfo)
        {
            this.birthYear = birthYear;
            this.IdNumber = IdNumber;
            this.personalInfo = personalInfo;
        }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - birthYear;
            }
        }
        byte averageMiddleAge = 50;
        internal string Name { get; set; }
        public string NickName { get; internal set; }
        protected internal void HasLivedHalfOfLife() { }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            MyAccessModifiers mam = (MyAccessModifiers)obj;
            return (this.Age == mam.Age && this.Name == mam.Name && this.personalInfo == mam.personalInfo);
        }
        //Знайти як реалізувати метод GetHashCode
        public override int GetHashCode() => base.GetHashCode();

        public static bool operator == (MyAccessModifiers first, MyAccessModifiers second) =>
            first.Equals(second);

        public static bool operator != (MyAccessModifiers first, MyAccessModifiers second) =>
            !first.Equals(second);
    }
}
