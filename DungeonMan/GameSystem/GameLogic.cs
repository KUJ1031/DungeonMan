using DungeonMan.GameSystem;
using DungeonMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMan.GameSystem
{
    public class GameLogic
    {
        public static Character chara;
        public static string nickname;
        public static string savedJob;
        public void StartGame()
        {
            Console.WriteLine("- DungeonMan에 오신 것을 환영합니다.");
            CharacterNickname();

        }

        public static void CharacterNickname()
        {
            Console.WriteLine("");
            Console.Write("당신의 이름을 알려주세요 => ");
            nickname = Console.ReadLine();
            Console.WriteLine($"[{nickname}] ← 이 이름이 맞으신가요?");
            Console.WriteLine("(1)예 (2)아니오");
            int i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1:
                    SelectJob();
                    break;

                case 2:
                    nickname = "";
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
                        chara = new Character(nickname, savedJob);
                        Console.WriteLine("[전사]가 되었습니다. 아무 키를 눌러 로비로 이동해주세요."); Console.ReadLine();
                        Lobby.InLobby();
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
                        GameLogic.chara = new Character(nickname, savedJob);
                        Console.WriteLine("[도적]이 되었습니다. 아무 키를 눌러 로비로 이동해주세요."); Console.ReadLine();
                        Lobby.InLobby();
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
    }

}
