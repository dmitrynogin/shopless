using Shopless.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopless.IO
{
    [Service]
    public class Storage : IStorage
    {
        public Folder Upload => Folder.Open(Config.Active.UploadFolder);
        public Folder Images => Folder.Open(Config.Active.ImageFolder);
    }
}
