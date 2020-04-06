using System;
using System.Linq;
using Fasterflect;

namespace Miro.Core.Pooling
{
    public class Poolable : IPoolable, IDisposable
    {
        bool m_disposed;

        public bool InUse() => !m_disposed;

        void IPoolable.Create()
        {
            m_disposed = false;
        }

        void IPoolable.Destroy()
        {
            m_disposed = true;
        }

        // TODO: Check perf, shouldn't be a problem tho
        public virtual void Reset()
        {
            GetType().Fields(Flags.InstanceAnyVisibility).AsParallel().Where(f => f.IsWritable()).ForAll(f => f.Set(this, f.GetRawConstantValue()));
        }

        public virtual void Dispose() => m_disposed = true;
    }
}