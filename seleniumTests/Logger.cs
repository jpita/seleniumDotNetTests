using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumTests
{
    public static class Logger
    {
        public static StringBuilder LogString = new StringBuilder();
        public static void Out(string str)
        {
            Console.WriteLine(str);
            LogString.Append(str).Append(Environment.NewLine);
        }
        public static void SaveToFile()
        {
            // WriteAllLines creates a file, writes a collection of strings to the file, 
            // and then closes the file.
            System.IO.File.WriteAllText(@"WriteLines.txt", LogString.ToString());
        }
    }
}
