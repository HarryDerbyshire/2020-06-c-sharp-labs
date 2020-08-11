//using Newtonsoft.Json.Linq;
//using System;
//using System.IO;

//namespace SerialisationApp
//{
//    class StreamWrite
//    {
//        static void Main(string[] args)
//        {
//            String path = @"LiveForever.txt";
            //Declare stream object. The stream is then used to write data from the application 		    		  //File.AppendText is used to open file in append mode
            //using (StreamWriter sr = File.AppendText(path))
            //{
            //    //We are using the stream write method, Writeline to to write “Live – Forever” to   		       //the stream . The line will then be written to the file
            //    sr.WriteLine("Live - Forever");
            //}

            //string[] lines = { "Text Line 1", "Line 2", "Line 3" };
            //File.WriteAllLines(path, lines);

            //using (StreamReader sr = File.OpenText(path))
            //{
            //    //The variable ‘s’ will be used to read all the data from the file
            //    String s = "";
            //    //We then use the stream reader method ReadLine to read each line from the stream buffer
            //    while ((s = sr.ReadLine()) != null)
            //    {
            //        //As a result, each line will be transferred from the file to the buffer, then the 			//string line will be transferred from the buffer to the variable ‘s’
            //        Console.WriteLine(s);
            //    }
            //}

//            string[] readLines = File.ReadAllLines(path);
//            foreach(var line in readLines)
//            {
//                Console.WriteLine(line);
//            }
//        }

//    }
//}

