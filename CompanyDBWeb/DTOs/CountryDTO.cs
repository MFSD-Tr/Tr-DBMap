using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CountryDTO
    {
        public CountryDTO()
        {
            this.States = new HashSet<StateDTO>();
        }
    
        public short CountryId { get; set; }
        public string Country1 { get; set; }
        public string CountryCode { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<short> RecordStatus { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<System.DateTime> LastModifiedBy { get; set; }
    
        public virtual ICollection<StateDTO> States { get; set; }
    }
}
