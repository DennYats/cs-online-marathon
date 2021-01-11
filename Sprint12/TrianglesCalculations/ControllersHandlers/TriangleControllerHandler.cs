using System;
using System.Collections.Generic;
using System.Linq;
using TrianglesCalculations.Models;
using System.Threading.Tasks;
using TrianglesCalculations.Extensions;

namespace TrianglesCalculations.ControllersHandlers
{  
    public static class TriangleControllerHandler
    {
        public static double epsilon = 0.001;
        public static bool IsValid(Triangle t) =>
            (t.side1 + t.side2 <= t.side3 ||
             t.side1 + t.side3 <= t.side2 ||
             t.side2 + t.side3 <= t.side1)
            ? false
            : true;

        //1
        public static string InfoHandler(Triangle t) =>
            IsValid(t)
            ?   $"------------------------------------------------------------\n" +
                $"Triangle:\n" +
                    $"({t.side1}, {t.side2}, {t.side3})\n" +
                $"Reduced:\n" +
                    $"({t.side1 / PerimeterHandler(t):N2}, " +
                    $"{t.side2 / PerimeterHandler(t):N2}, " +
                    $"{t.side3 / PerimeterHandler(t):N2})\n\n" +
                $"Area = {AreaHandler(t)}\n" +
                $"Perimeter = {PerimeterHandler(t)} \n" +
                $"------------------------------------------------------------"
            : throw new Exception("This triangle cannot exist");

        //2
        public static double PerimeterHandler(Triangle t) =>
            IsValid(t)
            ? t.side1 + t.side2 + t.side3
            : throw new Exception("This triangle cannot exist");

        //3
        public static double AreaHandler(Triangle t)
        {
            if(!IsValid(t))
                throw new Exception("This triangle cannot exist");

            double p = PerimeterHandler(t) / 2;
            return Math.Round(Math.Sqrt(p * (p - t.side1) * (p - t.side2) * (p - t.side3)));
        }

        //4
        public static bool IsRightAngledHandler(Triangle t)
        {
            if(!IsValid(t))
                throw new Exception("This triangle cannot exist");

            List<double> sides = new List<double>() { t.side1, t.side2, t.side3 };
            sides.Sort();
            return Math.Pow(sides[2], 2).EqualInPercentTo(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2), epsilon);
        }

        //5
        public static bool IsEquilateralHandler(Triangle t) =>
            IsValid(t)
            ? t.side1.EqualInPercentTo(t.side2, epsilon) && t.side2.EqualInPercentTo(t.side3, epsilon)
            : throw new Exception("This triangle cannot exist");

        //6
        public static bool IsIsoscelesHandler(Triangle t) =>
            IsValid(t)
            ? (t.side1.EqualInPercentTo(t.side2, epsilon) && !t.side3.EqualInPercentTo(t.side2, epsilon))||
            (t.side2.EqualInPercentTo(t.side3, epsilon) && !t.side1.EqualInPercentTo(t.side2, epsilon)) ||
            (t.side1.EqualInPercentTo(t.side3, epsilon) && !t.side2.EqualInPercentTo(t.side1, epsilon))
            : throw new Exception("This triangle cannot exist");

        //7
        public static bool AreCongruentHandler((Triangle, Triangle) triangles)
        {
            if(!IsValid(triangles.Item1) || !IsValid(triangles.Item2))
                throw new Exception("Some of this triangles cannot exist");
            else
            {
                List<double> firstTrSides = new List<double> { triangles.Item1.side1, triangles.Item1.side2, triangles.Item1.side3 };
                List<double> secondTrSides = new List<double> { triangles.Item2.side1, triangles.Item2.side2, triangles.Item2.side3 };

                firstTrSides.Sort();
                secondTrSides.Sort();

                for (int i = 0; i < firstTrSides.Count(); i++)
                    if (!firstTrSides[i].EqualInPercentTo(secondTrSides[i], epsilon)) return false;               

                return true ;
            }
        }

        //8
        public static bool AreSimilarHandler((Triangle, Triangle) triangles)
        {
            if (!IsValid(triangles.Item1) || !IsValid(triangles.Item2))
                throw new Exception("Some of this triangles cannot exist");
            else
            {
                List<double> firstTrSides = new List<double> { triangles.Item1.side1, triangles.Item1.side2, triangles.Item1.side3 };
                List<double> secondTrSides = new List<double> { triangles.Item2.side1, triangles.Item2.side2, triangles.Item2.side3 };

                firstTrSides.Sort();
                secondTrSides.Sort();

                bool IsSimilar = (firstTrSides[0] / secondTrSides[0]).EqualInPercentTo(firstTrSides[1] / secondTrSides[1], epsilon) &&
                                (firstTrSides[1] / secondTrSides[1]).EqualInPercentTo(firstTrSides[2] / secondTrSides[2], epsilon) &&
                                (firstTrSides[2] / secondTrSides[2]).EqualInPercentTo(firstTrSides[0] / secondTrSides[0], epsilon);

                return IsSimilar;
            }
        }

        //9
        public static string GreatestByPerimeterHandler(Triangle[] tr) =>
            InfoHandler(tr.OrderByDescending(t => PerimeterHandler(t)).First());

        //10
        public static string GreatestByAreaHandler(Triangle[] tr) =>
            InfoHandler(tr.OrderByDescending(t => AreaHandler(t)).First());

        //11
        public static string PairwiseNonSimilarHandler(Triangle[] tr)
        {
            string res = "";
            for (int i = 0; i < tr.Length - 1; i++)
                for(int j = i + 1; j < tr.Length; j++)
                    if (!AreSimilarHandler((tr[i], tr[j])))
                        res += $"PAIRWISE NON SIMILAR\n" +
                                $"{InfoHandler(tr[i])}\n" +
                                $"{InfoHandler(tr[j])}\n\n\n";

            return res;
        }
    }
}