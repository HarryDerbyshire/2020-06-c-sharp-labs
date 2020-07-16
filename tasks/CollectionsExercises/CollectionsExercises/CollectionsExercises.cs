using System.Collections.Generic;
using System.Linq;

namespace CollectionsExercisesLib
{
    public class CollectionsExercises
    {
        /* removes and returns the next num entries in the queue, as a comma separated string */
        public static string NextInQueue(int num, Queue<string> queue)
        {
            string output = "";
            if (num > 0) output += queue.Dequeue();
            for (int i = 1; i < num; i ++)
            {
                if (queue.Count == 0) break;
                output += ", ";
                output += queue.Dequeue();
            }
            return output;
        }

        /* uses a Stack to create and return array of ints in reverse order to the one supplied */
        public static int[] Reverse(int[] original)
        {
            return null;
        }
        // using a Dictionary, counts and returns (as a string) the occurence of the digits 0-9 in the given string
        public static string CountDigits(string input)
        {
            return "Not implemented";
        }
    }
}