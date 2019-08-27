using System;

namespace CP08_MetaAttributes {

    class ConsoleListBox {
        private int selectedIndex;
        private int topMargin;

        private string[] values;

        public ConsoleListBox(string[] values, int topMargin,
            ConsoleColor background, ConsoleColor foreground) {
            this.Values = values;
            this.TopMargin = topMargin;
            this.Background = background;
            this.Foreground = foreground;
            this.SelectedIndex = 0;
        }

        public string Selected {
            get { return this.Values[this.SelectedIndex]; }
        }

        public int SelectedIndex {
            get { return this.selectedIndex; }
            set {
                int prevSelectedIndex = this.selectedIndex;

                if (value < 0) {
                    value = this.MaxIndex - value - 1;
                }

                this.selectedIndex = value % (this.MaxIndex + 1);
                this.DrawSelectedElement(prevSelectedIndex);
            }
        }

        public int TopMargin {
            get { return this.topMargin; }
            private set {
                if (value < 0) {
                    throw new ArgumentException("Margin must be positive.");
                }

                this.topMargin = value;
            }
        }


        public string[] Values {
            get { return this.values; }
            private set {
                if (value == null || value.Length == 0) {
                    value = new string[1] {"..."};
                }

                this.values = value;
            }
        }

        public int MaxIndex {
            get { return this.Values.Length - 1; }
        }

        public ConsoleColor Foreground { get; private set; }

        public ConsoleColor Background { get; private set; }

        public static void Run(string[] values, string headerText) {
            ConsoleListBox listBox = new ConsoleListBox(values, 3,
                ConsoleColor.Black, ConsoleColor.Blue);
            listBox.MakeUserChoose();
            ConsoleUtil.CleanConsole();
            Console.WriteLine(listBox.Values[listBox.SelectedIndex]);
            Console.ReadKey();
        }

        public static ConsoleListBox FirstBreakItemFactory(string[] values,
            int topMargin, ConsoleColor background, ConsoleColor foreground) {
            string[] newValues = new string[values.Length + 1];
            newValues[0] = "...";
            Array.Copy(values, 0, newValues, 1, values.Length);
            return new ConsoleListBox(newValues, topMargin, background, foreground);
        }

        public void MakeUserChoose() {
            this.DrawElements();
            this.SelectedIndex = 0;
            this.WaiteForUserChoose();
        }

        public void DrawElements() {
            for (int index = 0; index < this.Values.Length; index++) {
                this.DrawElement(index);
            }
        }

        private void DrawElement(int index) {
            int lineNumber = index + this.TopMargin;
            string text = this.Values[index];

            ConsoleBasicDraw.DrawFlatText(text, lineNumber, this.Background,
                this.Foreground);
        }

        private void DrawSelectedElement(int prevIndex) {
            this.DrawElement(prevIndex);
            string text = this.Values[this.SelectedIndex];
            int lineNumber = this.SelectedIndex + this.TopMargin;

            ConsoleBasicDraw.DrawFlatText(text, lineNumber, this.Foreground,
                this.Background);
        }

        private void WaiteForUserChoose() {
            while (true) {
                ConsoleKey readKey = Console.ReadKey(true).Key;

                switch (readKey) {
                    case ConsoleKey.Enter:
                        return;
                    case ConsoleKey.UpArrow:
                        this.SelectedIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        this.SelectedIndex++;
                        break;
                }
            }
        }
    }

}