using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestDirectory.Objects
{
    public class DisplayFile : IDisplayable
    {
        public string Type
        {
            get
            {
                if (string.IsNullOrEmpty(this.Extension))
                {
                    return "file";
                }
                var formattedExt = this.Extension.Replace(".", "").ToLower();
                switch (formattedExt)
                {
                    case "pdf":
                        return "pdf";
                    case "jpg":
                    case "png":
                        return "image";
                    default:
                        return "file";
                }
            }
        }

        public string FileName { get; set; }

        public string Extension { get; set; }

        public string Path { get; set; }
        public string Text => FileName;
        public IEnumerable<IDisplayable> Children => new List<IDisplayable>();

 
    }
}