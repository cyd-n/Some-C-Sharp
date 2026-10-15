using System.Numerics;
using dungeon_crawler.Engine.Components;
using dungeon_crawler.Engine.Grid;
using dungeon_crawler.Game;

namespace dungeon_crawler.Engine.Components
{
    public class MapAsciiComponent : RpgComponent
    {
        public GridObj tiles { get; private set; }
        public Vector2 position { get; set; } = new Vector2(0, 0);
        private Vector2 size { get; set; } = new Vector2(0, 0);
        private int layer = 0;
        public string path = "";
        public int sortingOrder { get; set; }
        public bool isTrigger { get; set; } = false;

        // Which tiles can be walked on ('.' floor and ' ' empty)
        public HashSet<char> walkableTiles = new HashSet<char> { ' ', '.' };

        public void SetMap(string _path, Vector2 _size, int _layer = 0) {
            path = Path.Combine(Directory.GetCurrentDirectory(), "Game/", _path);
            size = _size;
            layer = _layer;

            string spriteString = File.ReadAllText(path);

            spriteString = spriteString.Replace('\n', ' ');
            spriteString = spriteString.Replace('\r', ' ');
            spriteString = spriteString.Replace('\t', ' ');


            List<Cell> cells = new List<Cell>();

            foreach(char c in spriteString) {
                cells.Add(new Cell(c));
            }

            tiles = new GridObj(cells.ToArray(), size, layer);
        }

        public override void Awake() { }

        public override void Start() {
            // Auto-register with the layer manager
            MapLayerManagerComponent.instance?.RegisterMap(this);
        }

        public override void Update() { }
        public override void Input(ConsoleKeyInfo _key) { }

        public override void Draw() {
            Renderer.instence.DrawOnBuffer(position, tiles.ToCharArray());
        }

        public bool IsWalkable(Vector2 _worldPosition) {
            if (isTrigger)
                return true;

            if (tiles == null)
                return true;

            // Convert world position to local tile position
            int x = (int)(_worldPosition.X - position.X);
            int y = (int)(_worldPosition.Y - position.Y);

            char[,] tileChars = tiles.ToCharArray();

            // Outside the map = solid, prevents walking off-screen
            if (x < 0 || y < 0 ||
                x >= tileChars.GetLength(1) ||
                y >= tileChars.GetLength(0))
                return false;

            return walkableTiles.Contains(tileChars[y, x]);
        }
    }
}