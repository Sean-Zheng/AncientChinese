using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SqlDataAdder
{
    class CopybookOperater:DbOperater
    {

        private DataSet _dataSet;

        public CopybookOperater():base()
        {
            _dataSet = new DataSet();
        }
        public void GetTable()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id,Title,FontType FROM Tb_CopyBook", _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            List<Title> titles = new List<Title>();

            foreach (DataRow item in table.Rows)
            {
                Title title = new Title
                {
                    T = item.Field<string>(1)
                };
                titles.Add(title);
            }
            Regex regex = new Regex(@"(.*?)（(.*?)）");

            for (int i = 0; i < titles.Count; i++)
            {
                Match match = regex.Match(titles[i].T);
                titles[i].Tit = match.Groups[1].Value;
                titles[i].type = match.Groups[2].Value;
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                row[1] = titles[i].Tit;
                row[2] = titles[i].type;
            }

            foreach (DataRow item in table.Rows)
            {

                Console.WriteLine(item.Field<string>(1));
                Console.WriteLine(item.Field<string>(2));
                Console.WriteLine();
            }


            new SqlCommandBuilder(adapter);
            adapter.Update(table);
        }



        public void AddCopyBook(string[] fileNames,int type)
        {
            AddCopyBook1(fileNames, type);
            AddCopyBook2(fileNames);
        }

        private void AddCopyBook1(string[] fileNames,int type)
        {
            SqlDataAdapter adapter_copybook = new SqlDataAdapter("SELECT * FROM Tb_CopyBook", _connection);
            SqlDataAdapter adapter_file = new SqlDataAdapter("SELECT * FROM Tb_File", _connection);

            Regex regex = new Regex(@"(.*?（.*?）)\d*");

            adapter_copybook.Fill(_dataSet, "Tb_CopyBook");
            adapter_file.Fill(_dataSet, "Tb_File");

            DataTable table_copybook = _dataSet.Tables["Tb_CopyBook"];
            DataTable table_files = _dataSet.Tables["Tb_File"];

            new SqlCommandBuilder(adapter_copybook);
            new SqlCommandBuilder(adapter_file);

            List<string> title = new List<string>();

            foreach (var item in fileNames)
            {
                Match match = regex.Match(item);
                string name = match.Groups[1].Value;
                title.Add(name);

                DataRow row_file = table_files.NewRow();
                row_file[0] = Guid.NewGuid();
                row_file[1] = item;
                row_file[2] = "~/ Resources / " + item;
                table_files.Rows.Add(row_file);
            }
            string[] names = title.Distinct().ToArray();

            foreach (var item in names)
            {
                DataRow row_copybook = table_copybook.NewRow();
                row_copybook[0] = Guid.NewGuid();
                row_copybook[1] = item;
                row_copybook[2] = type;
                table_copybook.Rows.Add(row_copybook);
            }

            adapter_copybook.Update(table_copybook);
            adapter_file.Update(table_files);
        }
        //SELECT Tb_CopyBook.Title, Tb_File.FileName FROM Tb_CopyBookFile LEFT JOIN Tb_CopyBook ON Tb_CopyBook.Id= Tb_CopyBookFile.Id LEFT JOIN Tb_File ON Tb_File.FileId= Tb_CopyBookFile.FileId ORDER BY Tb_File.FileName


        private void AddCopyBook2(string[] fileNames)
        {
            SqlDataAdapter adapter_copybook = new SqlDataAdapter("SELECT * FROM Tb_CopyBook", _connection);
            SqlDataAdapter adapter_copybookFile = new SqlDataAdapter("SELECT * FROM Tb_CopyBookFile", _connection);
            SqlDataAdapter adapter_file = new SqlDataAdapter("SELECT * FROM Tb_File", _connection);

            Regex regex = new Regex(@"(.*?（.*?）)\d*");

            adapter_copybook.Fill(_dataSet, "Tb_CopyBook");
            adapter_copybookFile.Fill(_dataSet, "Tb_CopyBookFile");
            adapter_file.Fill(_dataSet, "Tb_File");

            DataTable table_copybook = _dataSet.Tables["Tb_CopyBook"];
            DataTable table_copybookfile = _dataSet.Tables["Tb_CopyBookFile"];
            DataTable table_files = _dataSet.Tables["Tb_File"];

            new SqlCommandBuilder(adapter_copybookFile);

            foreach (var item in fileNames)
            {
                Match match = regex.Match(item);
                string name = match.Groups[1].Value;
                DataRow row_copybook = table_copybook.Select($"Title='{name}'")[0];
                DataRow row_file = table_files.Select($"FileName='{item}'")[0];
                DataRow row_fileref = table_copybookfile.NewRow();
                row_fileref[0] = row_copybook.Field<Guid>(0);
                row_fileref[1] = row_file.Field<Guid>(0);
                table_copybookfile.Rows.Add(row_fileref);
                
                adapter_copybookFile.Update(_dataSet, "Tb_CopyBookFile");
            }
            
        }
        


        public void AddContent(IEnumerable<Book>books)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Tb_CopyBook", _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (var item in books)
            {
                DataRow[] rows = table.Select($"Title='{item.Title}'");
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i][3] = item.Author;
                    rows[i][5] = item.Content;
                }
            }
            new SqlCommandBuilder(adapter);
            adapter.Update(table);
        }

    }
    class Title
    {
        public string T { get; set; }
        public string Tit { get; set; }
        public string type { get; set; }
    }
}
