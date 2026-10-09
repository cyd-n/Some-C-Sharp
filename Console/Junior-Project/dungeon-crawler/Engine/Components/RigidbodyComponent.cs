using System.Numerics;
using dungeon_crawler.Engine.Objects;
using dungeon_crawler.Game;

namespace dungeon_crawler.Engine.Components {
    public class RigidbodyComponent : RpgComponent {
        public bool isTrigger = false;

        // All rigidbodies, for object-vs-object collision
        public static List<RigidbodyComponent> allBodies = new List<RigidbodyComponent>();

        public override void Await(){ }

        public override void Start() {
            if (!allBodies.Contains(this))
                allBodies.Add(this);
        }

        public bool CanMoveTo(Vector2 _target) {
            // 1. Map collision
            if (MapLayerManagerComponent.instance != null &&
                !MapLayerManagerComponent.instance.IsWalkable(_target))
                return false;

            // 2. Other rigidbodies
            foreach (RigidbodyComponent body in allBodies) {
                if (body == this || body.isTrigger || body.gameObject == null)
                    continue;
                if (!body.gameObject.active)
                    continue;
                if (body.gameObject.position == _target)
                    return false;
            }

            return true;
        }

        public bool Move(Vector2 _direction) {
            Vector2 target = gameObject.position + _direction;

            if (CanMoveTo(target)) {
                gameObject.position = target;
                return true;
            }
            return false;
        }

        public override void Update() { }
        public override void Input(ConsoleKeyInfo _key) { }
        public override void Draw() { }
    }
}