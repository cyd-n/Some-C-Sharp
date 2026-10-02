using dungeon_crawler.Engine.Components;
using dungeon_crawler.Engine.Components.Objects;

namespace dungeon_crawler.Game {
    public class PlayerComponent : RpgComponent {
        public PlayerComponent() { }

        public override void Start() { }

        public override void Update() { }

        public override void Input(ConsoleKeyInfo _key) {
            if (_key.Key == ConsoleKey.W || _key.Key == ConsoleKey.UpArrow) {
                gameObject.position.Y -= 1;
            } else if (_key.Key == ConsoleKey.D || _key.Key == ConsoleKey.RightArrow) {
                gameObject.position.X += 1;
            } else if (_key.Key == ConsoleKey.S || _key.Key == ConsoleKey.DownArrow) {
                gameObject.position.Y += 1;
            } else if (_key.Key == ConsoleKey.A || _key.Key == ConsoleKey.LeftArrow) {
                gameObject.position.X -= 1;
            }
        }

        public override void Draw() { }
    }
}