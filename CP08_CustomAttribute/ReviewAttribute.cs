using System;


namespace CP08_CustomAttribute {

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ReviewAttribute : Attribute {
        public ReviewAttribute(string commit, string review) {
            this.Commit = commit;
            this.Review = review;
        }

        public ReviewAttribute(string commit, string author, string review)
            : this(commit, review) {
            this.Author = author;
        }

        public object Issues { get; set; }

        public int Revision { get; set; }

        public string Review { get; }

        public string Author { get; }

        public string Commit { get; set; }

        public virtual string FullReviewLink { get; set; }
    }

}