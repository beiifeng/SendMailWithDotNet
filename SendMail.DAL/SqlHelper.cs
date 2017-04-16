using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SendMail.DAL
{
    public class SqlHelper
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;


        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="paramters">参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] paramters)          //增删改;
        {
            using (SqlConnection conn = new SqlConnection(connStr))  //使用using自动释放资源.
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(paramters);
                    return cmd.ExecuteNonQuery();   //Query是查询的意思;
                }
            }
        }

        /// <summary>
        /// 查询，返回第一行第一列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static Object ExecuteScalar(string sql, params SqlParameter[] parameters)        //select语句;
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar(); //返回查询的第一行第一列;
                }
            }
        }

        /// <summary>
        /// 查询返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);   //本句真正执行sql语句,并将数据放到ds中;
                    return ds.Tables[0];
                }
            }
        }

    }
}