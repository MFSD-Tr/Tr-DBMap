using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CompanyDBDTO
    {
        public int CompanyDBId { get; set; }
        public Nullable<int> FkCompanyId { get; set; }
        public Nullable<int> FkDatabaseInfoId { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<short> RecordStatus { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<System.DateTime> LastModifiedBy { get; set; }

        public virtual CompanyDTO Company { get; set; }
        public virtual DatabaseInfoDTO DatabaseInfo { get; set; }
    }
}
