using System;
using DungeonMan.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using System.Xml.Linq;
using static DungeonMan.GameSystem.Dungeon;

namespace DungeonMan.GameSystem
{

    public delegate void PlayerAttackHanler(int damage);
    public delegate void EnemySlimeAttackHanler(int damage);
    public delegate void EnemyGoblinAttackHanler(int damage);
    public delegate void EnemyDevilttackHanler(int damage);
    public class Dungeon
    {
        EnterDungeon dungeon = new EnterDungeon();
        Slime slime = new Slime();
        Goblin goblin = new Goblin();
        Devil devil = new Devil();
        static Player player = Player.Instance;

        int turn = 1;

        public class Player
        {
            public bool IsInitialized = false;
            private static Player instance;

            // 외부에서 생성하지 못하도록 생성자 private
            private Player() { }

            public void ClearEvents()
            {
                OnAttack = null;
            }

            // 인스턴스를 가져오는 public static 속성
            public static Player Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Player();
                    }
                    return instance;
                }
            }


            public event PlayerAttackHanler OnAttack;
            public string PlayerJob;
            public bool isDie = false;
            public bool IsConnectedToEvents = false;
            public void ViewPlayerStats()
            {
                Console.WriteLine($"이름 : {GameLogic.chara.Name}");
                Console.WriteLine($"직업 : {GameLogic.chara.Job}");
                Console.WriteLine($"레벨 : {GameLogic.chara.Level}");
                Console.WriteLine($"경험치 : {GameLogic.chara.CurrentExp}/{GameLogic.chara.LevelupExp}");
                Console.WriteLine($"체력 : {GameLogic.chara.CurrentHp}/{GameLogic.chara.MaxHp}");
                Console.WriteLine($"공격력 : {GameLogic.chara.AttackPower}");
                Console.WriteLine($"방어력 : {GameLogic.chara.DefensePower}");
                Console.WriteLine($"골드 : {GameLogic.chara.Gold}");
            }

            public void InitEnemy(string enemy)
            {
                Console.WriteLine($"전투가 발생하였습니다. [{enemy}]");
                Attack(GameLogic.chara.AttackPower);
            }

            public void Attack(int damage)
            {
                Console.Write($"{GameLogic.chara.Name}의 공격! ");
                OnAttack?.Invoke(damage);
            }

            public void HandleDamage(int damage)
            {
                int realDamage = Math.Max(0, damage - GameLogic.chara.DefensePower);
                GameLogic.chara.CurrentHp -= realDamage;
                if (GameLogic.chara.CurrentHp <= 0)
                {
                    Console.WriteLine("사망했다...");
                    GameOver();
                }
                else
                {
                    Console.WriteLine($"{GameLogic.chara.Name}에게 {damage} 데미지, 그러나 {GameLogic.chara.Name}의 방어력 {GameLogic.chara.DefensePower}만큼 데미지를 경감!"); Thread.Sleep(1000);
                    Console.WriteLine($"총 {GameLogic.chara.Name}에게 {realDamage}의 데미지!");
                }
            }
        }


        public interface IDungeon
        {
            void Init(string dungeonName);
        }
        public class EnterDungeon : IDungeon
        {
            public string Name { get; set; }
            public void Init(string dungeonName)
            {
                Name = dungeonName;
                Console.WriteLine($"{Name} 던전에 입장하였습니다...");
                Thread.Sleep(1000);
            }
        }

        public interface IMonster
        {

            void Attack(int power);
            void HandleDamage(int damage);
            bool IsDie();
        }

        public interface IStatus
        {
            void ShowStatus(int a);
        }

        public class Slime : IMonster, IStatus
        {
            public event EnemySlimeAttackHanler OnAttack;
            public string Name = "슬라임";
            public int hp = 30;

            static Random random = new Random();
           
            public bool isDie = false;
            public int dropGold = 1000;
            public int dropExp = 50;

            public bool isFighted_Slime;

            public void Attack(int power)
            {
                OnAttack?.Invoke(power);
            }
            public void ShowStatus(int hp)
            {
                Console.WriteLine($"{Name}의 체력이 {hp}만큼 남은 것으로 보인다...\n");
            }
            public void HandleDamage(int damage)
            {
                isDie = false;
                int power = random.Next(20, 36); // 20 ~ 35중 공격력 랜덤

                Thread.Sleep(1000);
                hp -= damage;
                Console.WriteLine($"{Name}에게 {damage} 데미지");
                Thread.Sleep(1000);

                if (hp <= 0)
                {
                    IsDie();
                }
                else
                {
                    Console.Write($"{Name}의 공격! ");
                    Thread.Sleep(1000);
                    Attack(power);
                }
            }

            public bool IsDie()
            {
                isDie = true;
                Console.WriteLine($"{Name}에게서 승리!\n");
                GameLogic.chara.Gold += dropGold;
                
                Console.WriteLine($"보상 : {dropGold}골드 획득! 총 소지 골드 : {GameLogic.chara.Gold}");
                Console.WriteLine($"보상 : {dropExp}경험치 획득!");
                GameLogic.chara.AddExp(dropExp);

                hp = 30;
                isFighted_Slime = false;
                return isDie;
                
            }
        }

        public class Goblin : IMonster, IStatus
        {
            public event EnemyGoblinAttackHanler OnAttack;
            public string Name = "고블린";
            public int hp = 50;
            public int dropExp = 100;

            static Random random = new Random();
            public bool isDie = false;
            public int dropGold = 2500;

            public bool isFighted_Goblin = false;

            public void Attack(int power)
            {
                OnAttack?.Invoke(power);
            }
            public void ShowStatus(int hp)
            {
                Console.WriteLine($"{Name}의 체력이 {hp}만큼 남은 것으로 보인다...\n");
            }
            public void HandleDamage(int damage)
            {
                isDie = false;
                int power = random.Next(40, 56); // 40 ~ 55중 공격력 랜덤

                Thread.Sleep(1000);
                hp -= damage;
                Console.WriteLine($"{Name}에게 {damage} 데미지");
                Thread.Sleep(1000);

                if (hp <= 0)
                {
                    IsDie();
                }
                else
                {
                    Console.Write($"{Name}의 공격! ");
                    Thread.Sleep(1000);
                    Attack(power);
                }
            }



            public bool IsDie()
            {
                isDie = true;
                Console.WriteLine($"{Name}에게서 승리!\n");
                GameLogic.chara.Gold += dropGold;
                Console.WriteLine($"보상 : {dropGold}골드 획득! 총 소지 골드 : {GameLogic.chara.Gold}");
                Console.WriteLine($"보상 : {dropExp}경험치 획득!");
                GameLogic.chara.AddExp(dropExp);

                isFighted_Goblin = false;

                hp = 50;
                return isDie;

            }
        }
        public class Devil : IMonster, IStatus
        {
            public event EnemyDevilttackHanler OnAttack;
            public string Name = "악마";
            public int hp = 100;

            static Random random = new Random();
            public bool isDie = false;
            public int dropGold = 5000;
            public int dropExp = 200;

            public bool isFighted_Devil = false;

            public void Attack(int power)
            {
                OnAttack?.Invoke(power);
            }
            public void ShowStatus(int hp)
            {
                Console.WriteLine($"{Name}의 체력이 {hp}만큼 남은 것으로 보인다...\n");
            }
            public void HandleDamage(int damage)
            {
                isDie = false;
                int power = random.Next(120, 151); // 120 ~ 150중 공격력 랜덤

                Thread.Sleep(1000);
                hp -= damage;
                Console.WriteLine($"{Name}에게 {damage} 데미지");
                Thread.Sleep(1000);

                if (hp <= 0)
                {

                    IsDie();
                }
                else
                {
                    Console.Write($"{Name}의 공격! ");
                    Thread.Sleep(1000);
                    Attack(power);
                }
            }



            public bool IsDie()
            {
                isDie = true;
                Console.WriteLine($"{Name}에게서 승리!\n");
                GameLogic.chara.Gold += dropGold;
                Console.WriteLine($"보상 : {dropGold}골드 획득! 총 소지 골드 : {GameLogic.chara.Gold}");
                Console.WriteLine($"보상 : {dropExp}경험치 획득!");
                GameLogic.chara.AddExp(dropExp);

                isFighted_Devil = false;

                hp = 100;
                return isDie;

            }
        }
        public void IntoDungeon()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("던전에 오신 것을 환영합니다.");
                Console.WriteLine("입장할 던전을 선택해주세요.\n");
                Console.WriteLine("1.(Lv. 1~3 추천) 초보자용 던전.");
                Console.WriteLine("2.(Lv. 4~6 추천) 꽤 깊은 던전.");
                Console.WriteLine("3.(Lv. 7~9 추천) 가장 어두운 던전.");
                Console.WriteLine("4.현재 스테이터스 확인.");
                Console.WriteLine("0.로비로 나가기.");
                Console.Write("\n입장할 던전을 선택해주세요.\n>> ");

                int action;
                if (!int.TryParse(Console.ReadLine(), out action))
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                    Thread.Sleep(1000);
                    continue;
                }

                if (action == 1)
                {
                    player.ClearEvents();
                    player.OnAttack += slime.HandleDamage;
                    slime.OnAttack += player.HandleDamage;

                    slime.isFighted_Slime = true;
                    dungeon.Init("초보자용"); 
                    player.InitEnemy("슬라임");

                    while (!(slime.isDie))
                    {
                        FightEnemy();

                    }
                }
                else if (action == 2)
                {
                    player.ClearEvents();
                    player.OnAttack += goblin.HandleDamage;
                    goblin.OnAttack += player.HandleDamage;

                    goblin.isFighted_Goblin = true;
                    dungeon.Init("꽤 깊은");
                    player.InitEnemy("고블린");

                    // 전투 시작
                    while (!(goblin.isDie))
                    {
                        FightEnemy();
                    }
                    
                }
                else if (action == 3)
                {
                    player.ClearEvents();
                    player.OnAttack += devil.HandleDamage;
                    devil.OnAttack += player.HandleDamage;

                    devil.isFighted_Devil = true;
                    dungeon.Init("가장 어두운");
                    player.InitEnemy("악마");

                    while (!(devil.isDie))
                    {
                        FightEnemy();
                    }
                }
                else if (action == 4)
                {
                    player.ViewPlayerStats();
                    Thread.Sleep(2000);
                    continue;
                }
                else if (action == 0)
                {
                    Lobby.InLobby();
                    return;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                    Thread.Sleep(1500);
                    continue;
                }
                // 전투 종료 메시지
                Console.WriteLine("\n전투가 끝났습니다. 아무 키나 누르면 던전 선택 화면으로 돌아갑니다...");
                Console.ReadKey();
            }
        }

        
        public void FightEnemy()
        {
            
            Console.Write($"\n[현재 {turn}턴]");
            Console.WriteLine($"\n1.공격하기 2. 스테이터스 3. 상대 주시");
            Console.Write($"\n어떻게 할까? >> ");

            string input = Console.ReadLine();

            if (input == "1") player.Attack(GameLogic.chara.AttackPower);
            else if (input == "2") player.ViewPlayerStats();
            else if (input == "3")
            {
                if (slime.isFighted_Slime)
                {
                    slime.ShowStatus(slime.hp);
                }
                else if (goblin.isFighted_Goblin)
                {
                    goblin.ShowStatus(goblin.hp);
                }
                else if (devil.isFighted_Devil)
                {
                    devil.ShowStatus(devil.hp);
                }

            }
           
            else Console.WriteLine("\n그런 행동은 없는데용...");
            turn++;
            Thread.Sleep(1000);
            
        }

        public static void GameOver()
        {
            Console.WriteLine("\n[Game Over] 당신은 죽었습니다...\n");

            Console.WriteLine("지금까지 모은 골드: " + GameLogic.chara.Gold);

            string[] deathMan = { "정말, 이 방법이 최선이었을까..?", "운이 없었어... 그래, 운이 없었던거야...", "왜 그런 선택을 했을까. 왜..." };
            Random random = new Random();
            int index = random.Next(deathMan.Length); // 0부터 greetings.Length - 1 사이의 정수 반환
            Console.WriteLine(deathMan[index]);

            Console.WriteLine("\n0. 종료하기");
            Console.WriteLine("1. 처음부터 다시 시작");
            Console.Write("선택 >> ");

            string a = Console.ReadLine();

            if (a == "0")
            {
                Console.WriteLine("게임을 종료합니다...");
                Environment.Exit(0); // 정상 종료
            }
            else if (a == "1")
            {
                Console.Clear(); // 콘솔 초기화 (선택)
                DungeonMan.Program.Main(null); // Main 메서드 재호출
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 종료합니다...");
                Environment.Exit(0);
            }
        }
    }
}

