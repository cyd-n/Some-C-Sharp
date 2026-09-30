using System.Numerics; 

namespace dungeon_crawler
{
    public class Enemy : Charater {
        public Enemy(string _name, char _icon, Vector2 _pos, float _hp, float _damage) : base(_name, _icon, _pos, _hp, _damage) {

        }

        public override void Move(char[,] _map) {
            Random rand = new Random();
            int dire = rand.Next(0,5);

            switch (dire) {
                case 0:
                    if(ValidateMovement(_map[(int)pos.Y - 1, (int)pos.X])) { pos.Y--; }
                    break;
                case 1:
                    if(ValidateMovement(_map[(int)pos.X - 1, (int)pos.X])) { pos.X--; }
                    break;
                case 2:
                    if(ValidateMovement(_map[(int)pos.Y + 1, (int)pos.X])) { pos.Y++; }
                    break;
                case 3:
                    if(ValidateMovement(_map[(int)pos.X + 1, (int)pos.X])) { pos.X++; }
                    break;
                case 4:
                    break;
            }
        }

        public override bool ValidateMovement(char _nextWalkPos) {
            if(_nextWalkPos == '#') {
                return false;
            } else if(_nextWalkPos == '.') {
                return true;
            } else if(_nextWalkPos == '@') { // cant can player icon yet
                Attack(null); // cant find player yet
                return false;
            }

            return true;
        }
    }
}