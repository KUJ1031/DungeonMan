using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMan.GameSystem;
using DungeonMan.Data;

namespace DungeonMan.ShopSystem
{
    public class Shop
    {
        private Inventory playerInventory;

        public Shop(Inventory inventory)
        {
            this.playerInventory = inventory;
        }

        Item item_01 = new Item("낡은 검", 2, "금방이라도 부러질 듯합니다.", "500", "모든 직업 이용 가능");
        Item item_02 = new Item("청동 도끼", 5, "어디선가 사용됐던 흔적이 있습니다.", "800", "모든 직업 이용 가능");
        Item item_03 = new Item("철검", 10, "꽤나 잘 만들어져 있습니다.", "1300", "[전사] 전용 장비");
        Item item_04 = new Item("잘 벼려진 나이프", 10, "날카롭습니다.", "1300", "[도적] 전용 장비");

        Item item_21 = new Item("수련자 갑옷", "5", "잘 벼려진 검입니다.", "500", "모든 직업 이용 가능");
        Item item_22 = new Item("청동 갑옷", "8", "약한 칼 정도는 우습습니다.", "800", "모든 직업 이용 가능");
        Item item_23 = new Item("무쇠 갑옷", "12", "매우 단단해 보입니다.", "1300", "[전사] 전용 장비");
        Item item_24 = new Item("위장 갑옷", "12", "위장에 탁월한 갑옷입니다.", "1300", "[도적] 전용 장비");
        public void ShowShop(int page = 1)
        {
            Console.Clear();
            if (page == 1)
            {
                Console.WriteLine($"------------------------------------현재 무기 상점 목록------------------------------------");
                Console.WriteLine("");

                List<Item> itemList = new List<Item>() { item_01, item_02, item_03, item_04 };
                int index = 1;
                foreach (Item item in itemList)
                {
                    Console.WriteLine($"({index}) {item.Name}\n공격력: {item.AttackPower}\n{item.Explain}\n골드: {item.Gold}\n{item.AvailableJob}\n");
                    index++;
                }
            }
            else if (page == 2)
            {
                Console.WriteLine($"------------------------------------현재 방어구 상점 목록------------------------------------");
                Console.WriteLine("");

                List<Item> itemList = new List<Item>() { item_21, item_22, item_23, item_24 };
                int index = 1;
                foreach (Item item in itemList)
                {
                    Console.WriteLine($"({index}) {item.Name}\n방어력: {item.DefensePower}\n{item.Explain}\n골드: {item.Gold}\n{item.AvailableJob}\n");
                    index++;
                }
            }
            Console.WriteLine("");

            Console.WriteLine("\n방향키 ← →로 상점 페이지 이동");
            Console.WriteLine("");
            Console.WriteLine("1. 구매하기");
            Console.WriteLine("0. 나가기");
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.RightArrow && page == 1)
            {
                ShowShop(2);  // 다음 페이지로
            }
            else if (key.Key == ConsoleKey.LeftArrow && page == 2)
            {
                ShowShop(1);  // 이전 페이지로
            }

            int i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1:
                    if (page == 1)
                    {
                        Buy_Weapon();
                    }
                    else if (page == 2)
                    {
                        Buy_Sheild();
                    }
                    break;
                case 0:
                    ShowShop();
                    break;
                default:
                    ShowShop();
                    break;
            }
        }

        public void Buy_Weapon()
        {

            Console.Clear();
            Console.WriteLine("어떠한 무기를 구매하시겠습니까?");
            Console.WriteLine($"(1) {item_01.Name} | 공격력:{item_01.AttackPower} | 골드:{item_01.Gold} | {item_01.AvailableJob}");
            Console.WriteLine($"(2) {item_02.Name} | 공격력:{item_02.AttackPower} | 골드:{item_02.Gold} | {item_02.AvailableJob}");
            Console.WriteLine($"(3) {item_03.Name} | 공격력:{item_03.AttackPower} | 골드:{item_03.Gold} | {item_03.AvailableJob}");
            Console.WriteLine($"(4) {item_04.Name} | 공격력:{item_04.AttackPower} | 골드:{item_04.Gold} | {item_04.AvailableJob}");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.Write("사고싶은 물건의 번호를 입력하여 구입 =>");
            int i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1: playerInventory.AddItem(item_01); Console.WriteLine($"[{item_01.Name}] 구매가 완료되었습니다."); Console.WriteLine(""); break;
                case 2: playerInventory.AddItem(item_02); Console.WriteLine($"[{item_02.Name}] 구매가 완료되었습니다."); Console.WriteLine(""); break;
                case 3: playerInventory.AddItem(item_03); Console.WriteLine($"[{item_03.Name}] 구매가 완료되었습니다."); Console.WriteLine(""); break;
                case 4: playerInventory.AddItem(item_04); Console.WriteLine($"[{item_04.Name}] 구매가 완료되었습니다."); Console.WriteLine(""); break;
                case 0:
                    ShowShop();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Buy_Weapon();
                    break;
            }
            Console.WriteLine("1. 상점으로 돌아가기");
            Console.WriteLine("2. 인벤토리 확인");
            Console.WriteLine("0. 로비로 돌아가기");

            int j = int.Parse(Console.ReadLine());
            switch (j)
            {
                case 1:
                    ShowShop();
                    break;
                case 2:
                    playerInventory.ShowItems();
                    break;
                case 0:
                    Program.Lobby();
                    break;
            }
        }

        public void Buy_Sheild()
        {
            Console.Clear();
            Console.WriteLine("어떠한 방어구를 구매하시겠습니까?");
            Console.WriteLine($"(1) {item_21.Name} | 방어력:{item_21.AttackPower} | 골드:{item_21.Gold} | {item_21.AvailableJob}");
            Console.WriteLine($"(2) {item_22.Name} | 방어력:{item_22.AttackPower} | 골드:{item_22.Gold} | {item_22.AvailableJob}");
            Console.WriteLine($"(3) {item_23.Name} | 방어력:{item_23.AttackPower} | 골드:{item_23.Gold} | {item_23.AvailableJob}");
            Console.WriteLine($"(4) {item_24.Name} | 방어력:{item_24.AttackPower} | 골드:{item_24.Gold} | {item_24.AvailableJob}");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.Write("사고싶은 물건의 번호를 입력하여 구입 =>");
            int i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1: playerInventory.AddItem(item_21); Console.WriteLine($"[{item_21.Name}] 구매가 완료되었습니다."); Console.WriteLine(""); break;
                case 2: playerInventory.AddItem(item_22); Console.WriteLine($"[{item_22.Name}] 구매가 완료되었습니다."); Console.WriteLine(""); break;
                case 3: playerInventory.AddItem(item_23); Console.WriteLine($"[{item_23.Name}] 구매가 완료되었습니다."); Console.WriteLine(""); break;
                case 4: playerInventory.AddItem(item_24); Console.WriteLine($"[{item_24.Name}] 구매가 완료되었습니다."); Console.WriteLine(""); break;
                case 0:
                    ShowShop();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Buy_Weapon();
                    break;
            }
            Console.WriteLine("1. 상점으로 돌아가기");
            Console.WriteLine("2. 인벤토리 확인");
            Console.WriteLine("0. 로비로 돌아가기");

            int j = int.Parse(Console.ReadLine());
            switch (j)
            {
                case 1:
                    ShowShop();
                    break;
                case 2:
                    playerInventory.ShowItems();
                    break;
                case 0:
                    Program.Lobby();
                    break;
            }
        }
    }
}
