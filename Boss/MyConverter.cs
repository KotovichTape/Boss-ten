using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Boss
{
    public class MyConverter
    {

        public static void MySerialize<T>(T objects, string filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + filename;

            string json = JsonConvert.SerializeObject(objects);

            File.WriteAllText(path, json);
        }

        public static T MyDeserialize<T>(string filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + filename;

            string json = File.ReadAllText(path);
            T objects = JsonConvert.DeserializeObject<T>(json);
            return objects;
        }

        public MyConverter()
        {
        }
    }
}
