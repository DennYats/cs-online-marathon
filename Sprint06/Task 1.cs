using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint06
{
    public class CircleOfChildren
    {
        List<string> children { get; set; }
        public CircleOfChildren(IEnumerable<string> children)
        {
            this.children = children.ToList();
        }

        public IEnumerable GetChildrenInOrder(int syllables, int countOfChildren = 0)
        {
            int kidsToKick = children.Count();
            if (syllables <= 0)
            {
                yield break;
            }
            else if (countOfChildren != 0)
            {
                kidsToKick = countOfChildren < children.Count ? countOfChildren : children.Count;
            }
            /*for (int i = 0; i < kidsToKick; i++)
            {
                for(int j = 0; j < children.Count(); i++)
                {
                    if (i % syllables == 1)
                        yield return children.ElementAt(i).ToString();
                    if (i >= children.Count()) yield break;
                }
            }*/
            int index = 0;
            while(kidsToKick > 0)
            {
                index = (index + syllables - 1) % children.Count;

                yield return children.ElementAt(index);

                children.RemoveAt(index);
                kidsToKick--;
            }
        }
    }

    public class OutputUtils
    {
        public static void ExitOutput(CircleOfChildren circleOfChildren, int syllables, int countOfChildren = 0)
        {
            foreach(var kid in circleOfChildren.GetChildrenInOrder(syllables, countOfChildren))
            {
                Console.Write(kid + " ");
            }
        }
    }
}