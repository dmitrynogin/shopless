using Shopless.Base;
using System;
using System.Collections.Generic;

namespace Shopless.Products
{
    public class ProductName : ValueObject<ProductName>
    {
        public static ProductName New(string text) =>
            new ProductName(text.Trim(), Slug.New(text));

        public ProductName(string text, Slug slug)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Slug = slug ?? throw new ArgumentNullException(nameof(slug));
        }

        public string Text { get; }
        public Slug Slug { get; }

        protected override IEnumerable<object> EqualityCheckAttributes => 
            new object[] { Slug };
    }
}
