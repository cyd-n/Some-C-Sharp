using System.Numerics;
using dungeon_crawler.Engine.Components.Objects;

namespace dungeon_crawler.Engine.Components
{
    public class MapAsciiComponent : RpgComponent
    {
        // Properties
        // need Color 
        public char[,] map { get; private set; }
        public Vector2 position { get; set; }
        public int sortingOrder { get; set; }
        public bool enabled { get; set; }

        // Methods
        public MapAsciiComponent() {
            //position = GameObject.position;
        }

        public void SetMap(char[,] _map) {
            map = _map;
        }

        public override void Start(){ }

        public override void Update() { }

        public override void Input(ConsoleKeyInfo _key) { }

        public override void Draw() {
            Renderer.instence.DrawOnBuffer(position, map);
        }
    }
}