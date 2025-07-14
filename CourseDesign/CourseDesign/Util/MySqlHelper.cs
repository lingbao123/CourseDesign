using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CourseDesign.Util
{
    /// <summary>
    /// 通用 MySQL 数据库操作辅助类
    /// </summary>
    public static class MySqlHelper
    {
        // 连接字符串，根据你的数据库实际情况修改
        private static readonly string connStr = "server=localhost;user=root;password=123qweAASD;database=design;charset=utf8";

        /// <summary>
        /// 执行 INSERT、UPDATE、DELETE 等非查询操作，返回受影响的行数
        /// </summary>
        public static int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            using MySqlConnection conn = new MySqlConnection(connStr);
            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 执行 SELECT，返回第一行第一列的值（常用于聚合查询）
        /// </summary>
        public static object ExecuteScalar(string sql, params MySqlParameter[] parameters)
        {
            using MySqlConnection conn = new MySqlConnection(connStr);
            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            conn.Open();
            return cmd.ExecuteScalar();
        }

        /// <summary>
        /// 执行 SELECT 查询，返回 DataTable（适合显示列表数据）
        /// </summary>
        public static DataTable ExecuteDataTable(string sql, params MySqlParameter[] parameters)
        {
            using MySqlConnection conn = new MySqlConnection(connStr);
            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            using MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}