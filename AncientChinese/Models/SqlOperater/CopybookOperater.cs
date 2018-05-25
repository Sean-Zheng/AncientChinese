using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AncientChinese.Models.SqlOperater
{
    public class CopybookOperater:DbOperater
    {
        public IEnumerable<Copybook> GetCopybooks()
        {
            SqlDataReader reader = GetSqlDataReader(@"SELECT Tb_CopyBook.Id,Tb_CopyBook.Title,Tb_CopybookType.TypeName FROM Tb_CopyBook 
                                            LEFT JOIN Tb_CopybookType on Tb_CopyBook.TypeId=Tb_CopybookType.TypeId 
                                            ORDER BY Tb_CopyBook.TypeId,Tb_CopyBook.Title");
            while (reader.Read())
            {
                Copybook book = new Copybook
                {
                    Id = reader.GetGuid(0),
                    Title = reader.GetString(1),
                    BookType = reader.GetString(2)
                };
                yield return book;
            }
            reader.Close();
            CloseConnection();
        }

        public IEnumerable<Guid> GetCopybook(string id)
        {
            using (SqlCommand command=_connection.CreateCommand())
            {
                command.CommandText = "SELECT Tb_CopyBookFile.FileId FROM Tb_CopyBookFile LEFT JOIN Tb_File ON Tb_CopyBookFile.FileId=Tb_File.FileId WHERE Id=@ID ORDER BY Tb_File.FileName";
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