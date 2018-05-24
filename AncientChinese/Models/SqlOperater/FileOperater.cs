using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AncientChinese.Models.SqlOperater
{
    public class FileOperater:DbOperater
    {
        public string GetFilePath(string fileId)
        {
            using (SqlCommand command=_connection.CreateCommand())
            {
                command.CommandText = "SELECT Tb_File.FileName FROM Tb_File WHERE FileId=@id";
                command.Parameters.AddWithValue("@id", fileId);

                string path = null;
                SqlDataReader reader = GetSqlDataReader(command);
                if (reader.Read())
                    path = reader.GetString(0);
                CloseConnection();
                return path;
            }
        }
    }
}