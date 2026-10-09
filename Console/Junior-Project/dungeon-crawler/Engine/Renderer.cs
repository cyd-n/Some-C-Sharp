using System.Drawing;
using System.Numerics;

namespace dungeon_crawler.Engine {
    public class Renderer {
        public static Renderer instence; 

        int witdh = 50, height = 50;
        char[,] buffer = new char[1,1];

        public void ClearBuffer() {
            for (int y = 0; y < height; y++)
                for (int x = 0; x < witdh; x++)
                    buffer[y, x] = ' ';
        }

        public Renderer(int _witdh = 25, int _height = 50) {
            if(instence == null) {
                instence = this;
            }

            witdh = _witdh;
            height = _height;

            buffer = new char[height, witdh];
        }

        public void DrawOnBuffer(Vector2 _pos, char[,] sprite) {
            int posX = (int)_pos.X;
            int posY = (int)_pos.Y;

            int spriteHeight = sprite.GetLength(0);
            int spriteWidth = sprite.GetLength(1);

            for (int y = 0; y < spriteHeight; y++) {
                for (int x = 0; x < spriteWidth; x++) {
                    int bufferY = posY + y;
                    int bufferX = posX + x;

                    if (bufferY >= 0 && bufferY < height && bufferX >= 0 && bufferX < witdh){
                        if(sprite[y, x] != ' ') {
                            buffer[bufferY, bufferX] = sprite[y, x];
                        }
                    }
                }
            }
        }

        public void DrawOnScreen() {
            string screnBuffer = "";

            for(int y = 0; y < height; y++) {
                for(int x = 0; x < witdh; x++) {
                    screnBuffer += buffer[y,x];
                }

                screnBuffer += '\n';
            }

            Console.Clear();

            Console.WriteLine(screnBuffer);
        }
    }
}