using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Threading;
using System.Reflection;
using System.Xml;

namespace Finisar
{
    /// <summary>
    /// 
    ///  Temporarily copied from OSA.NET here to make the code Keithley7002.cs (adpated from Keithley7001.cs) compilable with mnimum modifications.
    ///  SearialzerExtensions.cs is brought in to minimize the code changes.
    /// 
    /// </summary>
    public static class SerializerExtensions
    {
        public static SpinLock spinlock = new SpinLock();
        public static Dictionary<Type, Dictionary<String, XmlSerializer>> serializers_ = new Dictionary<Type, Dictionary<string, XmlSerializer>>();
        private static XmlReaderSettings readerSettings_;
        public static XmlReaderSettings ReaderSettings
        {
            get
            {
                if (readerSettings_ == null)
                    readerSettings_ = new XmlReaderSettings
                    {
                        IgnoreComments = true,
                        IgnoreProcessingInstructions = true,
                        IgnoreWhitespace = true,
                    };
                return readerSettings_;
            }
        }
        public static XmlWriterSettings writerSettings_;
        private static XmlWriterSettings WriterSettings
        {
            get
            {
                writerSettings_ = new XmlWriterSettings{ OmitXmlDeclaration = true};
                return writerSettings_;
            }
        }
        public static XmlSerializer XmlSerializer(this Type type, String rootName)
        {
            bool gotlock = false;
            try
            {
                spinlock.Enter(ref gotlock);
                if (!serializers_.ContainsKey(type))
                {
                    serializers_.Add(type, new Dictionary<string, XmlSerializer>());
                }


                if (!serializers_[type].ContainsKey(rootName))
                {
                    Type[] extratypes = new Type[0];
                    serializers_[type].Add(rootName, new XmlSerializer(type, null, extratypes, new XmlRootAttribute
                    {
                        ElementName = rootName,
                        Namespace = null
                    }, null, null));
                }
            }
            finally
            {
                if (gotlock)
                    spinlock.Exit();
            }

            return serializers_[type][rootName];

        }
       
        public static XmlReader ReadSubTreeSafely(this XmlReader reader, Action<XmlReader> readAction)
        {
            using (var safereader = reader.ReadSubtree())
            {
                safereader.Read();
                readAction(safereader);
            }
            if (reader.NodeType == XmlNodeType.EndElement) //not all elements have endelements
                reader.Read();
            return reader;
        }

        public static TResult ReadSubTreeFuncSafely<TResult>(this XmlReader reader, Func<XmlReader, TResult> readFunc)
        {
            TResult res = default(TResult);
            bool wasEmpty = reader.IsEmptyElement;
            using (var safereader = reader.ReadSubtree())
            {
                safereader.Read();
                res = readFunc(safereader);
            }
            if (wasEmpty || (reader.NodeType == XmlNodeType.EndElement))
            {
                reader.Read();
            }
            return res;
        }

        public static XmlWriter XmlSerialize<T>(this T obj, XmlWriter writer, String rootName)
        {
            if ((obj is IXmlSerializable) && !obj.GetType().IsGenericType)
            { // not sure generic types can be serialized like this
                writer.WriteStartElement(rootName);
                ((IXmlSerializable)obj).WriteXml(writer);
                writer.WriteEndElement();
                return writer;
            }
            else
                obj.XmlSerializer(rootName).Serialize(writer, obj);
            return writer;
        }

        public static XElement XmlSerializeToXElement<T>(this T obj, String rootName)
        {
            var x = new XDocument();
            using (var w = x.CreateWriter())
            {
                obj.XmlSerializer(rootName).Serialize(w, obj);
            }

            return x.Root;
        }
       
        public static XmlSerializer XmlSerializer<T>(this T obj, String rootName)
        {
            return obj.GetType().XmlSerializer(rootName);
        }

        public static XElement XmlWriterSerialize<T>(this T obj,XmlWriter writer,string rootName)
        {
            var x = new XDocument();
            Type type = obj.GetType();
            XmlSerializer xmlSerializer = type.XmlSerializer(rootName);
            if (writer == null)
            {
                using (var w = x.CreateWriter())
                {
                    xmlSerializer.Serialize(w, obj); //finally call the System.Xml.Serialization.XmlSerializer.Serialize()
                }
            }
            else
            {
                xmlSerializer.Serialize(writer, obj);
            }
            return x.Root;
        }

        public static object XmlReaderDeserialize(this XmlReader reader, Type type, String rootName)
        {
            if (type.GetInterface("IXmlSerializable", false) != null && !type.IsGenericType)
            {
                object o = Activator.CreateInstance(type);
                if (reader.ReadState == ReadState.Initial)
                {
                    reader.Read();
                }
                ((IXmlSerializable)o).ReadXml(reader);
                return o;
            }
            else
            {
                XmlSerializer xmlSerializer = type.XmlSerializer(rootName);
                return xmlSerializer.Deserialize(reader);
            }
        }
    }
}
