using System;
using System.Reflection;

namespace CP08_MetaAttributes.Frames {

    class AssemblyFrame : BaseFrame {
        private readonly Assembly assembly;

        public AssemblyFrame(Assembly assembly) {
            this.assembly = assembly;
            this.FrameTitle = String.Format("Assembly Info: {0}", assembly.GetName().Name);
        }

        public override void DrawContent() {
            DefinitionElement definitionList = new DefinitionElement(1);
            var assemblyName = assembly.GetName();

            definitionList.Draw("FullName", assembly.FullName);

            if (assemblyName.Name != null) {
                definitionList.Draw("Name", assemblyName.Name);
            }

            if (assemblyName.CodeBase != null) {
                definitionList.Draw("CodeBase", assemblyName.CodeBase);
            }

            if (assemblyName.CultureInfo != null) {
                definitionList.Draw("CultureInfo", assemblyName.CultureInfo.DisplayName);
            }

            definitionList.Draw("Flags", assemblyName.Flags.ToString());
            definitionList.Draw("HashAlgorithm", assemblyName.HashAlgorithm.ToString());
            definitionList.Draw("ProcessorArchitecture", assemblyName.ProcessorArchitecture.ToString());
            definitionList.Draw("Version", assemblyName.Version.ToString());
            definitionList.Draw("VersionCompatibility", assemblyName.VersionCompatibility.ToString());
            definitionList.Draw("Location", assembly.Location);
            definitionList.Draw("CodeBase", assembly.CodeBase);
            definitionList.Draw("ImageRuntimeVersion", assembly.ImageRuntimeVersion);

            if (assembly.EntryPoint != null) {
                definitionList.Draw("EntryPoint Name", assembly.EntryPoint.Name);
            }

            definitionList.Draw("Is GAC?", assembly.GlobalAssemblyCache.ToString());
        }

        public override bool Manager() {
            ConsoleBasicDraw.DrawFlatText("Modules:", Console.CursorTop, ConsoleColor.DarkMagenta,
                ConsoleColor.White);

            string[] modules = MetaExplorer.GetModules(this.assembly);
            var listBox = ConsoleListBox.FirstBreakItemFactory(
                modules, Console.CursorTop + 1,
                ConsoleColor.White, ConsoleColor.DarkBlue);

            listBox.MakeUserChoose();
            if (listBox.SelectedIndex != 0) {
                Module module = assembly.GetModule(listBox.Selected);
                BaseFrame childFrame = new ModuleFrame(module);
                childFrame.Run();
                return true;
            }

            return false;
        }
    }

}