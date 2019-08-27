using System;

namespace CP08_MetaAttributes.Frames {

    abstract class BaseFrame {
        protected string FrameTitle { get; set; }

        protected BaseFrame() {
            ConsoleUtil.ApplyDefaultSetting();
        }


        ~BaseFrame() {
            ConsoleUtil.CleanConsole();
        }

        public void Run() {
            while (true) {
                ConsoleUtil.CleanConsole();
                this.DrawFrame();
                bool isFrameAlive = this.Manager();
                if (!isFrameAlive) {
                    return;
                }
            }
        }

        private void DrawFrame() {
            this.DrawHeader();
            this.DrawContent();
            this.DrawFooter();
        }

        private void DrawFooter() {
            int position = Console.CursorTop;
            int height = 2;
            ConsoleBasicDraw.DrawFlatBox(position, height, ConsoleColor.White);
        }

        private void DrawHeader() {
            int position = 0;
            ConsoleBasicDraw.DrawFlatText(this.FrameTitle, position,
                ConsoleColor.DarkMagenta, ConsoleColor.White);
        }

        public abstract void DrawContent();
        public abstract bool Manager();
    }

}