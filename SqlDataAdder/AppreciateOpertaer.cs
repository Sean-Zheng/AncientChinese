using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataAdder
{
    class AppreciateOpertaer:DbOperater
    {
        private DataSet _dataSet;

        public AppreciateOpertaer() : base()
        {
            _dataSet = new DataSet();
        }

        public void Add(DirectoryInfo directoryInfo)
        {
            Add1(directoryInfo);
            Add2(directoryInfo);

        }

        private void Add1(DirectoryInfo directoryInfo)
        {
            SqlDataAdapter adapter_Appreciate = new SqlDataAdapter("SELECT * FROM Tb_Appreciate", _connection);
            SqlDataAdapter adapter_file = new SqlDataAdapter("SELECT * FROM Tb_File", _connection);

            adapter_Appreciate.Fill(_dataSet, "Tb_Appreciate");
            adapter_file.Fill(_dataSet, "Tb_File");

            DataTable table_Appreciate = _dataSet.Tables["Tb_Appreciate"];
            DataTable table_files = _dataSet.Tables["Tb_File"];

            new SqlCommandBuilder(adapter_Appreciate);
            new SqlCommandBuilder(adapter_file);

            FileInfo[] files = directoryInfo.GetFiles();
            DirectoryInfo[] directories = directoryInfo.GetDirectories();

            foreach (var item in files)
            {
                DataRow row_file = table_files.NewRow();
                row_file[0] = Guid.NewGuid();
                row_file[1] = item.Name;
                table_files.Rows.Add(row_file);

                string[] names = Path.GetFileNameWithoutExtension(item.Name).Split('-');

                DataRow row_app = table_Appreciate.NewRow();
                row_app[0] = Guid.NewGuid();
                row_app[1] = names[0];
                row_app[2] = names[1];
                row_app[3] = names[2];
                table_Appreciate.Rows.Add(row_app);
            }
            foreach (var item in directories)
            {
                string[] names = Path.GetFileNameWithoutExtension(item.Name).Split('-');

                DataRow row_app = table_Appreciate.NewRow();
                row_app[0] = Guid.NewGuid();
                row_app[1] = names[0];
                row_app[2] = names[1];
                row_app[3] = names[2];
                table_Appreciate.Rows.Add(row_app);
                foreach (var i in item.GetFiles())
                {
                    DataRow row_file = table_files.NewRow();
                    row_file[0] = Guid.NewGuid();
                    row_file[1] = i.Name;
                    table_files.Rows.Add(row_file);
                }
            }

            adapter_Appreciate.Update(table_Appreciate);
            adapter_file.Update(table_files);
        }


        public void Add2(DirectoryInfo directoryInfo)
        {
            SqlDataAdapter adapter_app = new SqlDataAdapter("SELECT * FROM Tb_Appreciate", _connection);
            SqlDataAdapter adapter_appFile = new SqlDataAdapter("SELECT * FROM Tb_AppreciateFile", _connection);
            SqlDataAdapter adapter_file = new SqlDataAdapter("SELECT * FROM Tb_File", _connection);


            adapter_app.Fill(_dataSet, "Tb_Appreciate");
            adapter_appFile.Fill(_dataSet, "Tb_AppreciateFile");
            adapter_file.Fill(_dataSet, "Tb_File");

            DataTable table_copybook = _dataSet.Tables["Tb_Appreciate"];
            DataTable table_copybookfile = _dataSet.Tables["Tb_AppreciateFile"];
            DataTable table_files = _dataSet.Tables["Tb_File"];

            new SqlCommandBuilder(adapter_appFile);


            FileInfo[] files = directoryInfo.GetFiles();
            DirectoryInfo[] directories = directoryInfo.GetDirectories();

            foreach (var item in files)
            {

                string[] names = Path.GetFileNameWithoutExtension(item.Name).Split('-');

                DataRow row_copybook = table_copybook.Select($"Title='{names[0]}'")[0];
                DataRow row_file = table_files.Select($"FileName='{item.Name}'")[0];

                DataRow row_fileref = table_copybookfile.NewRow();
                row_fileref[0] = row_copybook.Field<Guid>(0);
                row_fileref[1] = row_file.Field<Guid>(0);
                table_copybookfile.Rows.Add(row_fileref);
            }


            foreach (var item in directories)
            {
                string[] names = Path.GetFileNameWithoutExtension(item.Name).Split('-');

                DataRow row_copybook = table_copybook.Select($"Title='{names[0]}'")[0];

                foreach (var i in item.GetFiles())
                {
                    DataRow row_file = table_files.Select($"FileName='{i.Name}'")[0];

                    DataRow row_fileref = table_copybookfile.NewRow();
                    row_fileref[0] = row_copybook.Field<Guid>(0);
                    row_fileref[1] = row_file.Field<Guid>(0);

                    table_copybookfile.Rows.Add(row_fileref);
                }
            }

            adapter_appFile.Update(table_copybookfile);

        }

    }
}
