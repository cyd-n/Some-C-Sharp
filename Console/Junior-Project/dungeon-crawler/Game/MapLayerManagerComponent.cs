using System.Numerics;
using dungeon_crawler.Engine.Components;

namespace dungeon_crawler.Game {
    public class MapLayerManagerComponent : RpgComponent {
        public static MapLayerManagerComponent instance;

        public List<MapAsciiComponent> mapOrderList = new List<MapAsciiComponent>();

        public MapLayerManagerComponent() {
            
        }

        public void RegisterMap(MapAsciiComponent _map) {
            if (!mapOrderList.Contains(_map)) {
                mapOrderList.Add(_map);
                mapOrderList.Sort((a, b) => a.sortingOrder.CompareTo(b.sortingOrder));
            }
        }

        public bool IsWalkable(Vector2 _position) {
            foreach (MapAsciiComponent map in mapOrderList) {
                if (!map.IsWalkable(_position))
                    return false;
            }
            return true;
        }

        public override void Awake() {
            if (instance == null)
                instance = this;
        }

        public override void Start() { }

        public override void Update() { }

        public override void Input(ConsoleKeyInfo _key) { }

        public override void Draw() { }
    }
}