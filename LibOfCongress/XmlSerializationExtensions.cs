using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace LibOfCongress
{
        public static class XmlSerializationExtensions
        {
            public static readonly XmlSerializerNamespaces EmptyXmlSerializerNamespace = new XmlSerializerNamespaces(
                new XmlQualifiedName[] {
                new XmlQualifiedName("") });

            public static void WriteElementObject(this XmlWriter writer, string localName, object o)
            {
                writer.WriteStartElement(localName);
                XmlSerializer xs = new XmlSerializer(o.GetType());
                xs.Serialize(writer, o, EmptyXmlSerializerNamespace);
                writer.WriteEndElement();
            }

            public static T ReadElementObject<T>(this XmlReader reader)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                reader.ReadStartElement();
                T retval = (T)xs.Deserialize(reader);
                reader.ReadEndElement();
                return retval;
            }

        internal static void WriteElementObject(string fileName, Library lib)
        {
            throw new NotImplementedException();
        }
    }
}

