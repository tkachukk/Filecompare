using System;
using System.IO;

namespace filecompare
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Please provide exactly two file paths.");
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"File does not exist: {args[0]}");
                return;
            }

            if (!File.Exists(args[1]))
            {
                Console.WriteLine($"File does not exist: {args[1]}");
                return;
            }

            string[] lines1 = File.ReadAllLines(args[0]);
            string[] lines2 = File.ReadAllLines(args[1]);

            int minLength = Math.Min(lines1.Length, lines2.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (lines1[i] != lines2[i])
                {
                    Console.WriteLine("Files are different.");
                    Console.WriteLine($"First difference at line {i + 1}:");
                    Console.WriteLine($"File1: {lines1[i]}");
                    Console.WriteLine($"File2: {lines2[i]}");
                    return;
                }
            }

            if (lines1.Length != lines2.Length)
            {
                Console.WriteLine("Files are different.");
                Console.WriteLine("Files have different number of lines.");
                return;
            }

            Console.WriteLine("Files are identical.");
        }
    }
}