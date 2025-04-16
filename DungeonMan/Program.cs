using System.Diagnostics;
using System.Reflection.Emit;
using System.Xml.Linq;
using DungeonMan.GameSystem;
using DungeonMan.ShopSystem;

namespace DungeonMan
{
    internal class Program
    {
        public static Inventory inventory = new Inventory();
        public static Shop shop = new Shop(inventory);
        public static GameLogic gameLogic = new GameLogic();

        static void Main(string[] args)
        {
            gameLogic.StartGame();
        }
        
    }

    

}