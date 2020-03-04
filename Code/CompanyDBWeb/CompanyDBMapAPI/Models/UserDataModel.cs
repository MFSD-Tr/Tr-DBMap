using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTOs;

namespace CompanyDBMapAPI.Models
{
    public class UserDataModel
    {
        public LoginDTO loginDTO { get; set; }
        public UserAddressDTO useraddressDTO { get; set; }
    }
}