using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace BilisselBeceriler.Utility
{
    public class Serializer
    {
        public static string Serialize<T>(T Nesne)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer xs = new XmlSerializer(typeof(T));
            XmlWriterSettings ayar = new XmlWriterSettings();
            ayar.Encoding = new UTF8Encoding();
            ayar.Indent = false;
            ayar.CheckCharacters = false;
            ayar.OmitXmlDeclaration = true;
            StringBuilder sb = new StringBuilder();
            XmlWriter x = XmlWriter.Create(sb, ayar);
            xs.Serialize(x, Nesne, ns);
            return sb.ToString();
        }
        public static T Deserialize<T>(string Xml)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StringReader oku = new StringReader(Xml))
            {
                using (XmlTextReader xtr = new XmlTextReader(oku))
                {
                    return (T)xs.Deserialize(xtr);
                }
            }
        }        
    }
}
