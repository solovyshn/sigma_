using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5
{
    class FilePath
    {
        string path;
        public FilePath(string str) {
            path = str;
        }
        public string Path {
            get { return this.path; }
            set { path = value; }
        }
        public string FindNameOfFile() { 
            string[] str=path.Split('\\');
            string[] file = str[str.Length - 1].Split('.'); 
            return file[0];
        }
        public string FindNameOfRootFolder() {
            string[] str = path.Split('\\');
            return str[0];
        }
    }
}
