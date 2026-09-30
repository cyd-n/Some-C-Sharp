using System.Numerics; 

namespace dungeon_crawler
{
    public class Charater {
        public string name {get; private set;}
        public char icon {get; private set;}
        public float hpPoint {get; private set;}
        public Vector2 pos;

        public Charater(string _name, char _icon, Vector2 _pos) {
            name = _name;
            icon = _icon;
            pos = _pos;
        }

        public void TakeDamage(int _damage) {
            hpPoint -= _damage;
        }
    }
}