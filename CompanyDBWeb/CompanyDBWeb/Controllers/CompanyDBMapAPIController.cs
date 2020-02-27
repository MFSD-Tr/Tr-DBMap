﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using CompanyDBWeb.Models;
using DTOs;
using BLL;

namespace CompanyDBWeb.Controllers
{
    [RoutePrefix("api/CompanyDBMap")]
    public class CompanyDBMapAPIController : ApiController
    {
        #region "Variable Declaration"
        CompanyBL CompanyBLobject = new CompanyBL();
        CompanyDBMapBL CompanyDBMapBLobject = new CompanyDBMapBL();
        UserBL UserBLobject = new UserBL();
        LoginBL LoginBLobject = new LoginBL();
        #endregion


        #region "Public Methods"

        #region "Check Login Credentials"
        [Route("CheckLoginData")]
        [HttpGet]
        public IHttpActionResult CheckLoginData([FromUri]String UserName,[FromUri]String Password)
        {
            LoginDTO LoginDTOobject = new LoginDTO();
            try
            {
                LoginDTOobject.Username = UserName;
                LoginDTOobject.Password = Password;
                int UserId = LoginBLobject.CheckLoginData(LoginDTOobject);
                if (UserId > 0)
                    return Ok(UserId);
                else
                    return NotFound();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
           
        #endregion


        #region "List Functions"
        /// <summary>
        /// This function returns List of countries from the Database.
        /// </summary>
        /// <returns></returns>
        [Route("CountryList")]
        [HttpGet]
        public IHttpActionResult CountryList()
        {
            try
            {
                List<CountryDTO> countryList = CompanyBLobject.CountryList();
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
        /// This function returns List of states from the Database.
        /// </summary>
        /// <returns></returns>
        [Route("StateList")]
        [HttpGet]
        public IHttpActionResult StateList()
        {
            try
            {
                List<StateDTO> stateList = CompanyBLobject.StateList();
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
        /// <returns></returns>
        [Route("StateListByCountryId")]
        [HttpGet]
        public IHttpActionResult StateListByCountryId([FromUri]int CountryId)
        {
            try
            {
                List<StateDTO> stateList = CompanyBLobject.StateListByCountryId(CountryId);
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
        /// This function returns List of objects of CompanyAddress Table from the Database.
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
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// This function returns List of objects of CompanyDB Table from the Database.
        /// </summary>
        /// <returns></returns>
        [Route("CompanyDBList")]
        [HttpGet]
        public IHttpActionResult CompanyDBList()
        {
            try
            {
                List<CompanyDBDTO> companyDBList = CompanyDBMapBLobject.GetAll();
                if (companyDBList.Count() >0)
                    return Ok(companyDBList);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

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
        /// This function returns List of Companies whose "ActiveStatus=True" from the CompanyTable  from the Database.
        /// </summary>
        /// <returns></returns>
        [Route("ActiveCompanyList")]
        [HttpGet]
        public IHttpActionResult ActiveCompanyList()
        {
            try
            {
                List<CompanyDTO> companyList = CompanyDBMapBLobject.GetCompanyList();
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
        /// This function returns List of objects of UserAddress Table from the Database.
        /// </summary>
        /// <returns></returns>
        [Route("UserList")]
        [HttpGet]
        public IHttpActionResult UserList()
        {
            try
            {
                List<UserAddressDTO> userAddressList = UserBLobject.GetAllUser();
                if (userAddressList.Count() > 0)
                    return Ok(userAddressList);
                else
                    return NotFound();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("RoleList")]
        [HttpGet]
        public IHttpActionResult RoleList()
        {
            try
            {
                List<RoleDTO> roleList = UserBLobject.GetAllRole();
                if (roleList.Count() > 0)
                    return Ok(roleList);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        #endregion


        #region "GetById Functions"
        /// <summary>
        /// This function returns the details of CompanyPersonalData on the basis of CompanyId given by the user
        /// </summary>
        /// <param name="CompanyId"></param>
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
        /// This function returns the details of CompanyDBData on the basis of CompanyDBId given by the user
        /// </summary>
        /// <param name="CompanyDBId"></param>
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
        /// This function returns the details of User on the basis of UserAddressId given by the user.
        /// </summary>
        /// <param name="UserAddressId"></param>
        /// <returns></returns>
        [Route("UserDataById")]
        [HttpGet]
        public IHttpActionResult UserDataById([FromUri]int UserAddressId)
        {
            try
            {
                UserAddressDTO UserAddressDTOobject = UserBLobject.GetUserByUserAddressId(UserAddressId);
                if (UserAddressDTOobject != null)
                    return Ok(UserAddressDTOobject);
                else
                    return NotFound();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Returns User object on the basis of UserId.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [Route("GetUserByUserId")]
        [HttpGet]
        public IHttpActionResult GetUserByUserId([FromUri]int UserId)
        {
            try
            {
                UserDTO UserDTOobject = UserBLobject.GetUserByUserId(UserId);
                if(UserDTOobject!=null)
                {
                    return Ok(UserDTOobject);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }


        [Route("GetUserRole")]
        [HttpGet]
        public IHttpActionResult GetUserRole([FromUri]int UserId)
        {
            try
            {
                string role = UserBLobject.GetUserRole(UserId);
                if(role!="")
                {
                    return Ok(role);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        #endregion


        #region "Create Functions"
        /// <summary>
        /// This function creates Company in the database on the basis of details provided by the user
        /// </summary>
        /// <param name="CompanyAddressDTOobject"></param>
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
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// This function adds Company's Database Details in the database on the basis of details provided by the user
        /// </summary>
        /// <param name="CompanyDBDTOobject"></param>
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
        /// This function adds UserData to the database.
        /// </summary>
        /// <param name="UserAddressDTOobject"></param>
        /// <returns></returns>
        [Route("CreateUser")]
        [HttpPost]
        public object CreateUser([FromBody]UserDataModel model)
        {
            try
            {
                bool flag = UserBLobject.CreateUser(model.useraddressDTO,model.loginDTO);
                if (flag == true)
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        #endregion


        #region "Update Functions"
        /// <summary>
        /// This function updates Company Personal Data in the database on the basis of "edited" details provided by the user
        /// </summary>
        /// <param name="CompanyAddressDTOobject"></param>
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
        /// This function updates Company's Database Details in the database on the basis of "edited" details provided by the user
        /// </summary>
        /// <param name="CompanyDBDTOobject"></param>
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
        /// This function updates UserData.
        /// </summary>
        /// <param name="UserAddressDTOobject"></param>
        /// <returns></returns>
        [Route("UpdateUserInfo")]
        [HttpPost]
        public HttpResponseMessage UpdateUserInfo([FromBody] UserAddressDTO UserAddressDTOobject)
        {
            try
            {
                bool flag = UserBLobject.UpdateUser(UserAddressDTOobject);
                if (flag != false)
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

        #endregion
    }
}
