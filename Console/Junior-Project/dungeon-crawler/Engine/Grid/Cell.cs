using System.Numerics;

namespace dungeon_crawler.Engine.Grid {
    public class Cell {
        public char charater;
        private Vector2 position;

        public Cell(char _charater, Vector2 _position) {
            charater = _charater;
            position = _position;
        }
    }
}