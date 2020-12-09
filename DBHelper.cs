using System.Collections;
using System.Data.SqlClient;

namespace ChouJiang
{
    class DBHelper
    {
        //数据库连接字符串
        public static string ConnectionStr = "Data source=192.168.0.13;Initial Catalog=WinForm_Tese;User ID=sa;Password=123";
        //无参构造函数
        public DBHelper() { }
        //执行查询语句
        public static ArrayList Query_sql(string sql, params SqlParameter[] ps)
        {

            ArrayList Count = new ArrayList();


            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    SqlDataReader ObjReader = cmd.ExecuteReader();

                    while (ObjReader.Read())
                    {
                        Count.Add(ObjReader[0]);
                    }
                    return Count;
                }
            }
        }


        public static void Update_sql(string sql)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

