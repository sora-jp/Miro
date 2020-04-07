using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fasterflect;

namespace Miro.Core.Reflection
{
    public static class FastInvoke
    {
        public static void Invoke(object obj, string methodName, params object[] args)
        {
            obj.GetType().CallMethod(methodName, Flags.InstanceAnyDeclaredOnly, args); 
        }
    }
}
