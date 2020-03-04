using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using CompanyDBMapAPI.Models;
using DTOs;
using BLL;

namespace CompanyDBMapAPI.Controllers
{
    [RoutePrefix("api/User")]
    public class UserAPIController : ApiController
    {
        #region "Variable Declaration"
        UserBL UserBLobject = new UserBL();
        #endregion


        #region "Public Methods"

        /// <summary>
        /// This function returns List of all Users in the UserAddress Table from the Database.
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
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        /// <summary>
        /// This function returns the details of User on the basis of UserAddressId given by the user.
        /// </summary>
        /// <param name="UserAddressId">"int" Type</param>
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
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        /// <summary>
        /// Returns details of the User on the basis of UserId.
        /// </summary>
        /// <param name="UserId">"int" Type</param>
        /// <returns></returns>
        [Route("GetUserByUserId")]
        [HttpGet]
        public IHttpActionResult GetUserByUserId([FromUri]int UserId)
        {
            try
            {
                UserDTO UserDTOobject = UserBLobject.GetUserByUserId(UserId);
                if (UserDTOobject != null)
                {
                    return Ok(UserDTOobject);
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
        /// This function returns Role of a particular User on the Basis of UserId
        /// </summary>
        /// <param name="UserId">"int" Type</param>
        /// <returns></returns>
        [Route("GetUserRole")]
        [HttpGet]
        public IHttpActionResult GetUserRole([FromUri]int UserId)
        {
            try
            {
                string role = UserBLobject.GetUserRole(UserId);
                if (role != "")
                {
                    return Ok(role);
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
        /// This function creates User in the database on the basis of Data provided.
        /// </summary>
        /// <param name="UserAddressDTOobject">"UserAddressDTO" Type</param>
        /// <returns></returns>
        [Route("CreateUser")]
        [HttpPost]
        public object CreateUser([FromBody]UserDataModel model)
        {
            try
            {
                bool flag = UserBLobject.CreateUser(model.useraddressDTO, model.loginDTO);
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
        /// <param name="UserAddressDTOobject">"UserAddressDTO" Type</param>
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


        /// <summary>
        /// This function updates User's Data from the Database 
        /// </summary>
        /// <param name="UserAddressDTOobject">"UserAddressDTO" Type</param>
        /// <returns></returns>
        [Route("DeleteUser")]
        [HttpPost]
        public HttpResponseMessage DeleteUser([FromBody]UserAddressDTO UserAddressDTOobject)
        {
            try
            {
                bool flag = UserBLobject.DeleteUser(UserAddressDTOobject);
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
