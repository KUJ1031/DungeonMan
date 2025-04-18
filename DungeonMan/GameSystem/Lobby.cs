using DungeonMan.Data;
using DungeonMan.ShopSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMan.GameSystem
{
    internal class Lobby
    {
        public static void InLobby()
        {
            GameManager.SaveGame();
            Console.Clear();
            Console.WriteLine($"로비에 입장하였습니다. DungeonMan에 오신 것을 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("(1) 현재 스테이터스 확인");
            Console.WriteLine("(2) 현재 인벤토리 확인");
            Console.WriteLine("(3) 상점");
            Console.WriteLine("(4) 던전 입장");
            Console.WriteLine("(5) 휴식하기");

            Console.WriteLine("");
            Console.Write("원하시는 행동을 선택해주세요. : ");
            int action = int.Parse(Console.ReadLine());
            switch (action)
            {
                case 1:
                    Status();
                    break;
                case 2:
                    Inventory();
                    break;
                case 3:
                    Shop();
                    break;
                case 4:
                    Dungeon();
                    break;
                case 5:
                    Healing();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요."); Console.ReadLine();
                    InLobby();
                    break;
            }
        }

        public static void Status()
        {
           
            GameLogic.chara.ShowStats();
        }

        public static void Inventory()
        {
            Program.inventory.ShowItems();
        }

        public static void Shop()
        {
            Program.shop.ShowShop();
        }

        public static void Dungeon()
        {
            Program.dungeon.IntoDungeon();
        }

        public static void Healing()
        {
            Program.healing.IntoHealing();
        }
    }
}
