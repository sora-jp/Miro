using System;
using System.Collections.Generic;
using System.Linq;
using Fasterflect;
using JetBrains.Annotations;
using Miro.Core.Modules;

namespace Miro.Core
{
    public static class Runtime
    {
        static IEngineModule[] _modules;

        public static void Initialize()
        {
            _modules = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.Types())
                .Where(t => t.HasAttribute<EngineModuleAttribute>() && t.Implements<IEngineModule>())
                .Select(t => (IEngineModule)Activator.CreateInstance(t))
                .ToArray();

            _modules = ModuleDependencyResolver.Resolve(_modules);

            EachModule(m => m.Init());
        }

        public static void EnterLoop()
        {
            while (true)
            {
                EachModule(m => m.Update());
            }
        }

        public static void DestroyRuntime()
        {
            EachModule(m => m.Destroy());
            _modules = null;
        }

        static void EachModule([NotNull] Action<IEngineModule> action)
        {
            foreach (var engineModule in _modules)
            {
                action(engineModule);
            }
        }
    }
}
