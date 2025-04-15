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
                    Console.WriteLine($"({count}) {item.Name}\n공격력:{item.AttackPower}\n{item.Explain}\n골드:{item.Gold}\n{item.AvailableJob}\n\n");
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
                    //장착 관련 메서드
                    break;
                case 0:
                    Program.Lobby();
                    break;
                default:
                    ShowItems();
                    break;
            }

        }
    }
}
