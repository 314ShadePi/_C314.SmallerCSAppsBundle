using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C314.SmallerCSAppsBundle.ProjOne
{
    public class KeyCodes
    {
        public static int KeyCodesMain()
        {
            Console.TreatControlCAsInput = true;
            Console.Title = "Input Viewer";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Welcome to Key Codes.\nWhen you press a key the program will output the keycode in this format: \"<key you pressed> -> <keycode>\".\nPress \"Escape\" to exit.");
            ConsoleKeyInfo consoleKeyInfo;

            do
            {
                consoleKeyInfo = Console.ReadKey();
                Console.Write(" -> ");
                if ((consoleKeyInfo.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTRL+");
                if ((consoleKeyInfo.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
                if ((consoleKeyInfo.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
                Console.WriteLine(consoleKeyInfo.Key.ToString());
            } while (consoleKeyInfo.Key != ConsoleKey.Escape);

            return 0;
        }
    }
}
