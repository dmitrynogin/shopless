using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopless.Base;
using Shopless.Products;
using Shopless.Products.Images;
using System;
using System.IO;
using System.Linq;

namespace Shopless.IO
{
    [TestClass]
    public class ImageUploader_Should
    {
        [TestMethod]
        public void Upload()
        {
            Clock.Time = () => new DateTime(2019, 1, 2, 3, 4, 5, 678);

            IStorage storage = new Storage();
            storage.Upload.Clear();
            storage.Images.Clear();

            IImageUploader iu = new ImageUploader(storage);

            var tin1 = iu.Upload(1, new MemoryStream());
            var tin2 = iu.Upload(2, new MemoryStream());

            iu.Rename("Best Pasta Ever", tin1, tin2);

            Assert.IsFalse(storage.Upload.Any());

            Assert.AreEqual(2, storage.Images.Count());
            Assert.IsTrue(storage.Images.Contains("img-1-20190102030405678-best-pasta-ever.jpg"));
            Assert.IsTrue(storage.Images.Contains("img-2-20190102030405678-best-pasta-ever.jpg"));
        }
    }
}
