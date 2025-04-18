using System.Text.Json;
using System.IO;

namespace DungeonMan
{
    public static class SaveLoad
    {
        private static string filePath = "save.json";

        public static void Save(GameState state)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            // GameState 객체를 JSON 파일로 직렬화
            string json = JsonSerializer.Serialize(state, options);
            File.WriteAllText(filePath, json);
            Console.WriteLine("[게임 저장 완료]");
        }

        public static GameState Load()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("[저장 파일 없음. 새로 시작합니다]");
                return null;
            }

            // JSON 파일을 읽고, GameState 객체로 역직렬화
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<GameState>(json);
        }
    }
}
