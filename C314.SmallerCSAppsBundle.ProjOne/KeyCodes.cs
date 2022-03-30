namespace C314.SmallerCSAppsBundle.ProjOne
{
    public class KeyCodes
    {
        public static void KeyCodesMain()
        {
            Console.TreatControlCAsInput = true;
            Console.Title = "Input Viewer";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
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

            Console.ResetColor();
        }
    }
}
