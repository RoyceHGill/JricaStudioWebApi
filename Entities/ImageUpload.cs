﻿using JricaStudioWebAPI.Entities.Helpers;
using NuGet.Protocol.Plugins;

namespace JricaStudioWebAPI.Entities
{
    public class ImageUpload : BaseModel
    {
        public string FileName { get; set; }
        public string StoredFileName { get; set; }
        public string ContentType { get; set; }
        public IEnumerable<Service>? Services { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}
