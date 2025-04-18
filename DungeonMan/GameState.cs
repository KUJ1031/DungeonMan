using DungeonMan.Data;
using DungeonMan.GameSystem;
using DungeonMan.ShopSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMan
{
    [Serializable]
    public class GameState
    {
        public Character Player { get; set; }
        public Inventory Inventory { get; set; }
        public Shop Shop { get; set; }
    }
}
