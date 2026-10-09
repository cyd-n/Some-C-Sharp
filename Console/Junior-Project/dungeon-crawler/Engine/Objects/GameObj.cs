using System.ComponentModel;
using System.Numerics;
using System.Reflection.Metadata;
using dungeon_crawler.Engine.Objects;
using dungeon_crawler.Engine.Components;

namespace dungeon_crawler.Engine.Objects {
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
            _component.gameObject = this;
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

        public void Await() {
            foreach(RpgComponent rpgComp in components) {
                rpgComp.Await();
            }
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

        public void Input(ConsoleKeyInfo _key) {
            if (!active)
                return;

            foreach(RpgComponent rpgComp in components) {
                rpgComp.Input(_key);
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