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
    [RoutePrefix("api/Login")]
    public class LoginAPIController : ApiController
    {
        #region "Variable Declaration"
        LoginBL LoginBLobject = new LoginBL();
        #endregion

        #region "Public Methods"

        /// <summary>
        /// "CheckLoginData" function takes UserName & Password as input and returns OK if UserName & Password
        /// are present in the Database otherwise returns NotFound.
        /// </summary>
        /// <param name="UserName">"String" Type</param>
        /// <param name="Password">"String" Type</param>
        /// <returns></returns>
        [Route("CheckLoginData")]
        [HttpGet]
        public IHttpActionResult CheckLoginData([FromUri]String UserName, [FromUri]String Password)
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
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        #endregion
    }
}
