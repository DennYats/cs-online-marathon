using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint01.Task_3
{
    public class Fraction
    {
        private readonly int numerator;
        private readonly int denominator;

        public Fraction(int numerator, int denominator)
        {
            if(denominator == 0)
            {
                throw new DivideByZeroException("Denominator can't be zero");
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }

        private static int getGreatestComminDivisior(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static int getLeastComminMultiple(int a, int b)
        {
            return a * b / getGreatestComminDivisior(a, b);
        }

        private int GreatestCommonDevisor(int value1, int value2)
        {
            if (value2 == 0)
                return value1;
            else
                return GreatestCommonDevisor(value2, value1 % value2);
        }


        private Fraction Simlify(int numerator, int denominator)
        {
            int gcdNumber = GreatestCommonDevisor(numerator, denominator);

            if (gcdNumber != 0)
            {
                numerator /= gcdNumber;
                denominator /= gcdNumber;
            }

            return new Fraction(numerator, denominator);
        }

        private Fraction GetReverse()
        {
            return new Fraction(this.denominator, this.numerator);
        }

        public static Fraction operator +(Fraction f) => f;

        public static Fraction operator -(Fraction f) => f;

        public static Fraction operator +(Fraction f1, Fraction f2) =>
            new Fraction(f1.numerator + f2.numerator, f1.denominator + f2.denominator);

        public static Fraction operator -(Fraction f1, Fraction f2) =>
            new Fraction(f1.numerator - f2.numerator, f1.denominator - f2.denominator);

        public static Fraction operator !(Fraction f) =>
            new Fraction(f.denominator, f.numerator);

        public static Fraction operator *(Fraction f1, Fraction f2) =>
            new Fraction(f1.numerator * f2.numerator, f1.denominator * f2.denominator);

        public static Fraction operator /(Fraction f1, Fraction f2) =>
            new Fraction(f1.numerator / f2.numerator, f1.denominator / f2.denominator);

        public override string ToString() =>
            denominator < 0 ?
                $"-{numerator} / {denominator * -1}" :
                $"{numerator} / {denominator}";

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Fraction f = (Fraction)obj;
            return (this.numerator == f.numerator && this.denominator == f.denominator);
        }

        public static bool operator ==(Fraction f1, Fraction f2) =>
            f1.Equals(f2);

        public static bool operator !=(Fraction f1, Fraction f2) =>
            !f1.Equals(f2);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
