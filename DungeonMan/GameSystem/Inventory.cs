using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMan.Data;

namespace DungeonMan.GameSystem
{
    public class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public void ShowItems()
        {

            Console.Clear();
            Console.WriteLine($"----------------현재 아이템 목록----------------");
            Console.WriteLine("");
            if (items.Count == 0)
            {
                Console.WriteLine("보유 중인 아이템이 없습니다.");
            }
            else
            {
                int count = 1;
                foreach (Item item in items)
                {
                    if (item.Type == ItemType.무기)
                    {
                        Console.WriteLine($"({count}) [{item.Type}] {item.Name}\n공격력:{item.Power}\n{item.Explain}\n골드:{item.Gold}\n{item.AvailableJob}\n\n");
                    }
                    else if (item.Type == ItemType.방어구)
                    {
                        Console.WriteLine($"({count}) [{item.Type}] {item.Name}\n방어력:{item.Power}\n{item.Explain}\n골드:{item.Gold}\n{item.AvailableJob}\n\n");
                    }

                    count++;
                }
            }
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            int i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1:
                    if (items.Count == 0)
                    {
                        Console.WriteLine($"장착할 수 있는 아이템이 없습니다. 아무 키나 눌러 로비로 돌아가세요."); Console.ReadLine();
                        Lobby.InLobby();
                    }
                    EquipItems();
                    break;
                case 0:
                    Lobby.InLobby();
                    break;
                default:
                    ShowItems();
                    break;
            }

        }
        public void EquipItems(int page = 1)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("장착할 아이템을 선택해주세요.");
                Console.WriteLine("");

                List<Item> weaponItems = new List<Item>();
                List<Item> sheildItems = new List<Item>();

                foreach (Item item in items)
                {
                    if (item.Type == ItemType.무기)
                    {
                        weaponItems.Add(item);
                    }
                    else if (item.Type == ItemType.방어구)
                    {
                        sheildItems.Add(item);
                    }
                }

                if (page == 1)
                {
                    Console.WriteLine("\n[무기 목록]");
                    int count = 1;

                    foreach (Item item in weaponItems)
                    {
                        string equippedTag = (GameLogic.chara.EquippedWeapon == item) ? "[E] " : "";
                        Console.WriteLine($"({count}) {equippedTag}[{item.Type}] {item.Name} | 공격력: {item.Power} | {item.Explain} | {item.AvailableJob}");
                        count++;
                    }
                }

                if (page == 2)
                {
                    Console.WriteLine("\n[방어구 목록]");
                    int count = 1;
                    foreach (Item item in sheildItems)
                    {
                        string equippedTag = (GameLogic.chara.EquippedArmor == item) ? "[E] " : "";
                        Console.WriteLine($"({count}) {equippedTag}[{item.Type}] {item.Name} | 방어력: {item.Power} | {item.Explain} | {item.AvailableJob}");
                        count++;
                    }
                }
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                Console.Write("\n장착할 장비 번호 입력: ");
                ConsoleKeyInfo key = Console.ReadKey(true);

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
                    int selected = int.Parse(key.KeyChar.ToString());

                    if (page == 1 && selected > 0 && selected <= weaponItems.Count)
                    {
                        Item selectedItem = weaponItems[selected - 1];

                        if (GameLogic.chara.EquippedWeapon == selectedItem)
                        {
                            GameLogic.chara.AttackPower -= selectedItem.Power;
                            GameLogic.chara.EquippedWeapon = null;
                            Console.WriteLine($"\n[{selectedItem.Name}] 장착 해제되었습니다!");
                        }
                        else
                        {
                            if (GameLogic.chara.EquippedWeapon != null)
                                GameLogic.chara.AttackPower -= GameLogic.chara.EquippedWeapon.Power;

                            GameLogic.chara.EquippedWeapon = selectedItem;
                            GameLogic.chara.AttackPower += selectedItem.Power;
                            Console.WriteLine($"\n[{selectedItem.Name}] 장착 완료했습니다!");
                            Console.WriteLine($"공격력: {GameLogic.chara.AttackPower} ({selectedItem.Name} +{selectedItem.Power})");
                        }
                    }
                    else if (page == 2 && selected > 0 && selected <= sheildItems.Count)
                    {
                        Item selectedItem = sheildItems[selected - 1];

                        if (GameLogic.chara.EquippedArmor == selectedItem)
                        {
                            GameLogic.chara.DefensePower -= selectedItem.Power;
                            GameLogic.chara.EquippedArmor = null;
                            Console.WriteLine($"\n[{selectedItem.Name}] 장착 해제되었습니다!");
                        }
                        else
                        {
                            if (GameLogic.chara.EquippedArmor != null)
                                GameLogic.chara.DefensePower -= GameLogic.chara.EquippedArmor.Power;

                            GameLogic.chara.EquippedArmor = selectedItem;
                            GameLogic.chara.DefensePower += selectedItem.Power;
                            Console.WriteLine($"\n[{selectedItem.Name}] 장착 완료했습니다!");
                            Console.WriteLine($"방어력: {GameLogic.chara.DefensePower} ({selectedItem.Name} +{selectedItem.Power})");
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 번호입니다.");
                        EquipItems();
                        return;
                    }

                    Console.WriteLine("");
                    Console.WriteLine("1. 장착 관리");
                    Console.WriteLine("0. 나가기");
                    int i = int.Parse(Console.ReadLine());
                    switch (i)
                    {
                        case 1:
                            EquipItems();
                            break;
                        case 0:
                            Lobby.InLobby();
                            break;
                        default:
                            Console.WriteLine("잘못된 버튼을 눌렀습니다.");
                            EquipItems();
                            break;
                    }
                }

            }
        }
    }
    }
