namespace dungeon_crawler.Game.GameObj
{
    public abstract class RpgComponent {
        public GameObj GameObject { get; internal set; }

        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void Draw() { }
    }
}