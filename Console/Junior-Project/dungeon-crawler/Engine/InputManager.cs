using System.Numerics;
using dungeon_crawler.Engine.Objects;

namespace dungeon_crawler.Engine {
    public class InputManager {
        // Later I while make blocking input and none blocking so you can built many differnt types sof game but for now mine engine dont need it
        public static InputManager instence; 

        public InputManager() {
            if(instence == null) {
                instence = this;
            }
        }

        public void WaitForInput(List<GameObj> gameObjs) {
            ConsoleKeyInfo key = Console.ReadKey(true);

            foreach (GameObj gameObj in gameObjs) {
                gameObj.SetState(key);
            }

            return;
        }
    }
}
