using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApp1
{
    public static class JsonAccess
    {
        public static void JsonEntitiesLoad()
        {

            string json = File.ReadAllText("Board.txt");
            Root.Entities = JsonConvert.DeserializeObject<List<Entity>>(json);
        }

        public static void JsonEntitiesSave(List<Entity> entities)
        {
            string json = JsonConvert.SerializeObject(entities);
            File.WriteAllText("Board.txt", json);
        }
    }
}
