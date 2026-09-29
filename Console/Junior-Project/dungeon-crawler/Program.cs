using System;
using dungeon_crawler;

class Program
{
    public static void Main(string[] arg) {
        Console.WriteLine(DrawRoom(new Vector2(20, 10)));
    }

    public static string DrawRoom(Vector2 _size) {
        string field = "";
        for(int y = 0; y < _size.y; y++) {
            for(int x = 0; x < _size.x; x++) {
                if (y == 0 || y == _size.y - 1 || x == 0 || x == _size.x - 1) {
                    field += "#";
                } else {
                    field += ".";
                }
            }
            field += "\n";
        }

        return field;
    }
}
