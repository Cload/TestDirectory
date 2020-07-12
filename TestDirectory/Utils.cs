using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestDirectory.Objects;

namespace TestDirectory
{
    public static class Utils
    {
        public static Folder GetAssets(string filesRoot, string wwwroot)
        {
            Folder result = new Folder();
            result.FolderName = "Documenti";

            Stack<string> dirs = new Stack<string>(20);
            Stack<Folder> folders = new Stack<Folder>(20);


            dirs.Push(filesRoot);
            folders.Push(result);

            while (dirs.Count > 0)
            {

                string currentDir = dirs.Pop();
                Folder currentFolder = folders.Pop() ;
                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }
                catch (Exception e) when (e is UnauthorizedAccessException || e is DirectoryNotFoundException)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                subDirs.ToList().ForEach(dir => {
                    DirectoryInfo di = new DirectoryInfo(dir);
                    var newFolder = new Folder
                    {
                        FolderName = di.Name
                    };
                    currentFolder.Folders.Push(newFolder);
                    folders.Push(newFolder);
                
                });

                string[] files = null;
                try
                {
                    files = System.IO.Directory.GetFiles(currentDir);
                }
                catch (Exception ex) when (ex is UnauthorizedAccessException || ex is DirectoryNotFoundException)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                files.ToList().ForEach(f => {
                    try {
                        FileInfo fi = new FileInfo(f);
                        currentFolder.Files.Add(new DisplayFile
                        {
                            Extension = fi.Extension,
                            FileName = fi.Name,
                            Path = $"{Path.GetRelativePath(wwwroot, fi.FullName)}"
                        }); 
                    } catch (FileNotFoundException e)
                    {
                        Console.WriteLine(e);
                    }
                });

                foreach (string str in subDirs)
                {
                    dirs.Push(str);

                }
            }
            return result;
            
            
            

        }
    }
}
