using System;
using System.IO;

namespace Bloom
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Logs.LogError("InitialParameterNullDirectoryPath", true);
                Console.ReadLine();
                return;
            }

            switch (args[0].ToLower())
            {
                case "run":
                    if (args.Length > 1 && File.Exists(args[1]))
                    {
                        string file = File.ReadAllText(args[1]);
                        Console.WriteLine(file);
                    }
                    break;
                case "--help":
                    if (args.Length == 1)
                    {
                        Help.HelpMe();
                    }
                    else
                    {
                        Logs.LogError("InvalidInitialParameter", true);
                    }
                    break;
                default:
                    Logs.LogError("InvalidInitialParameter", true);
                    break;
            }
        }
    }
}
