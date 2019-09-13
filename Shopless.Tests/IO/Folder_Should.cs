using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Shopless.IO
{
    [TestClass]
    public class Folder_Should
    {
        [TestMethod]
        public void Stringify()
        {
            Connection connection = DiskFolder.String("c:\\proj");
            Assert.AreEqual(
                "Type=Shopless.IO.DiskFolder, Shopless.Disk, Version;Path=c:\\proj", 
                $"{connection}");
        }

        [TestMethod]
        public void Open()
        {
            Folder folder = Folder.Open("Type=Shopless.IO.DiskFolder, Shopless.Disk;Path=c:\\proj");
            Assert.IsTrue(folder is DiskFolder df && df.Path == "c:\\proj");
        }

        [TestMethod]
        public void Manage_Files()
        {
            var folder = new DiskFolder();
            folder.Delete("test.txt");
            Assert.IsFalse(folder.Contains("test.txt"));
            folder.Write("test.txt").Dispose();
            folder.Read("test.txt").Dispose();
            Assert.IsTrue(folder.Contains("test.txt"));
            folder.Delete("test.txt");
            Assert.IsFalse(folder.Contains("test.txt"));
        }
    }
}
