namespace Sprint03.Task_1
{
    delegate int CalcDelegate(int num1, int num2, char sign);

    public class CalcProgram
    {
        public static int Calc(int num1, int num2, char sign)
        {
            int res = 0;

            if (sign == char.Parse("+"))
                res = num1 + num2;
            if (sign == char.Parse("-"))
                res = num1 - num2;
            if (sign == char.Parse("*"))
                res = num1 * num2;
            if (sign == char.Parse("/"))
            {
                if (num2 != 0) res = num1 / num2;
                else res = 0;
            }
                
            return res;
        }

        static CalcDelegate funcCalc = Calc;
    }
}
