using Shopless.Base;
using System.IO;
using System.Linq;

namespace Shopless.IO
{
    public abstract class Folder : Enumerable<string>
    {
        public object ForEach { get; set; }

        public static Folder Open(Connection @string) => 
            @string.Open<Folder>();

        public abstract Stream Write(string file);
        public abstract Stream Read(string file);
        public abstract void Delete(string file);

        public void Clear() => this.AsParallel().ForEach(Delete);

        public void CopyTo(Folder folder, string file) => CopyTo(folder, file, file);
        public void CopyTo(Folder folder, string file, string newFile)
        {
            using (var source = Read(file))
            using (var target = folder.Write(newFile))
                source.CopyTo(target);
        }

        public void MoveTo(Folder folder, string file) => MoveTo(folder, file, file);
        public void MoveTo(Folder folder, string file, string newFile)
        {
            CopyTo(folder, file, newFile);
            Delete(file);
        }
    }
}
