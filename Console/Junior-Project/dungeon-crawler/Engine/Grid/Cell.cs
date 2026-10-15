using System.Numerics;

namespace dungeon_crawler.Engine.Grid {
    public class Cell {
        public char charater;
        private Vector2 position;

        public Cell(char _charater) {
            charater = _charater;
        }

        public void SetPosition(Vector2 _pos) {
            position = _pos;
        }

        public char ToChar() {
            return charater;
        }
    }
}