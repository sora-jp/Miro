using System;
using System.Diagnostics.CodeAnalysis;

namespace Miro.Core.Pooling
{
    [SuppressMessage("ReSharper", "StaticMemberInGenericType")]
    public static class ObjectPool<T> where T : IPoolable
    {
        static T[] _pool = new T[64];
        static int _newIdx = -1;

        public static ref T Create()
        {
            for (var i = 0; i < _pool.Length; i++)
            {
                if (!_pool[i].InUse())
                {
                    _pool[i].Reset();
                    _pool[i].Create();

                    return ref _pool[i];
                }
            }

            if (++_newIdx >= _pool.Length) Array.Resize(ref _pool, _pool.Length << 1);

            var obj = (T)Activator.CreateInstance(typeof(T), true);
            _pool[_newIdx] = obj;

            obj.Reset();
            obj.Create();
            
            return ref _pool[_newIdx];
        }

        public static void Destroy(ref T obj)
        {
            obj.Destroy();
        }
    }
}