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
        public static Job job;
        public void StartGame()
        {
            Console.WriteLine("- DungeonMan에 오신 것을 환영합니다.");
            CharacterNickname();

        }

        public static void CharacterNickname()
        {
            Console.WriteLine("");
            Console.Write("당신의 이름은 무엇인가요? =>  ");
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
            Console.Write("\n당신이 걸어갈 길은 무엇인가요? =>  ");
            if (int.TryParse(Console.ReadLine(), out int selectedJob) && Enum.IsDefined(typeof(Job), selectedJob))
            {

                Job job = (Job)selectedJob;
                switch (job)
                {
                    case Job.전사:
                        Console.Clear();
                        Console.WriteLine("<거대한 대검을 손에 쥔 호쾌한 싸움꾼>\n\n[전사] 직업을 택하시겠습니까?\n\n");
                        Console.Write("(1)예 (2)아니오 ");
                        Console.Write("\n결정 =>  ");
                        int i = int.Parse(Console.ReadLine());
                        if (i == 1)
                        {
                            savedJob = "전사";
                            chara = new Character(nickname, savedJob);
                            Console.Clear();
                            Console.WriteLine("당신의 운명이 결정되는 중입니다...");
                            Thread.Sleep(2000);
                            Console.Clear();
                            Console.WriteLine("[전사] 전직이 완료되었습니다. 행운을 빕니다...\n\n아무 키를 눌러 로비로 이동해주세요."); Console.ReadLine();
                            Lobby.InLobby();
                        }
                        else if (i == 2)
                        {
                            SelectJob();
                        }
                        else
                        {
                            Console.WriteLine("- 올바른 키를 눌러주세요."); Console.ReadLine();
                            SelectJob();
                        }
                        break;
                    case Job.도적:
                        Console.Clear();
                        Console.WriteLine("<어둠 속의 은밀한 암살자>\n\n[도적] 직업을 택하시겠습니까?\n\n");
                        Console.Write("(1)예 (2)아니오 ");
                        Console.Write("\n결정 =>  ");
                        int j = int.Parse(Console.ReadLine());
                        if (j == 1)
                        {
                            savedJob = "도적";
                            GameLogic.chara = new Character(nickname, savedJob);
                            Console.Clear();
                            Console.WriteLine("당신의 운명이 결정되는 중입니다...");
                            Thread.Sleep(2000);
                            Console.Clear();
                            Console.WriteLine("[도적] 전직이 완료되었습니다. 행운을 빕니다...\n\n아무 키를 눌러 로비로 이동해주세요."); Console.ReadLine();
                            Lobby.InLobby();
                        }
                        else if (j == 2)
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
      public enum Job { 전사 = 1, 도적 }
    }

}
