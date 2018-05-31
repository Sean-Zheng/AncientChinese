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
            ExcelOperater operater = new ExcelOperater(@"C:\Users\NULL\Desktop\a.xlsx");

            IEnumerable<Book> books = operater.GetBooks();

            CopybookOperater copybookOperater = new CopybookOperater();
            copybookOperater.AddContent(books);
            //foreach (var item in books)
            //{
            //    Console.WriteLine(item.Title);
            //    Console.WriteLine(item.Author);
            //    Console.WriteLine(item.Content);
            //    Console.WriteLine();
            //}
        }
    }
}
