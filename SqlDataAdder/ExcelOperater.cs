using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataAdder
{
    class ExcelOperater
    {
        private IWorkbook _workbook;

        public ExcelOperater(string path)
        {
            string extension = Path.GetExtension(path);
            if (extension == ".xlsx")//Excel2007
                this._workbook = new XSSFWorkbook(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite));
            else if (extension == ".xls")//Excel2003
                this._workbook = new HSSFWorkbook(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite));
            
        }

        public IEnumerable<Book> GetBooks()
        {
            ISheet sheet = _workbook.GetSheetAt(3);
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                IRow cells = sheet.GetRow(i);
                
                Book book = new Book
                {
                    Title = cells.GetCell(0).StringCellValue.Trim(),
                    Author = cells.GetCell(1).StringCellValue.Trim(),
                    Content = cells.GetCell(2).StringCellValue
                };
                yield return book;
            }
        }
    }
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}
