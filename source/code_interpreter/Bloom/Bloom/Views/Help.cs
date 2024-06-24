using Bloom.Resources;
using System.Globalization;

namespace Bloom.Views
{
    public class Help
    {
        public static void HelpMe()
        {
            Logs.LogWithColor(ConsoleColor.Magenta, "Bloom help-me\n");

            string Message = AppSettings.GetHelpMessage();

            Console.WriteLine(Message);
        }
    }
}
