using System;
using System.Collections.Generic;
using System.Linq;
using Fasterflect;

namespace Miro.Core.Modules
{
    public class EngineModule : IEngineModule
    {
        public IEnumerable<Type> GetDependencies() => GetType().Attributes(typeof(ModuleDependencyAttribute)).Cast<ModuleDependencyAttribute>().Select(a => a.Dependency);

        public virtual void Init() { }
        public virtual void Update() { }
        public virtual void Destroy() { }
    }
}