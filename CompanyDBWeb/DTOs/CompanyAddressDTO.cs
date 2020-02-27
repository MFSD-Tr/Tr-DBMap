using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CompanyAddressDTO
    {
        public int CompanyAddressId { get; set; }
        public Nullable<int> FkCompanyId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> FkAddressId { get; set; }

        public virtual AddressDTO Address { get; set; }
        public virtual CompanyDTO Company { get; set; }
    }
}
