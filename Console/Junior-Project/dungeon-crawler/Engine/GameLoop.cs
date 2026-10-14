using System.Numerics;

namespace dungeon_crawler.Engine {
    public class GameLoop {
        private static GameLoop instance;
        private Scene scene = new Scene("test");

        public static GameLoop GetInstance() {
            if (instance == null) {
                instance = new GameLoop();
            }

            return instance;
        }
        
        // Set the scene 
        public void SetScene(Scene _scene) {
            scene = _scene;
        }

        // load the data 
        private void LoadData() {
            // Later make that the data from json
        }

        // start the start func
        public void Start() {
            LoadData(); // late this will become asyncc but it is here now only yo give shape the the project

            SettingsSingleton.GetInstance().isRuntimeActive = true;

            scene.Start();
        }

        // run the gameloop
        private void Run() {
            while (SettingsSingleton.GetInstance().isRuntimeActive) {
                scene.Update();
                scene.Draw();
                scene.InputHandle();
            }

            ShutDown();
        }

        // Shut Down
        public void ShutDown() {
            // later here come the code that happens on shutdown
        }
    }
}
