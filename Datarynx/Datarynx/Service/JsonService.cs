using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Datarynx.Service
{
    public class JsonService<T>
    {
        public static string ReadFile(string jsonFile)
        {
            var content = string.Empty;
            try
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(jsonFile);
                using (var reader = new StreamReader(stream))
                {
                    content = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return content;
        }

        public static T GetDeserializedData(string jsonFile)
        {
            var content = ReadFile(jsonFile);
            T jsonDeserialized = JsonConvert.DeserializeObject<T>(content);
            return jsonDeserialized;
        }
    }
}
