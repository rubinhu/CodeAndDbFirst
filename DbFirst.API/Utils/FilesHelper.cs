using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DbFirst.API.Utils
{
    public class FilesHelper
    {
        /// <summary>
        /// Get all files from a directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<FileInfo> GetFiles(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            var files = dir.GetFiles().Select(fn => new FileInfo(fn.Name)).OrderBy(f => f.Name); 
            return files.ToList();
        }

        /// <summary>
        /// Get the contents from a file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetFileContents(string path)
        {
            string contents = File.ReadAllText(path);
            return contents;
        }
    }
}
