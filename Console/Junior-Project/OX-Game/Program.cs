using System;

class Program {
    public static char[,] gameField =  {{' ', ' ', ' '}, {' ', ' ', ' '}, {' ', ' ', ' '}};

    public static void Main(string[] arg) {
        DrawField();
        
        PlayerTurn();
        
    }

    private static void PlayerTurn() {
        InitScreen();

        int x = 0;
        int y = 0;

        while(true){
            ConsoleKeyInfo info = Console.ReadKey();

            if(info.Key == ConsoleKey.D) x = (x >= 2) ? 0 : x += 1;
            else if(info.Key == ConsoleKey.A) x = (x <= 0) ? 2 : x -= 1;
            else if(info.Key == ConsoleKey.S) y = (y >= 2) ? 0 : y += 1;
            else if(info.Key == ConsoleKey.W) y = (y <= 0) ? 2 : y -= 1;

            Console.Write("X: " + x + ",Y: " + y);

            char oldTile = gameField[y,x];
            gameField[y,x] = '▓';

            DrawField();

            gameField[y,x] = oldTile;
        }
    }

    private static void InitScreen() {
        char oldTile = gameField[0,0];
        gameField[0,0] = '▓';

        DrawField();

        gameField[0,0] = oldTile;
    }

    private static void DrawField() {
        Console.Clear();

        Console.WriteLine("╔═╦═╦═╗");
        Console.WriteLine($"║{gameField[0,0]}║{gameField[0,1]}║{gameField[0,2]}║");
        Console.WriteLine("╠═╬═╬═╣");
        Console.WriteLine($"║{gameField[1,0]}║{gameField[1,1]}║{gameField[1,2]}║");
        Console.WriteLine("╠═╬═╬═╣");
        Console.WriteLine($"║{gameField[2,0]}║{gameField[2,1]}║{gameField[2,2]}║");
        Console.WriteLine("╚═╩═╩═╝");
    }
}
