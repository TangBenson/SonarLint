using SonarLint.Model;

namespace SonarLint;

public static partial class Program
{
    static void Main(string[] args)
    {
        var personlst = new List<Person>
        {
            new() { Name = "John", Age = 25, Address = "USA" },
            new() { Name = "Smith", Age = 30, Address = "UK" },
            new() { Name = "David", Age = 35, Address = "AUS" }
        };
        // 錯誤 - 提醒程式碼違反了規則 S3169 和 S1481
        // https://rules.sonarsource.com/csharp/RSPEC-3169/
        // https://rules.sonarsource.com/csharp/RSPEC-1481/
        var x = personlst.OrderBy(p => p.Name).OrderBy(p => p.Age).ToList();

        // 正確
        var y = personlst.OrderBy(p => p.Name).ThenBy(p => p.Age).ToList();
        Console.WriteLine(y.Count);
    }
}

