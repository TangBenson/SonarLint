using Microsoft.AspNetCore.Mvc;
using owasp10.test.Model;

namespace owasp10.test.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrokenAcccessControlController : ControllerBase
{
    List<Person> persons = new()
    {
        new() { Id = 0, Name = "John", Age = 29, Address = "Taipei" },
        new() { Id = 1, Name = "Mary", Age = 35, Address = "Taipei" },
        new() { Id = 2, Name = "Benson", Age = 34, Address = "Taipei" },
        new() { Id = 3, Name = "Peggy", Age = 27, Address = "Taipei" },
        new() { Id = 4, Name = "Tom", Age = 30, Address = "Taipei" }
    };

    public BrokenAcccessControlController()
    {
    }

    //未驗證是否為此id的使用者
    [HttpGet]
    public IActionResult AccountInfo([FromQuery] int id)
    {
        return Ok(persons.Where(p => p.Age == id).FirstOrDefault());
    }

    //未驗證是否為管理員
    [HttpGet]
    public IActionResult AdminAccountInfo()
    {
        return Ok(persons.Select(p => new { p.Id, p.Name, p.Age, p.Address }));
    }
}