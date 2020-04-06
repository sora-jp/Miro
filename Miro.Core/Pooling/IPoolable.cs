using System.Collections.Generic;
using System.Text;

namespace Miro.Core.Pooling
{
    public interface IPoolable
    {
        bool InUse();
        void Create();
        void Destroy();
        void Reset();
    }
}
