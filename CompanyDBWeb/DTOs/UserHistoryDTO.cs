using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UserHistoryDTO
    {
        public int Id { get; set; }
        public Nullable<short> FkRoleId { get; set; }
        public string Version { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Action { get; set; }

        public virtual RoleDTO Role { get; set; }
    }
}
