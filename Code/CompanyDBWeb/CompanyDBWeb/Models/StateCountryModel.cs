using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTOs;

namespace CompanyDBWeb.Models
{
    public class StateCountryModel
    {
        public StateDTO stateDTO { get; set; }
        public CountryDTO countryDTO { get; set; }

        public List<CountryDTO> countryList { get; set; }
    }
}