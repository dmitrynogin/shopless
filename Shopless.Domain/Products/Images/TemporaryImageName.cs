using Shopless.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using static System.IO.Path;

namespace Shopless.Products.Images
{
    public class TemporaryImageName : ValueObject<TemporaryImageName>
    {
        public static implicit operator string(TemporaryImageName name) => $"{name}";

        public static TemporaryImageName New(int number) =>
            new TemporaryImageName(number, Clock.Time());

        public static TemporaryImageName Parse(string text) =>
            GetExtension(text) == ".jpg" &&
            GetFileNameWithoutExtension(text).Split('-') is string[] p &&
            p.Length == 3 && p[0] == "tmp" &&
            int.TryParse(p[1], out var n) &&
            DateTime.TryParseExact(p[2], "yyyyMMddHHmmssfff", null, DateTimeStyles.None, out var t)
            ? new TemporaryImageName(n, t)
            : throw new FormatException("Invalid temporary image name.");

        public TemporaryImageName(int number, DateTime timestamp)
        {
            Number = number;
            Timestamp = timestamp;
        }

        public int Number { get; }
        public DateTime Timestamp { get; }

        public override string ToString() => $"tmp-{Number}-{Timestamp:yyyyMMddHHmmssfff}.jpg";

        protected override IEnumerable<object> EqualityCheckAttributes =>
            new object[] { Number, Timestamp };
    }
}
