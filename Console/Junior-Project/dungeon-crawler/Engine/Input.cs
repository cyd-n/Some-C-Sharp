using System.Numerics;
using dungeon_crawler.Engine.Components.Objects;
using dungeon_crawler.Game.GameObj;

namespace dungeon_crawler.Engine {
    public class InputManager {
        public static InputManager instence; 

        private ConsoleKeyInfo currentKey;

        public InputManager() {
            if(instence == null) {
                instence = this;
            }
        }

        public void WaitForInput(List<GameObj> _gameObjs) {
            currentKey = Console.ReadKey(true);

            foreach(GameObj gO in _gameObjs) {
                gO.Input(currentKey);
            }
        }
    }
}
