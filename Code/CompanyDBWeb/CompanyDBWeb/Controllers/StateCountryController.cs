using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTOs;
using BLL;
using CompanyDBWeb.Models;

namespace CompanyDBWeb.Controllers
{
    public class StateCountryController : Controller
    {
        public StateCountryBL obj = new StateCountryBL();
        CompanyBL companyBLobject = new CompanyBL();

        
        [HttpGet]
        public ActionResult CreateCountry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCountry(StateCountryModel model)
        {
            CountryDTO CountryDTOobject = model.countryDTO;
            obj.CreateCountry(CountryDTOobject);
            return RedirectToAction("CreateState", "StateCountry");
        }

        [HttpGet]
        public ActionResult CreateState()
        {
            StateCountryModel model = new StateCountryModel();
            model.countryList = companyBLobject.CountryList();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateState(StateCountryModel model)
        {
            StateDTO StateDTOobject = model.stateDTO;
            obj.CreateState(StateDTOobject);
            return RedirectToAction("CreateCountry", "StateCountry");
        }

        
    }
}