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
        public Inventory playerInventory;
        public List<Item> AllItems { get; private set; } = new List<Item>();

        public Shop() { }

        public Shop(Inventory inventory)
        {
            this.playerInventory = inventory;
        }

        Item item_01 = new Item("낡은 검", 2, ItemType.무기, "- 금방이라도 부러질 듯합니다.", "500", "모든 직업 이용 가능");
        Item item_02 = new Item("청동 도끼", 5, ItemType.무기, "- 어디선가 사용됐던 흔적이 있습니다.", "800", "모든 직업 이용 가능");
        Item item_03 = new Item("철검", 10, ItemType.무기, "- 꽤나 잘 만들어져 있습니다.", "1300", "[전사] 전용 장비");
        Item item_04 = new Item("잘 벼려진 나이프", 10, ItemType.무기, "- 굉장히 날카롭습니다.", "1300", "[도적] 전용 장비");

        Item item_21 = new Item("수련자 갑옷", 5, ItemType.방어구, "- 썩 믿음직스럽지는 않습니다.", "500", "모든 직업 이용 가능");
        Item item_22 = new Item("청동 갑옷", 8, ItemType.방어구, "- 약한 칼 정도는 우습습니다.", "800", "모든 직업 이용 가능");
        Item item_23 = new Item("무쇠 갑옷", 12, ItemType.방어구, "- 무지 단단해 보입니다.", "1300", "[전사] 전용 장비");
        Item item_24 = new Item("위장 갑옷", 12, ItemType.방어구, "- 위장에 탁월한 갑옷입니다.", "1300", "[도적] 전용 장비");
        public void ShowShop(int page = 1)
        {
            while (true)
            {
                Console.Clear();

                if (page == 1)
                {
                    Console.WriteLine($"------------------------------------현재 무기 상점 목록------------------------------------");
                    Console.WriteLine("방향키 ← →로 상점 페이지 이동\n\n");
                    List<Item> itemList = new List<Item>() { item_01, item_02, item_03, item_04 };
                    int index = 1;
                    foreach (Item item in itemList)
                    {
                        if (item.IsPurchased)
                        {
                            Console.WriteLine($"({index}) [{item.Type}] {item.Name} [구매 완료] \n");
                        }
                        else
                        {
                            Console.WriteLine($"({index}) [{item.Type}] {item.Name}\n공격력: {item.Power}\n{item.Explain}\n골드: {item.Gold}\n{item.AvailableJob}\n");
                        }
                        index++;
                    }
                }
                else if (page == 2)
                {
                    Console.WriteLine("------------------------------------현재 방어구 상점 목록------------------------------------");
                    Console.WriteLine("방향키 ← →로 상점 페이지 이동\n\n");

                    List<Item> itemList = new List<Item>() { item_21, item_22, item_23, item_24 };
                    int index = 1;
                    foreach (Item item in itemList)
                    {
                        if (item.IsPurchased)
                        {
                            Console.WriteLine($"({index}) [{item.Type}] {item.Name} [구매 완료] \n");
                        }
                        else
                        {
                            Console.WriteLine($"({index}) [{item.Type}] {item.Name}\n방어력: {item.Power}\n{item.Explain}\n골드: {item.Gold}\n{item.AvailableJob}\n");
                        }
                        index++;
                    }
                }

                Console.WriteLine($"현재 골드 : {GameLogic.chara.Gold}");
                
                Console.WriteLine("1. 구매하기");
                Console.WriteLine("2. 판매하기");
                Console.WriteLine("0. 나가기");
                Console.Write("\n 숫자 입력 =>");

                var key = Console.ReadKey(intercept: true); // 입력 표시 없이 키 읽음

                if (key.Key == ConsoleKey.RightArrow && page == 1)
                {
                    page = 2;
                }
                else if (key.Key == ConsoleKey.LeftArrow && page == 2)
                {
                    page = 1;
                }
                else if (char.IsDigit(key.KeyChar))
                {
                    Console.Write(key.KeyChar); // 입력된 숫자 표시
                    string remainingInput = Console.ReadLine(); // 나머지 숫자와 엔터 기다림
                    string fullInput = key.KeyChar + remainingInput;

                    if (int.TryParse(fullInput, out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                Buy_Weapon(page);
                                return;
                            case 2:
                                Sale_Weapon();
                                return;
                            case 0:
                                Lobby.InLobby();
                                return;
                            default:
                                Console.WriteLine("올바른 숫자를 입력해주세요.");
                                Console.ReadLine();
                                break;
                        }
                    }
                }
            }
        }

        public void Buy_Weapon(int i)
        {

            Console.Clear();
            Console.WriteLine($"현재 골드 : {GameLogic.chara.Gold}\n");
            Console.WriteLine("어떠한 물건을 구매하시겠습니까?\n");

            List<Item> weaponList = new List<Item>();

            if (i == 1) weaponList = new List<Item> { item_01, item_02, item_03, item_04 };
            else if ( i == 2) weaponList = new List<Item> { item_21, item_22, item_23, item_24 };

            for (int index = 0; index < weaponList.Count; index++)
            {
                Item item = weaponList[index];
                if (item.IsPurchased) Console.WriteLine($"({index + 1}) [{item.Type}] {item.Name} [구매 완료]");
                else if (i == 1) Console.WriteLine($"({index + 1}) [{item.Type}] {item.Name} | 공격력: {item.Power} | 골드: {item.Gold} | {item.AvailableJob}");
                else if (i == 2) Console.WriteLine($"({index + 1}) [{item.Type}] {item.Name} | 방어력: {item.Power} | 골드: {item.Gold} | {item.AvailableJob}");

            }

            Console.WriteLine("\n0. 나가기");
            Console.Write("\n사고 싶은 물건의 번호를 입력하여 구입 => ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice >= 1 && choice <= weaponList.Count)
                {
                    
                    Item selectedItem = weaponList[choice - 1];
                    if (selectedItem.IsPurchased)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"그건 이미 사간 제품이잖아요!");
                        Console.WriteLine("");
                        Console.WriteLine("아무 키나 눌러 구매창으로 나가기"); Console.ReadLine();
                        Buy_Weapon(i);
                    }
                    if (GameLogic.chara.Gold < int.Parse(selectedItem.Gold))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("이봐요, 돈이 없잖아요!");
                        Console.WriteLine("");
                        Console.WriteLine("아무 키나 눌러 구매창으로 나가기"); Console.ReadLine();
                        Buy_Weapon(i);
                    }
                    playerInventory.AddItem(selectedItem);
                    GameLogic.chara.Gold -= int.Parse(selectedItem.Gold);
                    selectedItem.IsPurchased = true;
                    Console.WriteLine($"\n[{selectedItem.Name}] 구매가 완료되었습니다.");
                    Console.WriteLine($"남은 골드 : {GameLogic.chara.Gold}");
                }
                else if (choice == 0)
                {
                    ShowShop();
                }
                else
                {
                    Console.WriteLine("\n잘못된 입력입니다.");
                    Buy_Weapon(i);
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
                        playerInventory.EquipItems();
                        break;
                    case 0:
                        Lobby.InLobby();
                        break;
                }
            } 
        }
        public void Sale_Weapon()
        {
            Console.Clear();
            Console.WriteLine($"현재 골드 : {GameLogic.chara.Gold}\n");
            Console.WriteLine("어떠한 물건을 판매하시겠습니까?\n");

           playerInventory.SaleItems(1);
        }
    }
}
