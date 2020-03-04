using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using BLL;
using DTOs;

namespace CompanyDBMapAPI.Controllers
{
    [RoutePrefix("api/Company")]
    public class CompanyAPIController : ApiController
    {
        #region "Variable Declaration"
        CompanyBL CompanyBLobject = new CompanyBL();
        #endregion

        #region "Public Methods"

        /// <summary>
        /// This function returns List of all Company in the CompanyAddress Table from the Database.
        /// </summary>
        /// <returns></returns>
        [Route("CompanyList")]
        [HttpGet]
        public IHttpActionResult CompanyList()
        {
            try
            {
                List<CompanyAddressDTO> companyList = CompanyBLobject.GetCompanyList();
                if (companyList.Count() > 0)
                    return Ok(companyList);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        /// <summary>
        /// This function returns List of Companies where attribute "Active=True" from the CompanyTable  from the Database.
        /// </summary>
        /// <returns></returns>
        [Route("ActiveCompanyList")]
        [HttpGet]
        public IHttpActionResult ActiveCompanyList()
        {
            try
            {
                List<CompanyDTO> companyList = CompanyBLobject.GetActiveCompanyList();
                if (companyList.Count() > 0)
                    return Ok(companyList);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        /// <summary>
        /// This function returns the details of CompanyPersonalData on the basis of CompanyId given by the user
        /// </summary>
        /// <param name="CompanyId">"int" Type</param>
        /// <returns></returns>
        [Route("CompanyDataById")]
        [HttpGet]
        public IHttpActionResult CompanyDataById([FromUri]int CompanyId)
        {
            try
            {
                CompanyAddressDTO CompanyAddressDTOobject = CompanyBLobject.GetCompanyPersonalDataById(CompanyId);
                if (CompanyAddressDTOobject != null)
                {
                    return Ok(CompanyAddressDTOobject);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        /// <summary>
        /// This function creates Company in the database on the basis of details provided by the user
        /// </summary>
        /// <param name="CompanyAddressDTOobject">"CompanyAddressDTO" Type</param>
        /// <returns></returns>
        [Route("CreateCompany")]
        [HttpPost]
        public HttpResponseMessage CreateCompany([FromBody]CompanyAddressDTO CompanyAddressDTOobject)
        {
            try
            {
                bool flag = CompanyBLobject.CreateCompany(CompanyAddressDTOobject);
                if (flag == true)
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        /// <summary>
        /// This function updates Company's Personal Data in the database on the basis of "edited" details provided by the user
        /// </summary>
        /// <param name="CompanyAddressDTOobject">"CompanyAddressDTO" Type</param>
        /// <returns></returns>
        [Route("UpdateCompanyInfo")]
        [HttpPost]
        public HttpResponseMessage UpdateCompanyInfo([FromBody]CompanyAddressDTO CompanyAddressDTOobject)
        {
            try
            {
                bool flag = CompanyBLobject.UpdateCompanyPersonalData(CompanyAddressDTOobject);
                if (flag == true)
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        /// <summary>
        /// This function updates Company's Personal Data from the Database 
        /// </summary>
        /// <param name="CompanyAddressDTOobject">"CompanyAddressDTO" Type</param>
        /// <returns></returns>
        [Route("DeleteCompany")]
        [HttpPost]
        public HttpResponseMessage DeleteCompany([FromBody]CompanyAddressDTO CompanyAddressDTOobject)
        {
            try
            {
                bool flag = CompanyBLobject.DeleteCompany(CompanyAddressDTOobject);
                if (flag == true)
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        #endregion
    }
}
