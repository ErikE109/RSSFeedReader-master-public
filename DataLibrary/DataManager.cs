using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.CodeDom;
using System.Diagnostics;
using System.Xml;

namespace DataLibrary
{
    class DataManager <T>
    {
        //Fields
        string path { get; set; }

        public DataManager (string path)
        {
            this.path = path;
        }

        public void SaveAllData(List<T> list)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter xmlWriter = XmlWriter.Create(path, settings))
                {

                    xmlSerializer.Serialize(xmlWriter, list);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<T> GetData()
        {
                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                    using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        var list = (List<T>)xmlSerializer.Deserialize(fileStream);
                        return list;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return new List<T>();
                }
            }
    }
}
