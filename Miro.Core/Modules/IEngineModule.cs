using System;
using System.Collections.Generic;
using System.Text;

namespace Miro.Core.Modules
{
    public interface IEngineModule
    {
        Type[] GetDependencies();
        void Init();
        void Update();
        void Destroy();
    }
}
