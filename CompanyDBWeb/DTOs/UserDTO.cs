using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UserDTO
    {
        public UserDTO()
        {
            this.UserAddresses = new HashSet<UserAddressDTO>();
        }
    
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public Nullable<short> FkRoleId { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<short> RecordStatus { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<System.DateTime> LastModifiedBy { get; set; }

        public virtual RoleDTO Role { get; set; }
        
        public virtual ICollection<UserAddressDTO> UserAddresses { get; set; }
        public virtual ICollection<LoginDTO> Logins { get; set; }
    }
}
