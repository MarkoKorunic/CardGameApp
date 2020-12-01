using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Root
    {
        static Root()
        {
            JsonAccess.JsonEntitiesLoad();
        }
        public static List<Entity> Entities { get; set; }
        public static List<Entity> LiveEntities
        {
            get
            {
                return Root.Entities.Where(e => e.health > 0).ToList();
            }
        }
    }
}
