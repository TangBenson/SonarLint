using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace SonarLint;
public static partial class Program
{
    public static void SensitiveDataExposure(string username, string password)
    {
        //錯誤 - 將敏感數據記錄到日誌中
        Logger logger = LogManager.GetCurrentClassLogger();
        logger.Info("Username: " + username + ", Password: " + password);

        //正確
        logger.Info("UN: {0}, PVV: {1}", username, password);
    }
}
