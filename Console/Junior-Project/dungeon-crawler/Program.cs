using System;
using System;
using System.Text;
using System.Numerics; 

class Program
{
    public static Vector2 playerPos = new Vector2(5,5);

    public static void Main(string[] arg) {
        char[,] map = DrawRoom(new Vector2(20, 10));

        map[(int)playerPos.Y, (int)playerPos.X] ='@';

        foreach(char mapChar in map) {
            Console.Write(mapChar);
        }
    }

    public static char[,] DrawRoom(Vector2 size)  {
        int width = (int)size.X + 1;
        int height = (int)size.Y;

        char[,] map = new char[height, width];

        for (int y = 0; y < height; y++)  {
            for (int x = 0; x < width; x++)  {
                if (y == 0 || y == height - 1 || x == 0 || x == width - 2)  {
                    map[y, x] = '#';
                }  else  {
                    map[y, x] = '.';
                }
            }
            map[y, width - 1] = '\n';
        }

        return map;
    }
}


