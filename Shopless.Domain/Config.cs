using Newtonsoft.Json;
using Shopless.Base;
using Shopless.IO;
using System;
using System.Collections.Generic;
using System.IO;
using static System.IO.File;

namespace Shopless
{
    public class Config : ValueObject<Config>
    {        
        public static readonly Config Local = Load("local.json");
        public static readonly Config Stage = Load("stage.json");
        public static readonly Config Published = Load("published.json");
        public static readonly Config Active = Published ?? Stage ?? Local;

        public static Config Load(string file) =>
            Exists(file) ? JsonConvert.DeserializeObject<Config>(ReadAllText(file)) : null;

        public Config(string uploadFolder, string imageFolder)
        {
            UploadFolder = uploadFolder;
            ImageFolder = imageFolder;
        }

        public Connection UploadFolder { get; }
        public Connection ImageFolder { get; }

        protected override IEnumerable<object> EqualityCheckAttributes =>
            new object[] { UploadFolder, ImageFolder };
    }
}
