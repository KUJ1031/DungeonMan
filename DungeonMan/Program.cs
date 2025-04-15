using System.Diagnostics;
using System.Reflection.Emit;
using System.Xml.Linq;
using DungeonMan.GameSystem;
using DungeonMan.ShopSystem;

namespace DungeonMan
{
    internal class Program
    {
        public static string Nickname;
        public static string savedJob;

        public static Character Chara;
        public static Inventory inventory = new Inventory(); // 전역 인벤토리
        public static Shop shop = new Shop(inventory);       // 공유된 인벤토리 전달

        static void Main(string[] args)
        {
            StartGame();
        }

        public static void StartGame()
        {
            Console.WriteLine("- DungeonMan에 오신 것을 환영합니다."); Console.ReadLine();
            CharacterNickname();

        }

        public static void CharacterNickname()
        {
            Console.Clear();
            Console.WriteLine("- 당신의 이름을 알려주세요.");
            Nickname = Console.ReadLine();
            Console.WriteLine($"[{Nickname}] ← 이 이름이 맞으신가요?");
            Console.WriteLine("(1)예 (2)아니오");
            int i = int.Parse(Console.ReadLine());
            switch (i) 
            { 
                case 1:
                    SelectJob();
                    break;

                case 2:
                    Nickname = "";
                    CharacterNickname();
                    break;
                default:
                    Console.WriteLine("- 올바른 버튼을 눌러주세요."); Console.ReadLine();
                    CharacterNickname();
                    break;

            }
        }

        public static void SelectJob()
        {
            Console.Clear();
            Console.WriteLine("- 직업을 선택해주세요.");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 도적");
            int jobNum = int.Parse(Console.ReadLine());
            switch (jobNum)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("[전사] 직업을 택하시겠습니까?");
                    Console.Write("(1)예 (2)아니오 ");
                    int selectWarrior = int.Parse(Console.ReadLine());
                    if (selectWarrior == 1)
                    {
                        savedJob = "전사";
                        Program.Chara = new Character(Program.Nickname, Program.savedJob);
                        Console.WriteLine("[전사]가 되었습니다. 아무 키를 눌러 로비로 이동해주세요."); Console.ReadLine();
                        Lobby();
                    }
                    else if (selectWarrior == 2)
                    {
                        SelectJob();
                    }
                    else
                    {
                        Console.WriteLine("- 올바른 키를 눌러주세요."); Console.ReadLine();
                        SelectJob();
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("[도적] 직업을 택하시겠습니까?");
                    Console.Write("(1)예 (2)아니오 ");
                    int selectThief = int.Parse(Console.ReadLine());
                    if (selectThief == 1)
                    {
                        savedJob = "도적";
                        Program.Chara = new Character(Program.Nickname, Program.savedJob);
                        Console.WriteLine("[도적]이 되었습니다. 아무 키를 눌러 로비로 이동해주세요."); Console.ReadLine();
                        Lobby();
                    }
                    else if (selectThief == 2)
                    {
                        SelectJob();
                    }
                    else
                    {
                        Console.WriteLine("- 올바른 키를 눌러주세요."); Console.ReadLine();
                        SelectJob();
                    }
                    break;
                default:
                    Console.WriteLine("- 올바른 키를 눌러주세요."); Console.ReadLine();
                    SelectJob();
                    break;
            }
           
        }

        public static void Lobby()
        {
            Console.Clear();
            Console.WriteLine($"로비에 입장하였습니다. DungeonMan에 오신 것을 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("(1) 현재 스테이터스 확인");
            Console.WriteLine("(2) 현재 인벤토리 확인");
            Console.WriteLine("(3) 상점");

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
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요."); Console.ReadLine();
                    Lobby();
                    break;
            }
        }

        public static void Status()
        {
            Chara.ShowStats();
        }

        public static void Inventory()
        {
            inventory.ShowItems();
        }

        public static void Shop()
        {
            shop.ShowShop();
        }
    }

    

}