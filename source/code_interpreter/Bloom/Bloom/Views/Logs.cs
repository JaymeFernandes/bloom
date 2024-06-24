using Bloom.Resources;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bloom.Views
{
    public static class Logs
    {
        public static void LogLoading(int totalProcesses, int currentPosition)
        {
            Console.SetCursorPosition(0, Console.CursorTop);

            int positionPercentage = (40 * currentPosition) / totalProcesses;
            int percentage = (positionPercentage * 100) / 40;

            string loadingBar = $"[{new string('|', positionPercentage)}{new string(' ', 40 - positionPercentage)}]";

            LogWithColor(ConsoleColor.Green, loadingBar);
            if (percentage == 100)
            {
                Console.WriteLine($" {percentage}%  ({currentPosition} / {totalProcesses})");
            }
            else
            {
                Console.Write($" {percentage}% ({currentPosition} / {totalProcesses})");
            }


        }

        public static void LogError(string errorType, bool fatalErro)
        {
            string erroMessage = AppSettings.GetErrorMessage(errorType);

            LogError(errorType, erroMessage, fatalErro);
        }

        public static void LogError(string errorType, string errorMessage, bool fatalErro)
        {
            LogWithColor(ConsoleColor.Red, "[Error]: ");
            Console.Write($"{errorType} ");
            LogWithColor(ConsoleColor.Green, "[Message]: ");
            Console.WriteLine($"\"{errorMessage}\"");

            if (fatalErro)
            {
                LogWithColor(ConsoleColor.Red, "\n\nA fatal error occurred. The application will now exit.\n");
                LogWithColor(ConsoleColor.Green, "[Code Error]: ");
                Console.WriteLine(errorType);
                Environment.Exit(0);
            }
        }

        public static void LogWithColor(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.Write($"{message}");
            Console.ResetColor();
        }
    }
}
