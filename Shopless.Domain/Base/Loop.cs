using System;
using System.Collections.Generic;
using System.Text;

namespace Shopless.Base
{
    public static class Loop
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);

            return source;
        }
    }
}
