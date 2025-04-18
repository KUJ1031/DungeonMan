using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DungeonMan.GameSystem
{
    public class Healing
    {
        public void IntoHealing()
        {
            Console.Clear();
            Console.WriteLine("체력을 회복하러 오셨나요? 500골드에 체력을 50만큼 회복해드리겠습니다.\n");
            Console.WriteLine($"현재 체력 : {GameLogic.chara.CurrentHp}/{GameLogic.chara.MaxHp}");
            Console.WriteLine($"현재 골드 : {GameLogic.chara.Gold}\n");

            Console.WriteLine("(1) 체력 회복");
            Console.WriteLine("(0) 로비로 나가기");

            Console.Write("\n원하시는 행동을 선택해주세요. : ");
            int action = int.Parse(Console.ReadLine());
            switch (action)
            {
                case 1:
                    Heal();
                    break;
                case 0:
                    Lobby.InLobby();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요."); Console.ReadLine();
                    break;
            }
        }

        public void Heal()
        {
            
            if (GameLogic.chara.CurrentHp == GameLogic.chara.MaxHp)
            {
                Console.WriteLine("이미 체력이 전부 차있는 상태입니다.");
            }

            else if (GameLogic.chara.Gold < 500)
            {
                Console.WriteLine("돈 없으면 회복 못 받아요.");
            }

            else 
            {
                int healedHp = 50;
                int beforeHeal = GameLogic.chara.CurrentHp;

                GameLogic.chara.CurrentHp = Math.Min(GameLogic.chara.CurrentHp + healedHp, GameLogic.chara.MaxHp);
                GameLogic.chara.Gold -= 500;

                int actualHealed = GameLogic.chara.CurrentHp - beforeHeal;

                Console.WriteLine($"체력을 회복중입니다..."); Thread.Sleep(1000);
                Console.WriteLine($"..."); Thread.Sleep(1000);
                Console.WriteLine($"..."); Thread.Sleep(1000);
                Console.WriteLine($"..."); Thread.Sleep(1000);

                Console.Clear();
                Console.WriteLine($"{GameLogic.chara.Name}의 Hp가 {actualHealed}만큼 회복되었습니다.");
                Console.WriteLine($"\n현재 Hp : {GameLogic.chara.CurrentHp}/{GameLogic.chara.MaxHp}");
                Console.WriteLine($"\n현재 골드 : {GameLogic.chara.Gold}");
            }

            Console.WriteLine("(1) 체력 회복");
            Console.WriteLine("(0) 로비로 나가기");

            Console.Write("\n원하시는 행동을 선택해주세요. : ");
            int action = int.Parse(Console.ReadLine());
            switch (action)
            {
                case 1:
                    Heal();
                    break;
                case 0:
                    Lobby.InLobby();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요."); Console.ReadLine();
                    break;
            }


        }

    }
}
