using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DatabaseInfoDTO
    {
        public DatabaseInfoDTO()
        {
            this.CompanyDBs = new HashSet<CompanyDBDTO>();
        }
    
        public int DatabaseInfoId { get; set; }
        public string ServerName { get; set; }
        public string Authentication { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<short> RecordStatus { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<System.DateTime> LastModifiedBy { get; set; }
    
        public virtual ICollection<CompanyDBDTO> CompanyDBs { get; set; }
    }
}
