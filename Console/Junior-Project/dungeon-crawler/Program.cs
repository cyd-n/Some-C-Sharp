using System;
using System.Text;
using System.Numerics;
using dungeon_crawler;

class Program
{
    public static Charater player = new Charater("user", '@', new Vector2(5,5));

    public static void Main(string[] arg) {
        while(true) {
            Console.Clear();

            char[,] map = DrawRoom(new Vector2(20, 10));

            map[(int)player.pos.Y, (int)player.pos.X] = player.icon;

            foreach(char mapChar in map) {
                Console.Write(mapChar);
            }

            MovePlayer(map);
            
        }
    }

    public static void MovePlayer(char[,] _map) {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        if(keyInfo.Key == ConsoleKey.W || keyInfo.Key == ConsoleKey.UpArrow) {
            if (_map[(int)player.pos.Y - 1, (int)player.pos.X] != '#') { player.pos.Y--; }
        } else if(keyInfo.Key == ConsoleKey.S || keyInfo.Key == ConsoleKey.DownArrow) {
            if (_map[(int)player.pos.Y + 1, (int)player.pos.X] != '#') { player.pos.Y++; }
        } else if(keyInfo.Key == ConsoleKey.A || keyInfo.Key == ConsoleKey.LeftArrow) {
            if (_map[(int)player.pos.Y, (int)player.pos.X - 1] != '#') { player.pos.X--; }
        } else if(keyInfo.Key == ConsoleKey.D || keyInfo.Key == ConsoleKey.RightArrow) {
            if (_map[(int)player.pos.Y, (int)player.pos.X + 1] != '#') { player.pos.X++; }
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


