using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Log : BaseEntity
    {
        public int UserId { get; set; }
        public int LogTypeId { get; set; }
        public string Description { get; set; }
    }
}
