using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SonarLint;
public static partial class Program
{
    //訪問控制缺陷
    public static void BrokenAccessControl(int id)
    {
        string connectionString = "Data Source=.;Initial Catalog=master;Integrated Security=True";
        using SqlConnection connection = new(connectionString);
        connection.Open();
        SqlCommand command = new($"DELETE FROM users WHERE UserId = {id}", connection);
        _ = command.ExecuteReader();
    }
}
