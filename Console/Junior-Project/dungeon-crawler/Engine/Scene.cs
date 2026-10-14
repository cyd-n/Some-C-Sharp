using System.ComponentModel;
using dungeon_crawler.Engine.Objects;

namespace dungeon_crawler.Engine {
    public class Scene {
        // state for created, init, running, paused, unloaded
        public string name {get;}
        public List<GameObj> objs = new List<GameObj>();

        public Scene(string _name) {
            name =_name;
        }

        public void Start() {
            foreach(var obj in objs) {
                obj.SetState(LifeCycleState.ON_CREATION);
                obj.SetState(LifeCycleState.AWAKE);
                obj.SetState(LifeCycleState.START);
            }
        }

        public void AddObject(GameObj _gameObj) {
            if(objs.Contains(_gameObj))
                return;

            objs.Add(_gameObj);

            if(SettingsSingleton.GetInstance().isRuntimeActive) {
                _gameObj.SetState(LifeCycleState.ON_CREATION);
                _gameObj.SetState(LifeCycleState.AWAKE);
                _gameObj.SetState(LifeCycleState.START);
            }
        }

        public void RemoveObject(GameObj _gameObj) {
            if (objs.Contains(_gameObj)) {
                _gameObj.SetState(LifeCycleState.ON_DELETION);
                objs.Remove(_gameObj);
            }
        }

        public void Update() {
            foreach(var obj in objs) {
                obj.SetState(LifeCycleState.UPDATE);
            }
        }

        public void Draw() {
            foreach(var obj in objs) {
                obj.SetState(LifeCycleState.DRAW);
            }
        }

        public void InputHandle() {
            InputManager.instence.WaitForInput(objs);
        }
    }
}