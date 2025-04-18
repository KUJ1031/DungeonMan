using DungeonMan.GameSystem;
using DungeonMan.ShopSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMan
{
    public static class GameManager
    {
        public static void SaveGame()
        {
            GameState currentState = new GameState
            {
                Player = GameLogic.chara,
                Inventory = Program.inventory,
                Shop = Program.shop,
               // Dungeon = Program.dungeon,
                //Healing = Program.healing,


            };
            SaveLoad.Save(currentState);
        }

        public static void LoadGame()
        {
            GameState loaded = SaveLoad.Load();
            if (loaded != null)
            {
                GameLogic.chara = loaded.Player;
                Program.inventory = loaded.Inventory;
                Program.shop = loaded.Shop;

               // Program.dungeon = loaded.Dungeon;
               // Program.healing = loaded.Healing;

            }
        }
    }
}
