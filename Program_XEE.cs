using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace SonarLint;
public static partial class Program
{
    public static void XEE()
    {
        //錯誤 - 不設置為 null 將可能導致 XXE 攻擊
        XmlDocument parser = new()
        {
            XmlResolver = new XmlUrlResolver()
        };
        parser.LoadXml("xxe.xml");

        //正確
        XmlDocument parser2 = new()
        {
            XmlResolver = null
        };
        parser2.LoadXml("xxe.xml");
    }
}