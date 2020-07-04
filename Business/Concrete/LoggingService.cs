using Business.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class LoggingService : ILoggingService
    {
        public LoggingService(IConfiguration config)
        {
            _config = config;
        }
        public IConfiguration _config { get; set; }


        public void Log(string logDesc, Entities.Abstract.LogType logTypeId, int userId)
        {
            Log log = new Log()
            {
                UserId = userId,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                Description = logDesc,
                LogTypeId = (int)logTypeId
            };
            using (UserContext db = new UserContext())
            {
                db.Logs.Add(log);
                db.SaveChanges();
            }
        }
    }
}
