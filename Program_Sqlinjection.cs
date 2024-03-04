using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SonarLint;
public static partial class Program
{
    public static void SqlInjection()
    {
        string connectionString = "Data Source=.;Initial Catalog=master;Integrated Security=True";
        using SqlConnection connection = new(connectionString);
        connection.Open();
        //錯誤 - 未使用參數化查詢
        SqlCommand command = new("SELECT * FROM TB_MemberData WHERE MEMIDNO = '123456'", connection);
        //正確
        // SqlCommand command = new SqlCommand("SELECT * FROM TB_MemberData WHERE MEMIDNO = @username", connection);
        // command.Parameters.AddWithValue("@username", "123456");
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader["MEMIDNO"].ToString());
        }
    }
}
