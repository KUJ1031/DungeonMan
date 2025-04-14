namespace DungeonMan
{
    internal class Program
    {

        static void Main(string[] args)
        {
            StartGame();
        }

        public static void StartGame()
        {
            Console.WriteLine("- DungeonMan에 오신 것을 환영합니다."); Console.ReadLine();
            SelectJob();

        }

        public static string SelectJob()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("- 직업을 선택해주세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 도적");

                int jobNum;
                if (!int.TryParse(Console.ReadLine(), out jobNum)) continue;

                switch (jobNum)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("[전사] 직업을 택하시겠습니까?");
                        Console.Write("(1)예 (2)아니오 ");
                        if (int.TryParse(Console.ReadLine(), out int selectWarrior))
                        {
                            if (selectWarrior == 1)
                            {
                                Console.WriteLine("[전사]가 되었습니다. 아무 키를 눌러 로비로 이동해주세요."); Console.ReadLine();
                                Lobby("전사");
                            }
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("[도적] 직업을 택하시겠습니까?");
                        Console.Write("(1)예 (2)아니오 ");
                        if (int.TryParse(Console.ReadLine(), out int selectThief))
                        {
                            if (selectThief == 1)
                            {
                                Console.WriteLine("[도적]이 되었습니다. 아무 키를 눌러 로비로 이동해주세요."); Console.ReadLine();
                                Lobby("도적");
                            }
                        }
                        break;
                }
                
                Console.WriteLine("- 올바른 키를 눌러주세요."); Console.ReadLine();
                SelectJob();
            }
        }

        public static void Lobby(string job)
        {
            Console.Clear();
            Console.WriteLine($"[{job}]로 로비에 입장하였습니다.");
            Console.WriteLine("- DungeonMan에 오신 것을 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("(1) 현재 스테이터스 확인");
            Console.WriteLine("(2) 현재 인벤토리 확인");
            Console.WriteLine("(3) 상점");

            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 선택해주세요.");
            Console.Write(">> "); Console.ReadLine();
        }
    }

}