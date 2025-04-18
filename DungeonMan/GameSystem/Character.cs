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

        public int CurrentExp {  get; set; }
        public int LevelupExp { get; set; }
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
        public int CurrentHp { get; set; }
        public int MaxHp { get; set; }
        public int Gold { get; set; }
        public string Job { get; set; }

        public Item EquippedWeapon { get; set; } // 무기
        public Item EquippedArmor { get; set; }  // 방어구

        public Character(string name, string job)
        {
            Name = name;
            Job = job;
            Level = 1;
            CurrentExp = 0;
            LevelupExp = 50;
            Gold = 10500;

            if (job == "전사")
            {
                AttackPower = 10;
                DefensePower = 15;
                CurrentHp = 100;
                MaxHp = 100;
                MaxHp = 100;
            }
            else if (job == "도적")
            {
                AttackPower = 20;
                DefensePower = 9;
                CurrentHp = 80;
                MaxHp = 100;
                MaxHp = 100;
            }
        }
        public void ShowStats()
        {
            Console.Clear();
            Console.WriteLine("----------------현재 스테이터스------------------");
            Console.WriteLine("");
            Console.WriteLine("이름 : " + Name);
            Console.WriteLine("Lv. " + Level);
            Console.WriteLine($"Exp : {CurrentExp}/{LevelupExp}");
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
            Console.WriteLine("체력 : " + CurrentHp + "/" + MaxHp);
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

        public void AddExp(int amount)
        {
            CurrentExp += amount;
            while (CurrentExp >= LevelupExp)
            {
                CurrentExp -= LevelupExp;
                LevelUp();
            }
        }

        public void LevelUp()
        {
            Level++;
            LevelupExp = 50 * Level;

            AttackPower += 5;
            DefensePower += 3;
            CurrentHp += 20;
            MaxHp += 20;

            Console.WriteLine($"레벨이 {Level}로 올랐습니다! 다음 레벨까지 필요한 경험치: {CurrentExp}/{LevelupExp}");
        }

       

    }
}
