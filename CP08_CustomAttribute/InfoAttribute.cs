using System;

namespace CP08_CustomAttribute {

    [AttributeUsage(AttributeTargets.All)]
    public class InfoAttribute : Attribute {
        public InfoAttribute(string description) {
            this.Description = description;
        }

        public InfoAttribute(string description, string author, double version) {
            this.Description = description;
            this.Author = author;
            this.Version = version;
        }

        public string Description { get; }

        public string Author { get; }

        public double Version { get; set; }
    }

}