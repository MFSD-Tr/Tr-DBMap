using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class StateDTO
    {
        public StateDTO()
        {
            this.Addresses = new HashSet<AddressDTO>();
        }
    
        public int StateId { get; set; }
        public string State1 { get; set; }
        public string StateCode { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<short> RecordStatus { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<System.DateTime> LastModifiedBy { get; set; }
        public Nullable<short> FkCountryId { get; set; }
    
        public virtual ICollection<AddressDTO> Addresses { get; set; }
        public virtual CountryDTO Country { get; set; }
    }
}
