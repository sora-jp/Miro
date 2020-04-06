using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Shouldly;

namespace Miro.Core.Modules
{
    public static class ModuleDependencyResolver
    {
        public static IEngineModule[] Resolve(IEngineModule[] modules)
        {
            var resolved = new HashSet<Type>();
            var input = modules;
            var output = new List<IEngineModule>();

            foreach (var engineModule in modules)
            {
                ResolveTree(engineModule, input, output, resolved);
            }

            output.Count.ShouldBe(modules.Length);

            return output.ToArray();
        }

        static void ResolveTree(IEngineModule root, IEngineModule[] input, ICollection<IEngineModule> output, ISet<Type> resolved)
        {
            root.ShouldNotBeNull();

            if (resolved.Contains(root.GetType())) return;
            resolved.Add(root.GetType());

            foreach (var dependency in root.GetDependencies())
            {
                var actualDep = input.SingleOrDefault(m => m.GetType() == dependency);

                ResolveTree(actualDep, input, output, resolved);
            }

            output.Add(root);
        }
    }
}
