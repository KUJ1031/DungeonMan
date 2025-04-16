using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMan.Data
{
    public enum ItemType { 무기, 방어구 }

    public class Item
    {

        public string Name { get; set; }
        public int Power { get; set; }
        public ItemType Type { get; set; }
        public string Explain { get; set; }
        public string Gold { get; set; }
        public string AvailableJob { get; set; }

        public bool IsPurchased { get; set; } = false;


        public Item(string name, int attack, ItemType type, string explain, string gold, string availablejob)
        {
            Name = name;
            Power = attack;
            Type = type;
            Explain = explain;
            Gold = gold;
            AvailableJob = availablejob;
        }

        public void ClearExceptGold()
        {
            Explain = "";
            AvailableJob = "";
            Gold = "구매 완료";
        }
    }
}
