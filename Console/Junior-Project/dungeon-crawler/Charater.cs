using System.Numerics; 

namespace dungeon_crawler
{
    public class Charater {
        public string name {get; private set;}
        public char icon {get; private set;}
        public float hpPoints {get; private set;}
        public float damagePoints {get; private set;}
        public Vector2 pos;

        public Charater(string _name, char _icon, Vector2 _pos, float _hp, float _damage) {
            name = _name;
            icon = _icon;
            pos = _pos;
            hpPoints =_hp;
            damagePoints = _damage;
        }

        public virtual void Move(char[,] _map) {
            
        }

        public virtual bool ValidateMovement(char _nextWalkPos) {
            return false;
        }

        public void Attack(Charater _char) {
            _char.TakeDamage(damagePoints);
        }

        public void TakeDamage(float _damage) {
            hpPoints -= _damage;

            if(hpPoints < 0) {
                Died();
            }
        }

        public void Died() {
            icon = '.';
        }
    }
}