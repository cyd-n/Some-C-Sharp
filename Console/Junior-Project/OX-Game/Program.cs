using System;

class Program {
    private static char[,] gameField =  {{' ', ' ', ' '}, {' ', ' ', ' '}, {' ', ' ', ' '}};
    private static bool running = true, playerTurn = true;

    public static void Main(string[] arg) {
        while (running) {
            PlayerTurn();
            DrawField();
            playerTurn = true;
        }
    }

    private static void PlayerTurn() {
        InitScreen();

        int x = 0;
        int y = 0;

        while(playerTurn){
            ConsoleKeyInfo info = Console.ReadKey();

            if(info.Key == ConsoleKey.D || info.Key == ConsoleKey.RightArrow) x = (x >= 2) ? 0 : x += 1;
            else if(info.Key == ConsoleKey.A || info.Key == ConsoleKey.LeftArrow) x = (x <= 0) ? 2 : x -= 1;
            else if(info.Key == ConsoleKey.S || info.Key == ConsoleKey.DownArrow) y = (y >= 2) ? 0 : y += 1;
            else if(info.Key == ConsoleKey.W || info.Key == ConsoleKey.UpArrow) y = (y <= 0) ? 2 : y -= 1;
            else if(info.Key == ConsoleKey.Enter && gameField[y,x] == ' ') {
                gameField[y,x] = 'X';
                playerTurn = false;
                return;
            }

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
