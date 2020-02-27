using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CompanyDTO
    {
        public CompanyDTO()
        {
            this.CompanyAddresses = new HashSet<CompanyAddressDTO>();
            this.CompanyDBs = new HashSet<CompanyDBDTO>();
        }
    
        public int CompanyId { get; set; }
        public string Company1 { get; set; }
        public string CompanyCode { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<short> RecordStatus { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<System.DateTime> LastModifiedBy { get; set; }
    
        public virtual ICollection<CompanyAddressDTO> CompanyAddresses { get; set; }
        public virtual ICollection<CompanyDBDTO> CompanyDBs { get; set; }
    }
}
