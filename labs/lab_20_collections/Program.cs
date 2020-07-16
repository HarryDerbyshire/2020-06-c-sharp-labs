using System;
using System.Collections.Generic;

namespace lab_20_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "We are SPARTA!";

            input = input.Trim().ToLower();

            var CountD = new Dictionary<char, int>();

            foreach (var c in input)
            {
                if (CountD.ContainsKey(c))
                {
                    CountD[c]++;
                }
                else
                {
                    CountD.Add(c, 1);
                }
            }

            foreach (var entry in CountD) Console.WriteLine(entry);
        }
    }
}
