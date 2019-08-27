using System;
using System.IO;
using System.Reflection;

namespace CP08_MetaAttributes.Frames {

    class MainFrame : BaseFrame {
        public static string GetCurrentAssemblyInfo() {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            AssemblyName currentAssemblyName = currentAssembly.GetName();
            string applicationName = currentAssemblyName.Name;
            string applicationVersion = currentAssemblyName.Version.ToString();
            string applicationAuthor = "Serhii Zarutskiy";
            return String.Format("{0} (v{1}) by {2}", applicationName, applicationVersion,
                applicationAuthor);
        }

        public override void DrawContent() {
            ConsoleBasicDraw.DrawFlatText(MainFrame.GetCurrentAssemblyInfo(), 0, ConsoleColor.White, ConsoleColor.Black);
            string helpText = "Yeaaaaah.";
            ConsoleBasicDraw.DrawFlatText(helpText, 1, ConsoleColor.White, ConsoleColor.Black);
        }

        public override bool Manager() {
            ConsoleBasicDraw.DrawFlatText("Write path to DLL/EXE: ", Console.CursorTop, ConsoleColor.DarkGray,
                ConsoleColor.Black);

            string path = null;
            while (String.IsNullOrEmpty(path) || !File.Exists(path)) {
                path = Console.ReadLine();

                if (!File.Exists(path)) {
                    ConsoleBasicDraw.DrawFlatText("File not found, try again: ", Console.CursorTop, ConsoleColor.DarkGray,
                        ConsoleColor.DarkGray);
                }
            }
            
            Assembly assembly = Assembly.LoadFrom(path);
            if (assembly != null) {
                BaseFrame childFrame = new AssemblyFrame(assembly);
                childFrame.Run();
            }

            return true;
        }
    }

}