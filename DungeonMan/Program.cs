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
        public static Dungeon dungeon = new Dungeon();
        public static Healing healing = new Healing();

        public static void Main(string[] args)
        {
            // 게임 상태 로드
            GameState loaded = SaveLoad.Load();
            if (loaded != null)
            {
                // 게임 상태 로드 후, 로비로 바로 이동
                GameLogic.chara = loaded.Player;
                Program.inventory = loaded.Inventory;
                shop = new Shop(inventory);

                //dungeon = loaded.Dungeon;
                //healing = loaded.Healing;

                // 로비로 이동
                Lobby.InLobby();
            }
            else
            {
                // 로딩된 상태가 없다면 새로운 게임 시작
                gameLogic.StartGame();
            }
        }
    }

    

}