using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMan.Data
{
    public class Item
    {
        public string Name { get; set; }
        public int AttackPower { get; set; }
        public string DefensePower { get; set; }
        public string Explain { get; set; }
        public string Gold { get; set; }
        public string AvailableJob { get; set; }


        public Item(string name, int attack, string explain, string gold, string availablejob)
        {
            Name = name;
            AttackPower = attack;
            Explain = explain;
            Gold = gold;
            AvailableJob = availablejob;
        }
        public Item(string name, string defense, string explain, string gold, string availablejob)
        {
            Name = name;
            DefensePower = defense;
            Explain = explain;
            Gold = gold;
            AvailableJob = availablejob;
        }
    }
}
