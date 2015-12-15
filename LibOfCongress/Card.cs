using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Xml.Linq;

namespace LibOfCongress
{
    [Serializable]
    public class Card : ISerializable
    {
        [Serializable]
        public class StringList : List<string>
        {
            public override string ToString()
            {
                return String.Join(", ", this);
            }

            public StringList() : base() { }

            public StringList(string[] strings) : base(strings) { }
        }

        public string Title { get; set; }
        public string Publisher { get; set; }
        public int WhenPublished;
        public bool Circulation { get; set; }
        public List<string> Author { get; set; }
        public List<string> Subject { get; set; }
        public LoCnum CatNum { get; set; }

        public string SubjectList { get { return Subject.ToString(); } }

        public Card() : this("", new List<string>(), new LoCnum(0), new List<string>(), "", 0, false) { }

        public Card(string Title, List<string> Author, LoCnum CatNum, List<string> Subject, string Publisher, int WhenPublished, bool Circulation)
        {
            this.Title = Title;
            this.Author = Author;
            this.CatNum = CatNum;
            this.Subject = Subject;
            this.Publisher = Publisher;
            this.WhenPublished = WhenPublished;
            this.Circulation = Circulation;
        }
     
        public int Published
        {
            get { return WhenPublished; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                WhenPublished = value;
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", Title);
            info.AddValue("Author", Author);
            info.AddValue("CatNum", CatNum);
            info.AddValue("Subject", Subject);
            info.AddValue("Publisher", Publisher);
            info.AddValue("WhenPublished", WhenPublished);
            info.AddValue("Circulation", Circulation);
        }

        public Card(SerializationInfo info, StreamingContext context) : this(
            Title: (string)info.GetValue("Title", typeof(string)),
            Author: (StringList)info.GetValue("Author", typeof(StringList)),
            CatNum: (LoCnum)info.GetValue("CatalogNumber", typeof(LoCnum)),
            Subject: (StringList)info.GetValue("Subject", typeof(StringList)),
            Publisher: (string)info.GetValue("Publisher", typeof(string)),
            WhenPublished: (int)info.GetValue("WhenPublished", typeof(int)),
            Circulation: (bool)info.GetValue("Circulation", typeof(bool)))
        { }
    }
}
