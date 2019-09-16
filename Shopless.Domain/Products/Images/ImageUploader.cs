using Shopless.Base;
using Shopless.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Shopless.Products.Images
{
    [Service]
    public class ImageUploader : IImageUploader
    {
        public ImageUploader(IStorage storage)
        {
            Storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        IStorage Storage { get; }

        public string Upload(int number, Stream jpeg)
        {
            var name = TemporaryImageName.New(number);
            using (var file = Storage.Upload.Write(name))
                jpeg.CopyTo(file);

            return name;
        }

        public void Rename(string product, params string[] images)
        {
            var pn = ProductName.New(product);
            foreach (var tin in images.Select(TemporaryImageName.Parse))
                if(Storage.Upload.Contains(tin))
                {
                    var pin = ProductImageName.New(tin, pn);
                    Storage.Upload.MoveTo(Storage.Images, tin, pin);
                }
        }
    }
}
