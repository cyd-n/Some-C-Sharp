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

        public bool RemoveComponent<T>(T component) where T : RpgComponent {
            if (!components.Remove(component))
                return false;

            component.OnDeletion();
            component.gameObject = null; 
            return true;
        }

        public void SetState(LifeCycleState _funcition) {
            switch (_funcition) {
                case LifeCycleState.ON_CREATION:  OnCreation();   break;   
                case LifeCycleState.AWAKE:        Awake();        break;   
                case LifeCycleState.START:        Start();        break;   
                case LifeCycleState.UPDATE:       Update();       break;   
                case LifeCycleState.DRAW:         Draw();         break;   
                case LifeCycleState.ON_DELETION:  OnDeletion();   break;   
            }
        }

        public void SetState(ConsoleKeyInfo _key) {
            Input(_key); 
        }

        private bool OnDeletion() {
            foreach(RpgComponent rpgComp in components) {
                rpgComp.OnDeletion();
                rpgComp.gameObject = null;
            }

            components.Clear();
            active = false;
            
            return true;
        }

        private void OnCreation() {
            foreach(RpgComponent rpgComp in components) {
                rpgComp.OnGameObjCreation();
            }
        }

        private void Awake() {
            if (!active)
                return;

            foreach(RpgComponent rpgComp in components) {
                rpgComp.Awake();
            }
        }

        private void Start() {
            if (!active)
                return;

            foreach(RpgComponent rpgComp in components) {
                rpgComp.Start();
            }
        }

        private void Update() {
            if (!active)
                return;

            foreach(RpgComponent rpgComp in components) {
                rpgComp.Update();
            }
        }

        private void Input(ConsoleKeyInfo _key) {
            if (!active)
                return;

            foreach(RpgComponent rpgComp in components) {
                rpgComp.Input(_key);
            }
        }

        private void Draw() {
            if (!active)
                return;

            foreach(RpgComponent rpgComp in components) {
                rpgComp.Draw();
            }
        }
    }
}