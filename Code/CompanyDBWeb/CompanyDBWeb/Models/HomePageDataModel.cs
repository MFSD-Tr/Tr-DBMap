using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTOs;

namespace CompanyDBWeb.Models
{
    public class HomePageDataModel
    {
        public CompanyAddressDTO companyaddressDTO { get; set; }
        public CompanyDBDTO companydbDTO { get; set; }
        public UserAddressDTO useraddressDTO { get; set; }

        public List<CompanyAddressDTO> companyaddressList { get; set; }
        public List<CompanyDBDTO> companydbList { get; set; }
        public List<UserAddressDTO> useraddressList { get; set; }
    }
}