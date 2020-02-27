using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AddressDTO
    {
       public AddressDTO()
        {
            this.CompanyAddresses = new HashSet<CompanyAddressDTO>();
            this.UserAddresses = new HashSet<UserAddressDTO>();
        }
    
        public int AddressId { get; set; }
        public Nullable<short> AddressType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public Nullable<int> FkStateId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<System.DateTime> LastModifiedBy { get; set; }

        public virtual StateDTO State { get; set; }
        
        public virtual ICollection<CompanyAddressDTO> CompanyAddresses { get; set; }
        public virtual ICollection<UserAddressDTO> UserAddresses { get; set; }
    }
}
