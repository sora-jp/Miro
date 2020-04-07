using System;

namespace Miro.Core.Modules
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class EngineModuleAttribute : Attribute
    {
        public EngineModuleAttribute() { }
    }
}