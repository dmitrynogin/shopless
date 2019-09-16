using Shopless.Base;
using System;
using System.Collections.Generic;
using static System.String;

namespace Shopless.Products
{
    public class Slug : ValueObject<Slug>
    {
        public static Slug New(string text) =>
            new Slug(text
                .Trim()
                .Replace(" ", "-")
                .ToLowerInvariant());

        public static Slug Parse(string text) =>
            TryParse(text, out var slug) ? slug : throw new FormatException("Malformed slug.");

        public static bool TryParse(string text, out Slug slug) =>
            (slug = IsNullOrWhiteSpace(text) ? null : new Slug(text)) != null;

        public Slug(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public override string ToString() => Text;

        protected override IEnumerable<object> EqualityCheckAttributes =>
            new object[] { Text };
    }
}
