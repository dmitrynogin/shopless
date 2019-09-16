using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shopless
{
    public interface IImageUploader
    {
        string Upload(int number, Stream jpeg);
        void Rename(string product, params string[] images);
    }
}
