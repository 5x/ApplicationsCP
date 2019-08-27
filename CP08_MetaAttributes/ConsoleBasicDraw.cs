using System;

namespace CP08_MetaAttributes {

    class ConsoleBasicDraw {
        public static void DrawFlatBox(int topMargin, int height, ConsoleColor background) {
            int lastRow = height + topMargin + 1;
            for (int row = topMargin + 1; row < lastRow; row++) {
                ConsoleBasicDraw.FillRow(row, background);
            }
        }

        public static void FillRow(int row, ConsoleColor background) {
            string fillLine = new string(' ', Console.WindowWidth);

            ConsoleUtil.SetColors(background, background);
            Console.SetCursorPosition(0, row);
            Console.Write(fillLine);
        }

        public static void DrawFlatText(string message, int topMargin,
            ConsoleColor background, ConsoleColor foreground) {
            ConsoleBasicDraw.FillRow(topMargin, background);
            message = ConsoleBasicDraw.RepresentObjectAsString(message, Console.WindowWidth);
            ConsoleBasicDraw.DrawText(message, 1, topMargin, background, foreground);
        }

        public static void DrawText(string message, int left, int top,
            ConsoleColor background, ConsoleColor foreground) {
            ConsoleUtil.SetColors(background, foreground);
            Console.SetCursorPosition(left, top);
            Console.Write(message);
        }

        public static string RepresentObjectAsString(object obj, int maxLength) {
            string value = obj?.ToString();
            if (String.IsNullOrEmpty(value)) {
                return String.Empty;
            }

            if (value.Length > maxLength) {
                return String.Concat(value.Substring(0, maxLength - 3), "...");
            }

            return value;
        }
    }

}