using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class RoleDTO
    {
        public RoleDTO()
        {
            this.Users = new HashSet<UserDTO>();
            this.UserHistories = new HashSet<UserHistoryDTO>();
        }
    
        public short RoleId { get; set; }
        public string Role1 { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<short> RecordStatus { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<System.DateTime> LastModifiedBy { get; set; }
    
        public virtual ICollection<UserDTO> Users { get; set; }
        public virtual ICollection<UserHistoryDTO> UserHistories { get; set; }
    }
}
