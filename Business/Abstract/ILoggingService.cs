using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ILoggingService
    {
        void Log(string logDesc, LogType logTypeId, int userId);
    }
}
