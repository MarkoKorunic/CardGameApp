using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Entity
    {
        public string entityId { get; set; }
        public int health { get; set; }
        public int attack { get; set; }
        public bool attackReady { get; set; }
        public EntityType entityType { get; set; }
        public List<Modifier> modifiers { get; set; }

    }

    public enum EntityType
    {
        Avatar = 1,
        Creature = 2


    }
}

