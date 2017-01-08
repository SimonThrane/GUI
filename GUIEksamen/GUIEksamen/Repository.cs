using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace GUIEksamen
{

    /// <summary>
    /// Klasse til at arbejde med filer i JSON og XML-format 
    /// </summary>
    public static class Repository
    {
        
            public static void ConvertToJsonFIle(List<DataClass> dataList, string filepath)
            {
                if (filepath == null) throw new ArgumentNullException(nameof(filepath));
                  
                //For at illustere point med Async  
                Thread.Sleep(3000);

                File.WriteAllText(path: filepath, contents: JsonConvert.SerializeObject(dataList));

            }

            internal static void SaveFileXml(string fileName, List<DataClass> jokes)
            {

                Thread.Sleep(3000);
                // Create an instance of the XmlSerializer class and specify the type of object to serialize.
                XmlSerializer serializer = new XmlSerializer(typeof(List<DataClass>));
                TextWriter writer = new StreamWriter(fileName);
                // Serialize all the agents.
                serializer.Serialize(writer, jokes);
                writer.Close();
            }

        public static bool ReadFromFile(string fileName, out List<DataClass> data)
        {
            TextReader reader = new StreamReader(fileName);

            if (reader.Read().ToString().IsJson())
            {
                return (ReadFileJson(fileName, out data));
            }
            else
            {
                return (ReadFileXml(fileName, out data));
            }
        }

            public static bool ReadFileXml(string fileName, out List<DataClass> jokes)
            {
                jokes = new List<DataClass>();
                // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
                XmlSerializer serializer = new XmlSerializer(typeof(List<DataClass>));

                TextReader reader = new StreamReader(fileName);

                jokes = (List<DataClass>)serializer.Deserialize(reader);
                reader.Close();

                return true;
            }

            public static bool ReadFileJson(string fileName, out List<DataClass> jokes)
            {
                jokes = new List<DataClass>();
                using (StreamReader file = File.OpenText(fileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    jokes = serializer.Deserialize(file, typeof(List<DataClass>)) as List<DataClass>;
                }

                return true;
            }

        public static bool IsJson(this string jsonData)
        {
            return jsonData.Trim().Substring(0, 1).IndexOfAny(new[] { '[', '{' }) == 0;
        }


    }
}

