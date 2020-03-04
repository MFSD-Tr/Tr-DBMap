using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using DTOs;
using BLL;

namespace CompanyDBMapAPI.Controllers
{
    [RoutePrefix("api/StateCountry")]
    public class StateCountryAPIController : ApiController
    {
        #region "Variable Declaration"
        StateCountryBL StateCountryBLobject = new StateCountryBL();
        #endregion

        #region "Public Methods"
        /// <summary>
        /// This function returns List of all Countries from the Database.
        /// </summary>
        /// <returns></returns>
        [Route("CountryList")]
        [HttpGet]
        public IHttpActionResult CountryList()
        {
            try
            {
                List<CountryDTO> countryList = StateCountryBLobject.CountryList();
                if (countryList.Count() > 0)
                    return Ok(countryList);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// This function returns List of all States from the Database.
        /// </summary>
        /// <returns></returns>
        [Route("StateList")]
        [HttpGet]
        public IHttpActionResult StateList()
        {
            try
            {
                List<StateDTO> stateList = StateCountryBLobject.StateList();
                if (stateList.Count() > 0)
                    return Ok(stateList);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// This function returns List of states on the basis of CountryId from the Database.
        /// </summary>
        /// <param name="CountryId">"int" Type</param>
        /// <returns></returns>
        [Route("StateListByCountryId")]
        [HttpGet]
        public IHttpActionResult StateListByCountryId([FromUri]int CountryId)
        {
            try
            {
                List<StateDTO> stateList = StateCountryBLobject.StateListByCountryId(CountryId);
                if (stateList.Count() > 0)
                    return Ok(stateList);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        #endregion

    }
}
