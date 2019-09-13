﻿using Shopless.Base;
using System;
using System.Collections.Generic;
using System.IO;
using static System.IO.Path;
using static System.IO.Directory;
using System.Linq;

namespace Shopless.IO
{
    public sealed class DiskFolder : Folder
    {
        public static Connection String(string path) => 
            $"Type={typeof(DiskFolder)}, {typeof(DiskFolder).Assembly};Path={path}";

        public DiskFolder()
            : this(GetTempPath())
        {
        }

        public DiskFolder(Connection @string)
            : this(@string.Get<string>("Path"))
        {
        }

        public DiskFolder(string path) 
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            if (!Exists(Path))
                CreateDirectory(Path);
        }

        public string Path { get; }

        public override IEnumerator<string> GetEnumerator() => 
            EnumerateFiles(Path).Select(GetFileName).GetEnumerator();

        public override Stream Write(string file) => 
            File.OpenWrite(Combine(Path, file));

        public override Stream Read(string file) =>
            File.OpenRead(Combine(Path, file));

        public override void Delete(string file) =>
            File.Delete(Combine(Path, file));
    }
}
