using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharactersSheetApp.Models
{
    public class Character
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        // Relationship between Character and Equipment
        // Normally, the convention for a List property is the plural of the object we passing in
        // Here, the singular and plurar for Equipment are the same so we don't put "s" 
        public List<Equipment> Equipment { get; set; }
    }
}
