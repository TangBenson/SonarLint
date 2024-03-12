using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace owasp10.test.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CryptographicFailuresController : ControllerBase
{
    public CryptographicFailuresController()
    {
    }

    public IActionResult Sha1([FromQuery] string data)
    {
        StringBuilder sb = new();
        byte[] hash = System.Security.Cryptography.SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(data));
        //將hash值轉換成16進位
        foreach (byte b in hash)
        {
            sb.Append(b.ToString("X2"));
        }

        return Ok(sb.ToString());
    }

    public IActionResult Sha256([FromQuery] string data)
    {
        StringBuilder sb = new();
        byte[] hash = System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(data));

        // 將hash值字节数组bytes转换成十六进制字符串表示，然后去掉其中的所有"-"字符，最后将字符串转换成小写
        return Ok(BitConverter.ToString(hash).Replace("-", "").ToLower());
    }

}