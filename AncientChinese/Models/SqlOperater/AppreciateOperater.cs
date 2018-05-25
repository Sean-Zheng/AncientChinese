using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AncientChinese.Models.SqlOperater
{
    public class AppreciateOperater:DbOperater
    {
        public IEnumerable<Appreciate> List()
        {
            SqlDataReader reader = GetSqlDataReader("SELECT * FROM Tb_Appreciate");
            while (reader.Read())
            {
                Appreciate appreciate = new Appreciate
                {
                    ID = reader.GetGuid(0),
                    Title = reader.GetString(1),
                    Times = reader.GetString(2),
                    Author = reader.GetString(3)
                };
                yield return appreciate;
            }
            reader.Close();
            CloseConnection();
        }
        public IEnumerable<Guid> Detail(string id)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT Tb_AppreciateFile.FileId FROM Tb_AppreciateFile LEFT JOIN Tb_File ON Tb_AppreciateFile.FileId=Tb_File.FileId WHERE Id=@ID ORDER BY Tb_File.FileName";
                command.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = GetSqlDataReader(command);
                while (reader.Read())
                    yield return reader.GetGuid(0);

                reader.Close();
                CloseConnection();
            }
        }
    }
}