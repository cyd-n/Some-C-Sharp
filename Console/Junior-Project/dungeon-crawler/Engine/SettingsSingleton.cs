namespace dungeon_crawler.Engine {
    public class SettingsSingleton {
        private static SettingsSingleton instance;
        public bool isRuntimeActive = false;

        public static SettingsSingleton GetInstance() {
            if(instance == null) {
                instance = new SettingsSingleton();
            }

            return instance;
        }
        
    }
}