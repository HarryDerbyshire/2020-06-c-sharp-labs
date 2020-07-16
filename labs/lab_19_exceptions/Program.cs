using System;
using System.IO;


namespace lab_19_exceptions
{
    public class Program
    {

        public static string[] _theBeatles = new string[] { "John", "Paul", "George", "Ringo" };

        
        static void Main(string[] args)
        {
            // AddBeatle(4, "Brian");
       

            try
            {
                File.OpenRead("myFile.txt");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Cannot find the file myFile.txt");
            }
            finally
            {
                Console.WriteLine("But life goes on..");
            }
        }

    }
    public class Beatles
    {
        public static void AddBeatle(int pos, string name)
        {
            try
            {
               Program._theBeatles[pos] = name;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error has occurred");
                throw new ArgumentException();
            }
            finally
            {
                Console.WriteLine("Here comes the sun!");
            }

        }
    }
}
