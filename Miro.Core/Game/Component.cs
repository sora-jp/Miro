using System.Linq;
using Fasterflect;
using Miro.Core.Pooling;

namespace Miro.Core
{
    public class Component : Poolable
    {
        internal static ref T CreateComponent<T>() where T : Component
        {
            return ref ObjectPool<T>.Create();
        }

        internal static void ReleaseComponent<T>(T component) where T : Component
        {
            ObjectPool<T>.Destroy(ref component);
        }
    }
}
