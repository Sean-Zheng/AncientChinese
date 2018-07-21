using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SqlDataAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FontInfo> infos = new List<FontInfo>();


            //加载文字映射表
            string[] index = new string[5000];
            FileStream fs = new FileStream(@"C:\Users\NULL\Desktop\image2\index.txt", FileMode.Open);
            StreamReader reader = new StreamReader(fs, Encoding.Default);
            string line = null;
            Regex r = new Regex(@"(\d+):(.*?);");
            do
            {
                line = reader.ReadLine();
                if (line == null)
                    break;
                Match m = r.Match(line);
                index[int.Parse(m.Groups[1].Value)] = m.Groups[2].Value;
            } while (line != null);

            Regex regex = new Regex(@"([a-zA-Z]+)(\d+)(\(\d\))*.[a-z]+");
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\NULL\Desktop\image2");
            DirectoryInfo[] directories = directory.GetDirectories();
            foreach (DirectoryInfo dir in directories)
            {
                foreach (FileInfo item in dir.GetFiles())
                {
                    Match match = regex.Match(item.Name);
                    int i = int.Parse(match.Groups[2].Value);
                    int type;
                    switch (match.Groups[1].Value)
                    {
                        case "cao":
                            type = 1;
                            break;
                        case "jia":
                            type = 2;
                            break;
                        case "jin":
                            type = 3;
                            break;
                        case "kai":
                            type = 4;
                            break;
                        case "li":
                            type = 5;
                            break;
                        case "zh":
                            type = 6;
                            break;
                        default:
                            type = 0;
                            break;
                    }
                    FontInfo info = new FontInfo
                    {
                        FontId = Guid.NewGuid(),
                        FileId = Guid.NewGuid(),
                        FileName = item.Name,
                        FontType = type,
                        Content = index[i]
                    };
                    infos.Add(info);
                }
            }

            string dbPath = @"C:\Users\NULL\Source\Repos\AncientChinese\AncientChinese\App_Data\AC.mdf";
            SqlConnection connection = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True");

            SqlDataAdapter adapter_font = new SqlDataAdapter("SELECT * FROM Tb_Font", connection);
            SqlDataAdapter adapter_font_file = new SqlDataAdapter("SELECT * FROM Tb_FontFile", connection);
            SqlDataAdapter adapter_file = new SqlDataAdapter("SELECT * FROM Tb_File", connection);

            new SqlCommandBuilder(adapter_font);
            new SqlCommandBuilder(adapter_font_file);
            new SqlCommandBuilder(adapter_file);

            DataTable table_font = new DataTable();
            DataTable table_font_file = new DataTable();
            DataTable table_file = new DataTable();

            adapter_font.Fill(table_font);
            adapter_font_file.Fill(table_font_file);
            adapter_file.Fill(table_file);

            foreach (var item in infos)
            {
                DataRow row_font = table_font.NewRow();
                DataRow row_font_file = table_font_file.NewRow();
                DataRow row_file = table_file.NewRow();

                row_font["Id"] = item.FontId;
                row_font["FontType"] = item.FontType;
                row_font["Content"] = item.Content;

                row_file["FileId"] = item.FileId;
                row_file["FileName"] = item.FileName;

                row_font_file["FileId"] = item.FileId;
                row_font_file["FontId"] = item.FontId;

                table_font.Rows.Add(row_font);
                table_file.Rows.Add(row_file);
                table_font_file.Rows.Add(row_font_file);
            }

            //foreach (DataRow item in table_font.Rows)
            //{
            //    Console.WriteLine(item[0]);
            //    Console.WriteLine(item[1]);
            //    Console.WriteLine(item[2]);
            //}


            adapter_font.Update(table_font);
            adapter_file.Update(table_file);
            adapter_font_file.Update(table_font_file);

        }
    }
    class FontInfo
    {
        public Guid FontId { get; set; }
        public Guid FileId { get; set; }
        public string FileName { get; set; }
        public int FontType { get; set; }
        public string Content { get; set; }
    }
}
