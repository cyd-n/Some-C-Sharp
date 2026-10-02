namespace dungeon_crawler.Game.GameObj
{
    public abstract class RpgComponent {
        public GameObj GameObject { get; internal set; }

        public abstract void Start();
        public abstract void Update();
        public abstract void Draw();
    }
}