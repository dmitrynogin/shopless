using Autofac;
using Shopless.IO;
using Shopless.Base;
using System.IO;
using static System.Console;

namespace Shopless
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AssemblyRegistrationModule(Solution.Assemblies));

            var container = builder.Build();
            var storage = container.Resolve<IStorage>();
            var imageUploader = container.Resolve<IImageUploader>();

            storage.Images.Clear();
            storage.Upload.Clear();

            var temporaryImageName1 = imageUploader.Upload(1, new MemoryStream());
            var temporaryImageName2 = imageUploader.Upload(2, new MemoryStream());
            imageUploader.Rename("Best Pasta Ever", temporaryImageName1, temporaryImageName2);

            storage.Images.ForEach(WriteLine);
        }
    }
}
