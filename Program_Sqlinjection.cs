using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SonarLint;
public static partial class Program
{
    public static void SqlInjection(
        int username
    )
    {
        string connectionString = "Data Source=.;Initial Catalog=master;Integrated Security=True";
        using SqlConnection connection = new(connectionString);
        connection.Open();
        // SqlCommand command = new($"SELECT * FROM TB_MemberData WHERE MEMIDNO = {username}", connection);
        SqlCommand command = new("SELECT * FROM TB_MemberData WHERE MEMIDNO = @username", connection);
        command.Parameters.AddWithValue("@username", "123456");
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader["MEMIDNO"].ToString());
        }
    }
}
