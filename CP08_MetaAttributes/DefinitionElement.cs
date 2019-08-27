using System;

namespace CP08_MetaAttributes {

    class DefinitionElement {
        private const int BordersWidth = 2;
        private int currentLine;
        private readonly int titleWidth;
        private readonly int definitionWidth;

        public DefinitionElement(int topMargin) {
            this.currentLine = topMargin;

            int maxWidth = Console.WindowWidth - DefinitionElement.BordersWidth;
            this.titleWidth = maxWidth / 3;
            this.definitionWidth = maxWidth - this.titleWidth;
        }

        public void Draw(string title, params string[] arguments) {
            string definition = this.BuildDefinitionValue(arguments);
            string message = this.BuildFullRow(title, definition);

            ConsoleBasicDraw.DrawFlatText(message, this.currentLine,
                ConsoleColor.White, ConsoleColor.Black);

            this.currentLine++;
        }

        private string BuildFullRow(string title, string definition) {
            title = ConsoleBasicDraw.RepresentObjectAsString(title, titleWidth);
            string paddingFillString = this.BuildPaddingFillString(title, definition);

            return String.Concat(title, paddingFillString, definition);
        }

        private string BuildDefinitionValue(params string[] arguments) {
            string definition = String.Join(", ", arguments);

            return ConsoleBasicDraw.RepresentObjectAsString(definition, definitionWidth);
        }

        private string BuildPaddingFillString(string title, string definition) {
            int paddingWidth = this.titleWidth - title.Length;

            return new string(' ', paddingWidth);
        }
    }

}