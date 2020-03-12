using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using BLL;
using DTOs;

namespace CompanyDBMapWebAPI.Controllers
{
    [RoutePrefix("api/CompanyDB")]
    public class CompanyDBController : ApiController
    {
        #region "Variable Declaration"
        CompanyDBMapBL CompanyDBMapBLobject = new CompanyDBMapBL();
        #endregion

        #region "Public Methods"

        /// <summary>
        /// This function returns List of all ComapnyDatabases in the CompanyDB Table from the Database.
        /// </summary>
        /// <returns></returns>
        [Route("CompanyDBList")]
        [HttpGet]
        public IHttpActionResult CompanyDBList()
        {
            try
            {
                List<CompanyDBDTO> companyDBList = CompanyDBMapBLobject.GetAll();
                if (companyDBList.Count() > 0)
                    return Ok(companyDBList);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// This function return List of CompanyDatabases from the CompanyDB Table on the basis of CompanyId .
        /// </summary>
        /// <param name="CompanyId">"int" Type</param>
        /// <returns></returns>
        [Route("CompanyDBListByCompanyId")]
        [HttpGet]
        public IHttpActionResult CompanyDBListByCompanyId([FromUri]int CompanyId)
        {
            try
            {
                List<CompanyDBDTO> companyDBList = CompanyDBMapBLobject.GetAllByCompanyId(CompanyId);
                if (companyDBList.Count() > 0)
                    return Ok(companyDBList);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        /// <summary>
        /// This function returns the details of CompanyDBData on the basis of CompanyDBId given by the user
        /// </summary>
        /// <param name="CompanyDBId">"int" Type</param>
        /// <returns></returns>
        [Route("CompanyDBDataById")]
        [HttpGet]
        public IHttpActionResult CompanyDBDataById([FromUri]int CompanyDBId)
        {
            try
            {
                CompanyDBDTO CompanyDBDTOobject = CompanyDBMapBLobject.GetById(CompanyDBId);
                if (CompanyDBDTOobject != null)
                {
                    return Ok(CompanyDBDTOobject);
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
        /// This function adds Company's Database Details in the database on the basis of details provided by the user
        /// </summary>
        /// <param name="CompanyDBDTOobject">"CompanyDBDTO" Type</param>
        /// <returns></returns>
        [Route("CreateCompanyDB")]
        [HttpPost]
        public HttpResponseMessage CreateCompanyDB([FromBody]CompanyDBDTO CompanyDBDTOobject)
        {
            try
            {
                bool flag = CompanyDBMapBLobject.AddCompanyDBInfo(CompanyDBDTOobject);
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
        /// This function updates Company's Database Details in the database on the basis of "edited" details provided by the user
        /// </summary>
        /// <param name="CompanyDBDTOobject">"CompanyDBDTO" Type</param>
        /// <returns></returns>
        [Route("UpdateCompanyDBInfo")]
        [HttpPost]
        public HttpResponseMessage UpdateCompanyDBInfo([FromBody]CompanyDBDTO CompanyDBDTOobject)
        {
            try
            {
                bool flag = CompanyDBMapBLobject.UpdateCompanyDBInfo(CompanyDBDTOobject);
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
        /// This function updates Company's Database Data from the Database 
        /// </summary>
        /// <param name="CompanyDBDTOobject">"CompanyDBDTO" Type</param>
        /// <returns></returns>
        [Route("DeleteCompanyDB")]
        [HttpPost]
        public HttpResponseMessage DeleteCompanyDB([FromBody]CompanyDBDTO CompanyDBDTOobject)
        {
            try
            {
                bool flag = CompanyDBMapBLobject.DeleteCompanyDB(CompanyDBDTOobject);
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
