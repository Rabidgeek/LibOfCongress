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
    public class Library : List<Card>, ISerializable
    {
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Books", this.ToArray<Card>());
        }

        private Card[] _deSerialize;

        public Library(SerializationInfo info, StreamingContext context)
        {
            _deSerialize = (Card[])info.GetValue("Cards", typeof(Card[]));
        }

        [OnDeserialized]
        private void Cards(StreamingContext context)
        {
            foreach (Card card in _deSerialize)
            {
                this.Add(card);
            }
            _deSerialize = null;
        }

        public Library() : base() { }

        public Library SubjectSearch(string subject)
        {
            Library book = new Library();

            foreach (Card card in this)
            {
                foreach (string _subject in card.Subject)
                {
                    if (_subject.Equals(subject))
                    {
                        book.Add(card);
                    }
                }
            }
            return book;
        }

        public override string ToString()
        {
            string result = "Title\t\t\t\t\tAuthor\t\t\t\t\tLoCnum";

            foreach (Card card in this)
            {
                result += String.Format(Environment.NewLine + "{0}\t\t\t{1}\t\t{2}", card.Title, string.Join(", ", card.Author), card.CatNum);
            }

            return result;
        }
    }
}
