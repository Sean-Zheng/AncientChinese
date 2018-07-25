using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AncientChinese.Models.SqlOperater
{
    public class FontOperater:DbOperater
    {
        /// <summary>
        /// 获取字体类型列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FontType> GetFontTypes()
        {
            SqlDataReader reader = GetSqlDataReader("SELECT * FROM Tb_FontType");

            while (reader.Read())
            {
                FontType fontType = new FontType
                {
                    TypeId = reader.GetInt32(0),
                    TypeName = reader.GetString(1)
                };
                yield return fontType;
            }
            reader.Close();
            CloseConnection();
        }

        public IEnumerable<Font> GetFonts(int type)
        {
            SqlDataReader reader = GetSqlDataReader($"SELECT Tb_FontFile.FileId,Tb_Font.Content FROM Tb_Font LEFT JOIN Tb_FontFile ON Tb_Font.Id=Tb_FontFile.FontId WHERE Tb_Font.FontType={type} ORDER BY Tb_Font.Content");
            while (reader.Read())
            {
                Font font = new Font
                {
                    FileId = reader.GetGuid(0),
                    Content = reader.GetString(1)
                };
                yield return font;
            }
            reader.Close();
            CloseConnection();
        }
        public IEnumerable<Font> GetFonts(string word)
        {
            using(SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT Tb_FontFile.FileId,Tb_FontType.TypeName FROM Tb_Font LEFT JOIN Tb_FontFile ON Tb_Font.Id=Tb_FontFile.FontId LEFT JOIN Tb_FontType ON Tb_Font.FontType=Tb_FontType.TypeId WHERE Tb_Font.Content=@search ORDER BY Tb_Font.FontType";
                command.Parameters.AddWithValue("search", word);
                SqlDataReader reader = GetSqlDataReader(command);
                while (reader.Read())
                {
                    Font font = new Font
                    {
                        FileId = reader.GetGuid(0),
                        Type = reader.GetString(1)
                    };
                    yield return font;
                }
                reader.Close();
                CloseConnection();
            }
        }
    }
}