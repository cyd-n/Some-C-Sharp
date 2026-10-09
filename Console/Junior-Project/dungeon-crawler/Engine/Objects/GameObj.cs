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
            _component.OnCreation();

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

        public T RemoveComponent<T>(T _component) where T : RpgComponent {
            bool isSuccesfull = components.Remove(_component);
            if(isSuccesfull)
                return null;

            _component.OnDeletion();

            return _component;
        }

        public void OnCreation() {
            foreach(RpgComponent rpgComp in components) {
                rpgComp.OnGameObjCreation();
            }
        }

        public void Awake() {
            foreach(RpgComponent rpgComp in components) {
                rpgComp.Awake();
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