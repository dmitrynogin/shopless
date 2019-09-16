using Shopless.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using static System.IO.Path;

namespace Shopless.Products.Images
{
    public class ProductImageName : ValueObject<ProductImageName>
    {
        public static implicit operator string(ProductImageName name) => $"{name}";

        public static ProductImageName New(TemporaryImageName imageName, ProductName productName) => 
            new ProductImageName(imageName.Number, imageName.Timestamp, productName.Slug);

        public static ProductImageName Parse(string text) =>
            GetExtension(text) == ".jpg" &&
            GetFileNameWithoutExtension(text).Split('-') is string[] p &&
            p.Length == 4 && p[0] == "tmp" &&
            int.TryParse(p[1], out var n) &&
            DateTime.TryParseExact(p[2], "yyyyMMddHHmmssfff", null, DateTimeStyles.None, out var t) &&
            Slug.TryParse(p[3], out var slug)             
            ? new ProductImageName(n, t, slug)
            : throw new FormatException("Invalid product image name.");

        public ProductImageName(int number, DateTime timestamp, Slug product)
        {
            Number = number;
            Timestamp = timestamp;
            Product = product ?? throw new ArgumentNullException(nameof(product));
        }

        public int Number { get; }
        public DateTime Timestamp { get; }
        public Slug Product { get; }

        public override string ToString() => $"img-{Number}-{Timestamp:yyyyMMddHHmmssfff}-{Product}.jpg";

        protected override IEnumerable<object> EqualityCheckAttributes => 
            new object[] { Number, Timestamp, Product };
    }
}
