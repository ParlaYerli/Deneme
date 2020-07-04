using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Abstract
{
    public enum LogType
    {
        Login = 1,
        SendMail = 2,
        SendSMS = 3,
        DownloadPdf = 4,
        ChangePhone = 5,
        Error = 6
    }
}
