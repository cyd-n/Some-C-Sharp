using System;

public enum GameState {
    NONE,
    PLAYER,
    NPC
}

class Program {
    private static GameState turn;
    private static char[,] gameField =  {{' ', ' ', ' '}, {' ', ' ', ' '}, {' ', ' ', ' '}};
    private static Random rnd = new Random();
    private static int turns = 0;
    private static bool running = true;
    

    public static void Main(string[] arg) {
        turn = GameState.PLAYER;

        while (running) {
            PlayerTurn();
            DrawField();
            Console.WriteLine($"{turn}");

            NPCTurn();
            DrawField();
            System.Threading.Thread.Sleep(100);
        }
    }

    private static void PlayerTurn() {
        InitScreen();

        int x = 0;
        int y = 0;

        while(turn ==  GameState.PLAYER){
            ConsoleKeyInfo info = Console.ReadKey();

            if(info.Key == ConsoleKey.D || info.Key == ConsoleKey.RightArrow) x = (x >= 2) ? 0 : x += 1;
            else if(info.Key == ConsoleKey.A || info.Key == ConsoleKey.LeftArrow) x = (x <= 0) ? 2 : x -= 1;
            else if(info.Key == ConsoleKey.S || info.Key == ConsoleKey.DownArrow) y = (y >= 2) ? 0 : y += 1;
            else if(info.Key == ConsoleKey.W || info.Key == ConsoleKey.UpArrow) y = (y <= 0) ? 2 : y -= 1;
            else if(info.Key == ConsoleKey.Enter && gameField[y,x] == ' ') {
                gameField[y,x] = 'X';

                turn = GameState.NPC;
                turns++;

                WinCheck('X');

                return;
            }

            Console.Write("X: " + x + ",Y: " + y);

            char oldTile = gameField[y,x];

            gameField[y,x] = '▓';

            DrawField();

            gameField[y,x] = oldTile;
        }
    }

    private static void NPCTurn() {
        int x = 0;
        int y = 0;

        while(turn == GameState.NPC){
            x = rnd.Next(0,3);
            y = rnd.Next(0,3);

            if(gameField[y,x] == ' ') {
                gameField[y,x] = 'O';

                turn = GameState.PLAYER;
                turns++;

                WinCheck('O');

                return;
            }
        }
    }

    private static void WinCheck(char checkChar) {
        bool someoneWon = false;

        if(!someoneWon && gameField[0,0] == gameField[0,1] && gameField[0,1] == gameField[0,2]) {// Hor Row 1
            if(gameField[0,0] == checkChar) someoneWon = true;
        } else if(!someoneWon && gameField[1,0] == gameField[1,1] && gameField[1,1] == gameField[1,2]) { // Hor Row 2
            if(gameField[1,0] == checkChar) someoneWon = true;
        } else if (!someoneWon && gameField[2,0] == gameField[2,1] && gameField[2,1] == gameField[2,2]) { // Hor Row 3
            if(gameField[2,0] == checkChar) someoneWon = true;
        } else if(!someoneWon && gameField[0,0] == gameField[1,0] && gameField[1,0] == gameField[2,0]) { // Ver Col 1
            if(gameField[0,0] == checkChar) someoneWon = true;
        } else if(!someoneWon && gameField[0,1] == gameField[1,1] && gameField[1,1] == gameField[2,1]) { // Ver Col 2
            if(gameField[0,1] == checkChar) someoneWon = true;
        } else if (!someoneWon && gameField[0,2] == gameField[1,2] && gameField[1,2] == gameField[2,2]) { // Ver Col 3
            if(gameField[0,2] == checkChar) someoneWon = true;
        } else if(!someoneWon && gameField[0,0] == gameField[1,1] && gameField[1,1] == gameField[2,2]) { // Dialog 1
            if(gameField[0,0] == checkChar) someoneWon = true;
        } else if (!someoneWon && gameField[2,0] == gameField[1,1] && gameField[1,1] == gameField[0,2]) { // Dialog 2
            if(gameField[2,0] == checkChar) someoneWon = true;
        } 

        if(turns >= 9 && !someoneWon){ SetWin(null); }

        if(someoneWon) SetWin(checkChar == 'X');
        
    }

    private static void SetWin(bool? _playerWin) {
        running = false;

        Console.Clear();

        string winTxt = (_playerWin == true)? "You won, good Job" : (_playerWin == false) ?  "You Lose, Loser" : "A draw?";

        Console.WriteLine(winTxt);
        Console.ReadLine();
        
        Environment.Exit(0);
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
