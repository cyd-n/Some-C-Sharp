using System.Numerics;
using System.Reflection.Metadata;

namespace dungeon_crawler.Game.GameObj {
    public class GameObj : IObj {
        public string name {get; private set;}
        public string tag = "";

        public Vector2 position = new Vector2(0, 0);

        public bool active = false;

        public GameObj(string _name, String _tag = "default", Vector2 _position = new Vector2(), bool _active = true) {
            name = _name;
            tag = _tag;
            position = _position;
            active = _active;
        }

        public virtual void Start() {}

        public virtual void Update() {}

        public virtual void Draw() {}
    }
}