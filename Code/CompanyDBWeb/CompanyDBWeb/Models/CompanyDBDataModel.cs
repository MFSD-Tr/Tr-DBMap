using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTOs;

namespace CompanyDBWeb.Models
{
    public class CompanyDBDataModel
    {
        public CompanyDBDTO companydbDTO { get; set; }
        public DatabaseInfoDTO databaseinfoDTO { get; set; }
        public CompanyDTO companyDTO { get; set; }

        public List<CompanyDBDTO> companydbList { get; set; }
        public List<CompanyAddressDTO> companyaddressList { get; set; }
        public List<CompanyDTO> companyList { get; set; }
    }
}