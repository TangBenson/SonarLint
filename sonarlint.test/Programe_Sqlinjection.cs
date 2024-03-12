using System.Data.SqlClient;

namespace sonarlint.test;
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

        // SqlCommand command = new($"DELETE FROM users WHERE UserId = {id}", connection);
        // _ = command.ExecuteReader();
    }
}