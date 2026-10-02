using System.ComponentModel;
using System.Numerics;
using System.Reflection.Metadata;

namespace dungeon_crawler.Game.GameObj {
    public class AsciiComponent : RpgComponent
    {
        // Properties
        public char icon { get; private set; }
        public Vector2 position { get; set; }
        public int sortingOrder { get; set; }
        public bool enabled { get; set; }

        // Methods
        public void SetIcon(char _icon) {
            icon = (_icon == null || _icon == ' ') ? _icon : 'O';
        }

        public void SetPosition(Vector2 _position) {
            position = new Vector2(position.X + GameObject.position.X, position.Y + GameObject.position.Y);
        }

        public override void Start(){
                
        }

        public override void Update() {
                
        }

        public override void Draw() {
                
        }
    }
}