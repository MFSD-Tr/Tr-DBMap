using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTOs;

namespace CompanyDBWeb.Models
{
    public class UserDataModel
    {
        public UserAddressDTO useraddressDTO { get; set; }
        public UserDTO userDTO { get; set; }
        public AddressDTO addressDTO { get; set; }
        public RoleDTO roleDTO { get; set; }
        public StateDTO stateDTO { get; set; }
        public CountryDTO countryDTO { get; set; }
        public LoginDTO loginDTO { get; set; }

        public List<UserAddressDTO> useraddressList { get; set; }
        public List<RoleDTO> roleList { get; set; }
        public List<StateDTO> stateList { get; set; }
        public List<CountryDTO> countryList { get; set; }
    }
}