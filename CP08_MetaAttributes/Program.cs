using System;
using CP08_MetaAttributes.Frames;

namespace CP08_MetaAttributes {

    internal class Program {
        static void Main(string[] args) {
            Console.Title = MainFrame.GetCurrentAssemblyInfo();
            ConsoleUtil.CleanConsole();

            BaseFrame frame = new MainFrame();
            frame.Run();
        }
    }

}