using System.ComponentModel;
using System.Numerics;
using System.Reflection.Metadata;
using dungeon_crawler.Engine;
using dungeon_crawler.Game.GameObj;

namespace dungeon_crawler.Engine.Components.Art {
    public class AsciiComponent : RpgComponent
    {
        // Properties
        // need Color 
        public char icon { get; private set; }
        public Vector2 position { get; set; }
        public int sortingOrder { get; set; }
        public bool enabled { get; set; }

        // Methods
        public AsciiComponent() {
            //position = GameObject.position;
        }

        public void SetIcon(char _icon) {
            icon = (_icon != null || _icon != ' ') ? _icon : 'O';
        }

        public void SetPosition(Vector2 _position) {
            position = new Vector2(position.X + GameObject.position.X, position.Y + GameObject.position.Y);
        }

        public override void Start(){ }

        public override void Update() { }

        public override void Input(ConsoleKeyInfo _key) {
            
        }

        public override void Draw() {
            Renderer.instence.DrawOnBuffer(GameObject.position, new char[,] {{icon}});
        }
    }
}