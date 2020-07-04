using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class User : BaseEntity
    {
        public int? DealerId { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string DealerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public int RoleId { get; set; }
    }
}
