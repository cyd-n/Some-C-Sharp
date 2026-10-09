using dungeon_crawler.Engine.Objects;

namespace dungeon_crawler.Engine.Components
{
    public abstract class RpgComponent {
        public GameObj gameObject { get; set; }

        public abstract void Start();
        public abstract void Update();
        public abstract void Input(ConsoleKeyInfo _key);
        public abstract void Draw();
    }
}