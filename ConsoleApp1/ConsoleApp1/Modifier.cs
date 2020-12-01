using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Modifier
    {
        public ModifierType modifierType { get; set; }
        public int value { get; set; }


    }

    public enum ModifierType
    {
        Armour = 1,
        Vulnerability = 2
    }
}

