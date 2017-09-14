using System;

namespace Multinerd.Windows.Console
{
    public class ConsoleHelpers
    {
        public static void PrintProgramName(string asciiText)
        {
            if (string.IsNullOrWhiteSpace(asciiText)) return;
            var stArray = asciiText.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var stars = new string('*', stArray[0].Length);
            CenterInConsole(stars);
            foreach (var s in stArray)
            {
                CenterInConsole(s);
            }
            CenterInConsole(stars);
        }


        public static void CenterInConsole(string text)
        {
            System.Console.WriteLine();
            var count = (System.Console.WindowWidth - text.Length) / 2;
            if (count < 0) count = 0;
            System.Console.Write(new string(' ', count));
            System.Console.WriteLine(text);
        }
    }
}
