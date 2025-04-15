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

        public Character(string name, string job)
        {
            Name = name;
            Job = job;
            Level = 1;
            Gold = 1000;

            if (job == "전사")
            {
                AttackPower = 15;
                DefensePower = 10;
                Hp = 20;
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
            Console.WriteLine("공격력 : " + AttackPower);
            Console.WriteLine("방어력 : " + DefensePower);
            Console.WriteLine("체력 : " + Hp);
            Console.WriteLine("골드 : " + Gold);
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("아무 버튼이나 눌러 나가기."); Console.ReadLine();

            Program.Lobby();
        }
    }
}
