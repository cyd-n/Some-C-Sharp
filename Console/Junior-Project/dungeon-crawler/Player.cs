using System.Numerics; 

namespace dungeon_crawler
{
    public class Player : Charater {
        public static Player instance {get; private set;}

        public Player(string _name, char _icon, Vector2 _pos, float _hp, float _damage) : base(_name, _icon, _pos, _hp, _damage) {
            if (instance == null) { instance = this; }
        }

        public override void Move(char[,] _map) {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if(keyInfo.Key == ConsoleKey.W || keyInfo.Key == ConsoleKey.UpArrow) {
                if (ValidateMovement(_map[(int)pos.Y - 1, (int)pos.X])) { pos.Y--; }
            } else if(keyInfo.Key == ConsoleKey.S || keyInfo.Key == ConsoleKey.DownArrow) {
                if (ValidateMovement(_map[(int)pos.Y + 1, (int)pos.X])) { pos.Y++; }
            } else if(keyInfo.Key == ConsoleKey.A || keyInfo.Key == ConsoleKey.LeftArrow) {
                if (ValidateMovement(_map[(int)pos.Y, (int)pos.X - 1])) { pos.X--; }
            } else if(keyInfo.Key == ConsoleKey.D || keyInfo.Key == ConsoleKey.RightArrow) {
                if (ValidateMovement(_map[(int)pos.Y, (int)pos.X + 1])) { pos.X++; }
            }
        }

        public override bool ValidateMovement(char _nextWalkPos) {
            if(_nextWalkPos == '#') {
                return false;
            } else if(_nextWalkPos == '.') {
                return true;
            } else if(_nextWalkPos == 's') { // cant can enemy icon yet
                Attack(null); // cant find enemy yet
                return false;
            }

            return true;
        }
    }
}