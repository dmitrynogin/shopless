using Shopless.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shopless.IO
{
    public abstract class Folder : Enumerable<string>
    {
        public static Folder Open(Connection @string) => 
            @string.Open<Folder>();

        public abstract Stream Write(string file);
        public abstract Stream Read(string file);
        public abstract void Delete(string file);
    }
}
