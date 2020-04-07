using System;

namespace Miro.Core.Modules
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class ModuleDependencyAttribute : Attribute
    {
        public Type Dependency { get; }

        public ModuleDependencyAttribute(Type dependency)
        {
            Dependency = dependency;
        }
    }
}