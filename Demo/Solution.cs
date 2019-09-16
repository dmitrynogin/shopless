 
 
 
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace Shopless
{
    public static class Solution 
    {
        static IEnumerable<string> AssemblyNames => new[] {
            "Shopless.Domain", "Shopless.Disk", "Shopless.Autofac", "Shopless.Tests", "Demo"
        };

        public static IEnumerable<Assembly> Assemblies => AssemblyNames
            .Select(Load)
            .Where(a => a != null);

        [DebuggerHidden]
        static Assembly Load(string assemblyName)
        {
            try
            {
                return Assembly.Load(new AssemblyName(assemblyName));
            }
            catch
            {
                return null;
            }
        }
    }
}

