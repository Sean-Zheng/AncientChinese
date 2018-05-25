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
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\NULL\Desktop\书生文\晋代名家书法");
            AppreciateOpertaer opertaer = new AppreciateOpertaer();
            opertaer.Add2(directory);
        }
    }
}
