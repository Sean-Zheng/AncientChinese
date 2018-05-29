using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;
using System.Data;

namespace SqlDataAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            //DirectoryInfo directory = new DirectoryInfo(@"C:\Users\NULL\Desktop\书生文\晋代名家书法");
            //AppreciateOpertaer opertaer = new AppreciateOpertaer();
            //opertaer.Add2(directory);



            CopybookOperater operater = new CopybookOperater();

            operater.GetTable();


            //Title[] table = operater.GetTable().ToArray();

            //Regex regex = new Regex(@"(.*?)（(.*?)）");


            //for (int i = 0; i < table.Length; i++)
            //{
            //    Match match = regex.Match(table[i].T);
            //    table[i].Tit = match.Groups[1].Value;
            //    table[i].type = match.Groups[2].Value;
            //}



            //foreach (var item in table)
            //{
            //    Console.WriteLine(item.T);
            //    Console.WriteLine(item.Tit);
            //    Console.WriteLine(item.type);
            //    Console.WriteLine();
            //}
        }
    }
}
