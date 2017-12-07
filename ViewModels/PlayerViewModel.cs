using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clanmanager.ViewModels
{
    public class PlayerViewModel
    {
        public Troop[] Troops { get; set; }
        public Spell[] Spells { get; set; }
        public Hero[] Heroes { get; set; }
        public int TownHallLevel { get; set; }
    }
}
