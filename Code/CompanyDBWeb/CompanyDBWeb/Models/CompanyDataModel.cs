using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTOs;

namespace CompanyDBWeb.Models
{
    public class CompanyDataModel
    {
        public CompanyAddressDTO companyaddressDTO { get; set; }
        public CompanyDTO companyDTO { get; set; }
        public AddressDTO addressDTO { get; set; }

        public List<CompanyAddressDTO> companyaddressList { get; set; }
        public List<CountryDTO> countryList { get; set; }
        public List<StateDTO> stateList { get; set; }
    }
}