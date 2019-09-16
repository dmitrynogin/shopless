using System;
using System.Collections.Generic;
using System.Text;

namespace Shopless.IO
{
    public interface IStorage
    {
        Folder Upload { get; }
        Folder Images { get; } 
    }
}
