using System;

namespace CP08_MetaAttributes.Frames {

    class TypeFrame : BaseFrame {
        private readonly Type type;

        public TypeFrame(Type type) {
            this.type = type;
            this.FrameTitle = String.Format("Type info: {0}", this.type.Name);
        }

        public override void DrawContent() {
            DefinitionElement definitionList = new DefinitionElement(1);
            definitionList.Draw("AssemblyQualifiedName", this.type.AssemblyQualifiedName);
            definitionList.Draw("FullName", this.type.FullName);
            definitionList.Draw("Namespace", this.type.Namespace);
            definitionList.Draw("Attributes", this.type.Attributes.ToString());
            var typeBaseType = this.type.BaseType;
            if (typeBaseType != null) {
                definitionList.Draw("BaseType", typeBaseType.Name);
            }
            definitionList.Draw("GUID", this.type.GUID.ToString());
            definitionList.Draw("HasElementType", this.type.HasElementType.ToString());
            definitionList.Draw("IsAbstract", this.type.IsAbstract.ToString());
            definitionList.Draw("IsAnsiClass", this.type.IsAnsiClass.ToString());
            definitionList.Draw("IsArray", this.type.IsArray.ToString());
            definitionList.Draw("IsAutoClass", this.type.IsAutoClass.ToString());
            definitionList.Draw("IsAutoLayout", this.type.IsAutoLayout.ToString());
            definitionList.Draw("IsByRef", this.type.IsByRef.ToString());
            definitionList.Draw("IsClass", this.type.IsClass.ToString());
            definitionList.Draw("IsCOMObject", this.type.IsCOMObject.ToString());
            definitionList.Draw("IsContextful", this.type.IsContextful.ToString());
            definitionList.Draw("IsEnum", this.type.IsEnum.ToString());
            definitionList.Draw("IsExplicitLayout", this.type.IsExplicitLayout.ToString());
            definitionList.Draw("IsGenericParameter", this.type.IsGenericParameter.ToString());
            definitionList.Draw("IsGenericTypeDefinition", this.type.IsGenericTypeDefinition.ToString());
            definitionList.Draw("IsImport", this.type.IsImport.ToString());
            definitionList.Draw("IsInterface", this.type.IsInterface.ToString());
            definitionList.Draw("IsLayoutSequential", this.type.IsLayoutSequential.ToString());
            definitionList.Draw("IsMarshalByRef", this.type.IsMarshalByRef.ToString());
            definitionList.Draw("IsNested", this.type.IsNested.ToString());
            definitionList.Draw("IsNestedAssembly", this.type.IsNestedAssembly.ToString());
            definitionList.Draw("IsNestedPrivate", this.type.IsNestedPrivate.ToString());
            definitionList.Draw("IsNestedPublic", this.type.IsNestedPublic.ToString());
            definitionList.Draw("IsNestedPublic", this.type.IsNestedPublic.ToString());
            definitionList.Draw("IsPointer", this.type.IsPointer.ToString());
            definitionList.Draw("IsPrimitive", this.type.IsPrimitive.ToString());
            definitionList.Draw("IsPublic", this.type.IsPublic.ToString());
            definitionList.Draw("IsSealed", this.type.IsSealed.ToString());
            definitionList.Draw("IsSerializable", this.type.IsSerializable.ToString());
            definitionList.Draw("IsUnicodeClass", this.type.IsUnicodeClass.ToString());
            definitionList.Draw("IsVisible", this.type.IsVisible.ToString());
            definitionList.Draw("MemberType", this.type.MemberType.ToString());
            definitionList.Draw("Module", this.type.Module.Name);
            definitionList.Draw("Namespace", this.type.Namespace);
            var typeReflectedType = this.type.ReflectedType;
            if (typeReflectedType != null) {
                definitionList.Draw("ReflectedType", typeReflectedType.Name);
            }
        }

        private void DrawListBox(string header, string[] values) {
            ConsoleBasicDraw.DrawFlatText(header, Console.CursorTop, ConsoleColor.DarkMagenta,
                ConsoleColor.White);
            ConsoleListBox listBox = new ConsoleListBox(values, Console.CursorTop + 1,
                ConsoleColor.White, ConsoleColor.DarkBlue);
            listBox.DrawElements();
        }

        public override bool Manager() {
            string[] constructors = MetaExplorer.GetConstructors(this.type);
            this.DrawListBox("Constructors", constructors);
            string[] fields = MetaExplorer.GetFields(this.type);
            this.DrawListBox("Fields", fields);
            string[] properties = MetaExplorer.GetProperties(this.type);
            this.DrawListBox("Properties", properties);
            string[] methods = MetaExplorer.GetMethods(this.type);
            this.DrawListBox("Methods", methods);
            string[] events = MetaExplorer.GetEvents(this.type);
            this.DrawListBox("Events", events);

            ConsoleBasicDraw.DrawFlatBox(Console.CursorTop, 2, ConsoleColor.White);
            ConsoleBasicDraw.DrawFlatText("Press any key to go back.", Console.CursorTop, ConsoleColor.Blue,
                ConsoleColor.White);

            Console.ReadKey();
            return false;
        }
    }

}