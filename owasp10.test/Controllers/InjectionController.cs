using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace owasp10.test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InjectionController : ControllerBase
    {
        public InjectionController()
        {
        }

        [HttpGet]
        public IActionResult SqlInjection([FromQuery] int username)
        {
            string connectionString = "Data Source=.;Initial Catalog=master;Integrated Security=True";
            using SqlConnection connection = new(connectionString);
            connection.Open();
            SqlCommand command = new($"SELECT * FROM TB_MemberData WHERE MEMIDNO = {username}", connection);
            // SqlCommand command = new("SELECT * FROM TB_MemberData WHERE MEMIDNO = @username", connection);
            // command.Parameters.AddWithValue("@username", "123456");
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["MEMIDNO"].ToString());
            }
            return Ok();
        }
    }
}