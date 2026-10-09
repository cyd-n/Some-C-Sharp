using System.Numerics;

namespace dungeon_crawler.Engine.Grid {
   public class GridObj {
        private Vector2 size;

        public Cell[] cells { get; private set; }
        public int layer { get; private set; }

        public GridObj(Cell[] _cells, Vector2 _size, int _layer = 0) {
            cells = _cells;
            size = _size;
            layer = _layer;
        }

        public char[,] ToCharArray() {
            int width = (int)size.X;
            int height = (int)size.Y;

            char[,] gridArray = new char[height, width];

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    int index = y * width + x;

                    gridArray[y, x] = cells[index].ToChar();
                }
            }

            return gridArray;
        }
    }
}