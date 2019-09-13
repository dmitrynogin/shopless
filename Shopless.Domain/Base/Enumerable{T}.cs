using System.Collections;
using System.Collections.Generic;

namespace Shopless.Base
{
    public abstract class Enumerable<T> : IEnumerable<T>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public abstract IEnumerator<T> GetEnumerator();
    }
}
