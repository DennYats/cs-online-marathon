using System;

namespace Sprint01.Task_3
{
    public class Fraction
    {
        private readonly int numerator;
        private readonly int denominator;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero.");
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public static Fraction operator +(Fraction f) => f;

        public static Fraction operator -(Fraction f) =>
            Simplify(new Fraction(-f.numerator, f.denominator));

        public static Fraction operator +(Fraction f1, Fraction f2) =>
            Simplify(new Fraction(f1.numerator * f2.denominator + f2.numerator * f1.denominator, f1.denominator * f2.denominator));

        public static Fraction operator -(Fraction f1, Fraction f2) =>
            f1 + (-f2);

        public static Fraction operator !(Fraction f) =>
            new Fraction(f.denominator, f.numerator);

        public static Fraction operator *(Fraction f1, Fraction f2) =>
            Simplify(new Fraction(f1.numerator * f2.numerator, f1.denominator * f2.denominator));

        public static Fraction operator /(Fraction f1, Fraction f2) =>
            Simplify(new Fraction(f1.numerator * f2.denominator, f1.denominator * f2.numerator));

        public static bool operator ==(Fraction f1, Fraction f2) =>
            f1.Equals(f2);

        public static bool operator !=(Fraction f1, Fraction f2) =>
            !(f1.Equals(f2));

        public static int gcd(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return gcd(b, a % b);
        }

        public static Fraction Simplify(Fraction f)
        {
            int numerator = f.numerator;
            int denominator = f.denominator;
            int gcdNumber = gcd(numerator, denominator);

            if (gcdNumber != 0)
            {
                numerator /= gcdNumber;
                denominator /= gcdNumber;
            }

            if (denominator < 0)
            {
                numerator = numerator * -1;
                denominator = denominator * -1;
            }

            return new Fraction(numerator, denominator);
        }

        public override string ToString()
        {
            Fraction f = new Fraction(this.numerator, this.denominator);
            f = Simplify(f);
            return $"{f.numerator} / {f.denominator}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Fraction)) return false;

            Fraction f = (Fraction)obj;
            f = Simplify(f);
            return this.numerator == f.numerator && this.denominator == f.denominator;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
