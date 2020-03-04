using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UserAddressDTO
    {
        public int UserAddressId { get; set; }
        public Nullable<int> FkUserId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> FkAddressId { get; set; }

        public virtual AddressDTO Address { get; set; }
        public virtual UserDTO User { get; set; }
    }
}
