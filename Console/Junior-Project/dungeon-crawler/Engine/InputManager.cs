using System.Numerics;
using dungeon_crawler.Engine.Objects;

namespace dungeon_crawler.Engine {
    public class InputManager {
        public static InputManager instence; 

        public InputManager() {
            if(instence == null) {
                instence = this;
            }
        }

        public void WaitForInput(List<GameObj> gameObjs) {
            ConsoleKeyInfo key = Console.ReadKey(true);

            foreach (GameObj gameObj in gameObjs) {
                gameObj.Input(key);
            }

            return;
        }
    }
}
