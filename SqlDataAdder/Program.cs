using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;

namespace SqlDataAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\NULL\Desktop\书生文\元曲");
            FileInfo[] files = directory.GetFiles();
            List<string> fileNames = new List<string>();
            foreach (var item in files)
                fileNames.Add(item.Name);
            CopybookOperater operater = new CopybookOperater();
            operater.AddCopyBook(fileNames.ToArray(),3);

        }
    }
}
