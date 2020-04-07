using Miro.Core.Pooling;

namespace Miro.Core
{
    public class Component : Poolable
    {
        public GameObject GameObject { get; set; }

        internal static T CreateComponent<T>(GameObject parent) where T : Component
        {
            var component = ObjectPool<T>.Create();
            component.GameObject = parent;
            return component;
        }

        internal static void ReleaseComponent<T>(T component) where T : Component
        {
            ObjectPool<T>.Destroy(ref component);
        }

        protected override void OnDestroyed()
        {
            GameObject = null;
        }
    }
}
