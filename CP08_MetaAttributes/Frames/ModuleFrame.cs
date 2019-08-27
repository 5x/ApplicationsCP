using System;
using System.Reflection;

namespace CP08_MetaAttributes.Frames {

    class ModuleFrame : BaseFrame {
        private readonly Module module;

        public ModuleFrame(Module module) {
            this.module = module;
            this.FrameTitle = String.Format("Module Info: {0}", this.module.Name);
        }

        public override void DrawContent() {
            DefinitionElement definitionList = new DefinitionElement(1);
            definitionList.Draw("Name", this.module.Name);
            definitionList.Draw("FullyQualifiedName", this.module.FullyQualifiedName);
            definitionList.Draw("ScopeName", this.module.ScopeName);
            definitionList.Draw("ModuleVersionId", this.module.ModuleVersionId.ToString());
            definitionList.Draw("MetadataToken", this.module.MetadataToken.ToString());
            definitionList.Draw("MDStreamVersion", this.module.MDStreamVersion.ToString());
            definitionList.Draw("HashCode", this.module.GetHashCode().ToString());
            definitionList.Draw("IsResource", this.module.IsResource().ToString());
        }

        public override bool Manager() {
            ConsoleBasicDraw.DrawFlatText("Types", Console.CursorTop, ConsoleColor.DarkMagenta,
                ConsoleColor.White);

            string[] types = MetaExplorer.GetTypes(this.module);
            var listBox = ConsoleListBox.FirstBreakItemFactory(
                types, Console.CursorTop + 1,
                ConsoleColor.White, ConsoleColor.DarkBlue);

            listBox.MakeUserChoose();
            if (listBox.SelectedIndex > 0) {
                this.RunNext(listBox.SelectedIndex - 1);
                return true;
            }

            return false;
        }

        private void RunNext(int index) {
            Type[] typesInfo = this.module.GetTypes();
            if (index >= typesInfo.Length) {
                return;
            }

            Type type = typesInfo[index];
            if (type == null) {
                return;
            }

            BaseFrame childFrame = new TypeFrame(type);
            childFrame.Run();
        }
    }

}