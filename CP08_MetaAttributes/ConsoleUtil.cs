using System;

namespace CP08_MetaAttributes {

    class ConsoleUtil {
        public static void ApplyDefaultSetting() {
            Console.TreatControlCAsInput = false;
            Console.CancelKeyPress += new ConsoleCancelEventHandler(BreakHandler);

            Console.Clear();
            Console.CursorVisible = false;
            ConsoleUtil.CleanConsole();
        }

        public static void SetColors(ConsoleColor background, ConsoleColor foreground) {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }

        public static void CleanConsole() {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        private static void BreakHandler(object sender, ConsoleCancelEventArgs args) {
            // exit gracefully if Control-C or Control-Break pressed 
            Console.CursorVisible = true;
            CleanConsole();
        }
    }

}