using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Markup;
using System.Xml;

namespace BilisselBeceriler.BelgeEditor.Library.Types
{
    public class Common
    {
        public static Grid KopyaHavuz { get; set; }
        /// <summary>
        /// Serialize olabilen tipler icin
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static T DeepClone<T>(T from)
        {
            using (MemoryStream s = new MemoryStream())
            {
                BinaryFormatter f = new BinaryFormatter();
                f.Serialize(s, from);
                s.Position = 0;
                object clone = f.Deserialize(s);

                return (T)clone;
            }
        }

        public static Object CloneUsingXaml(Object o)
        {
            string xaml = XamlWriter.Save(o);
            return XamlReader.Load(new XmlTextReader(new StringReader(xaml)));
        }
    }
}
