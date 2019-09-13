using Shopless.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Shopless.IO
{
    public sealed class Connection : ValueObject<Connection>
    {
        public static implicit operator Connection(string @string) => Parse(@string);
        public static Connection Parse(string @string) => new Connection(@string);            

        Connection(string @string)
        {
            Values = @string.Split(';')
               .Select(nv => nv.Split('='))
               .ToDictionary(nv => nv[0].Trim(), nv => nv[1].Trim());
        }

        IReadOnlyDictionary<string, string> Values { get; }
        
        public T Get<T>(string name, T @default = default(T)) =>
            Values.TryGetValue(name, out var value) 
            ? (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value)
            : @default;

        public T Open<T>() => (T)Activator.CreateInstance(
            Type.GetType(Get<string>("Type")), this);

        protected override IEnumerable<object> EqualityCheckAttributes => 
            new object[] { ToString() };

        public override string ToString() => 
            string.Join(";", from nv in Values
                             select $"{nv.Key}={nv.Value}");
    }
}
