using System;
using System.Collections.Generic;
using System.Text;

namespace Miro.Core.Modules
{
    internal interface IEngineModule
    {
        IEnumerable<Type> GetDependencies();
        void Init();
        void Update();
        void Destroy();
    }
}
