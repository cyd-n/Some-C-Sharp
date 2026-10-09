using System.Numerics;
using dungeon_crawler.Engine.Components;
using dungeon_crawler.Engine.Objects;

namespace dungeon_crawler.Game {
    public class PlayerComponent : RpgComponent {

        public override void Await(){ }

        public override void Start() { }

        public override void Update() { }

        public override void Input(ConsoleKeyInfo _key) {
            RigidbodyComponent rb = gameObject.GetComponent<RigidbodyComponent>();
            if (rb == null)
                return;

            if (_key.Key == ConsoleKey.W || _key.Key == ConsoleKey.UpArrow)
                rb.Move(new Vector2(0, -1));
            else if (_key.Key == ConsoleKey.S || _key.Key == ConsoleKey.DownArrow)
                rb.Move(new Vector2(0, 1));
            else if (_key.Key == ConsoleKey.A || _key.Key == ConsoleKey.LeftArrow)
                rb.Move(new Vector2(-1, 0));
            else if (_key.Key == ConsoleKey.D || _key.Key == ConsoleKey.RightArrow)
                rb.Move(new Vector2(1, 0));
        }

        public override void Draw() { }
    }
}