using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AncientChinese.Models.SqlOperater
{
    public abstract class DbOperater
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        protected readonly SqlConnection _connection;

        private readonly string _connectionString;
        private readonly SqlDataAdapter _adapter;
        private readonly DataTable _table;

        /// <summary>
        /// 只读的数据库操作类
        /// </summary>
        public DbOperater()
        {
            string dbPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/AC.mdf");
            _connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            _connection = new SqlConnection(_connectionString);
        }

        /// <summary>
        /// 可读写的数据库操作类
        /// </summary>
        /// <param name="selectCommandText">select语句</param>
        public DbOperater(string selectCommandText):this()
        {
            _adapter = new SqlDataAdapter(selectCommandText, _connection);
            _table = new DataTable();
            _adapter.Fill(_table);
            new SqlCommandBuilder(_adapter);
        }

        /// <summary>
        /// 可读写的数据库操作类
        /// </summary>
        /// <param name="selectCommand">select命令</param>
        public DbOperater(SqlCommand selectCommand):this()
        {
            _adapter = new SqlDataAdapter(selectCommand);
            _table = new DataTable();
            _adapter.Fill(_table);
            new SqlCommandBuilder(_adapter);
        }

        /// <summary>
        /// 获取表数据，使用后须关闭数据库连接
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        protected virtual SqlDataReader GetSqlDataReader(string commandText)
        {
            using (SqlCommand command=_connection.CreateCommand())
            {
                command.CommandText = commandText;
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
        }

        /// <summary>
        /// 获取表数据，使用后须关闭数据库连接
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected virtual SqlDataReader GetSqlDataReader(SqlCommand command)
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        protected virtual void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }

        /// <summary>
        /// 获取表数据
        /// </summary>
        /// <returns></returns>
        protected DataTableReader GetDataTableReader()
        {
            if (_adapter == null || _table == null)
                throw new Exception("只读类不允许操作");
            return new DataTableReader(_table);
        }

        /// <summary>
        /// 添加新的数据
        /// </summary>
        /// <returns></returns>
        protected DataRow GetNewRow()
        {
            if (_adapter == null || _table == null)
                throw new Exception("只读类不允许操作");
            return _table.NewRow();
        }

        protected DataRow GetRow(string filterExpression)
        {
            if (_adapter == null || _table == null)
                throw new Exception("只读类不允许操作");
            return _table.Select(filterExpression)[0];
        }

        protected DataRow[] GetRows()
        {
            if (_adapter == null || _table == null)
                throw new Exception("只读类不允许操作");
            return _table.Select();
        }

        protected DataRow[] GetRows(string filterExpression)
        {
            if (_adapter == null || _table == null)
                throw new Exception("只读类不允许操作");
            return _table.Select(filterExpression);
        }

        protected void AddRow(DataRow row)
        {
            if (_adapter == null || _table == null)
                throw new Exception("只读类不允许操作");
            _table.Rows.Add(row);
            _adapter.Update(_table);
        }

        protected void DateleteRow(DataRow row)
        {
            if (_adapter == null || _table == null)
                throw new Exception("只读类不允许操作");
            row.Delete();
            _adapter.Update(_table);
        }

        protected void UpdateRow()
        {
            if (_adapter == null || _table == null)
                throw new Exception("只读类不允许操作");
            _adapter.Update(_table);
        }
    }
}