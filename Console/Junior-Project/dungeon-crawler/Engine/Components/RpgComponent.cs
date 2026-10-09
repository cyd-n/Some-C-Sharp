using dungeon_crawler.Engine.Objects;

namespace dungeon_crawler.Engine.Components {
    public abstract class RpgComponent {
        public GameObj gameObject { get; set; }

        public void OnGameObjCreation() {} // this func is not force to override 

        public void OnCreation() {} // this func is not force to override 
        public abstract void Awake();
        public abstract void Start();
        public abstract void Update();
        public abstract void Input(ConsoleKeyInfo _key);
        public abstract void Draw();
        public void OnDeletion() {} // this func is not force to override 
    }
}