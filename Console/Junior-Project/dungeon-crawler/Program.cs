using System;
using System.Text;
using System.Numerics;
using dungeon_crawler;

class Program
{
    public static Player player = new Player("user", '@', new Vector2(5,5), 100, 13);

    public static Enemy snake = new Enemy("Snake", 's', new Vector2(9,5), 30, 3);

    public static void Main(string[] arg) {
        while(true) {
            Console.Clear();

            char[,] map = DrawRoom(new Vector2(20, 10));

            map[(int)player.pos.Y, (int)player.pos.X] = player.icon;
            map[(int)snake.pos.Y, (int)snake.pos.X] = snake.icon;

            foreach(char mapChar in map) {
                Console.Write(mapChar);
            }

            player.Move(map);
            snake.Move(map);
            
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


