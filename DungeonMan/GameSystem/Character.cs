using DungeonMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMan.GameSystem
{
    public class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }
        public string Job { get; set; }

        public Item EquippedWeapon { get; set; } // 무기
        public Item EquippedArmor { get; set; }  // 방어구

        public Character(string name, string job)
        {
            Name = name;
            Job = job;
            Level = 1;
            Gold = 10500;

            if (job == "전사")
            {
                AttackPower = 10;
                DefensePower = 15;
                Hp = 100;
            }
            else if (job == "도적")
            {
                AttackPower = 20;
                DefensePower = 7;
                Hp = 18;
            }
        }
        public void ShowStats()
        {
            Console.Clear();
            Console.WriteLine("----------------현재 스테이터스------------------");
            Console.WriteLine("");
            Console.WriteLine("이름 : " + Name);
            Console.WriteLine("Lv. " + Level);
            Console.WriteLine("Chad. " + Job);
            string attackInfo = AttackPower.ToString();
            if (EquippedWeapon != null)
            {
                int baseAttack = AttackPower - EquippedWeapon.Power;
                attackInfo = $"{AttackPower} ({EquippedWeapon.Name} +{EquippedWeapon.Power})";
            }

            string defenseInfo = DefensePower.ToString();
            if (EquippedArmor != null)
            {
                int baseDefense = DefensePower - EquippedArmor.Power;
                defenseInfo = $"{DefensePower} ({EquippedArmor.Name} +{EquippedArmor.Power})";
            }
            Console.WriteLine("공격력 : " + attackInfo);
            Console.WriteLine("방어력 : " + defenseInfo);
            Console.WriteLine("체력 : " + Hp);
            Console.WriteLine("골드 : " + Gold);
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("아무 버튼이나 눌러 나가기."); Console.ReadLine();

            Lobby.InLobby();
        }

        public void Equip(Item item)
        {
            if (item.Type == ItemType.무기)
            {
                EquippedWeapon = item;
                AttackPower += item.Power;
            }
            else if (item.Type == ItemType.방어구)
            {
                EquippedArmor = item;
                DefensePower += item.Power;
            }
        }


    }
}
