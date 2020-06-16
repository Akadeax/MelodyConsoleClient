using System;
using System.Collections.Generic;
using System.Text;

namespace MelodyConsoleClient
{
    class ColorPrint
    {
        public static void WriteLineColored(string toPrint)
        {
            string[] segments = toPrint.Split('&');
            foreach(string segment in segments)
            {
                if(!char.IsDigit(segment[0]))
                {
                    Console.Write(segment);
                    continue;
                }
                
                if(!char.IsDigit(segment[1]))
                {
                    Console.ForegroundColor = (ConsoleColor)int.Parse(segment.Substring(0, 1));
                    Console.Write(segment.Substring(1, 1));
                    Console.ResetColor();
                    Console.Write(segment.Substring(2));
                    continue;
                }

                Console.ForegroundColor = (ConsoleColor)int.Parse(segment.Substring(0, 2));
                Console.Write(segment.Substring(2, 1));
                Console.ResetColor();
                Console.Write(segment.Substring(3));
                Console.ResetColor();

            }
            Console.WriteLine();
        }
    }
}
