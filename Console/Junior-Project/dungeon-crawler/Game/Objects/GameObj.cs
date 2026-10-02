using System.ComponentModel;
using System.Numerics;
using System.Reflection.Metadata;

namespace dungeon_crawler.Game.GameObj {
    public class GameObj {
        public string name {get; set;}
        public string tag {get; set;}

        public Vector2 position = new Vector2(0, 0);

        public bool active {get;  set;} = true;

        public List<RpgComponent> components = new List<RpgComponent>();

        public GameObj(string _name) {
            name = _name;
        }

        public T AddComponent<T>(T _component) where T : RpgComponent {
            _component.GameObject = this;
            components.Add(_component);

            return _component;
        }

        public T? GetComponent<T>() where T : RpgComponent {
            foreach(RpgComponent rpgComp in components) {
                if(rpgComp is T wanted) {
                    return wanted;
                }
            }

            return null;
        }

        public void Start() {
            foreach(RpgComponent rpgComp in components) {
                rpgComp.Start();
            }
        }

        public void Update() {
            if (!active)
                return;

            foreach(RpgComponent rpgComp in components) {
                rpgComp.Update();
            }
        }

        public void Draw() {
            if (!active)
                return;

            foreach(RpgComponent rpgComp in components) {
                rpgComp.Draw();
            }
        }
    }
}