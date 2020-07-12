using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDirectory.Objects
{
    public class Folder : IDisplayable
    {
        public const string FolderType = "folder";
        public string FolderName { get; set; }

        public Stack<Folder> Folders { get; set; } = new Stack<Folder>(20);

        public List<DisplayFile> Files { get; set; } = new List<DisplayFile>();


        public string Text => this.FolderName;

       public IEnumerable<IDisplayable> Children
        {
            get
            {
                var children = new List<IDisplayable>();
                children.AddRange(Folders);
                children.AddRange(Files);
                return children;
            }
        }

        public string Type => FolderType;
    }
}
