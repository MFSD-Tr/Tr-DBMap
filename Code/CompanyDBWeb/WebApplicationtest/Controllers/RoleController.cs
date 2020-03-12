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
    [RoutePrefix("api/Role")]
    public class RoleController : ApiController
    {
        #region "Variable Declaration"
        RoleBL RoleBLobject = new RoleBL();
        #endregion

        #region "Public Methods"
        [Route("RoleList")]
        [HttpGet]
        public IHttpActionResult RoleList()
        {
            try
            {
                List<RoleDTO> roleList = RoleBLobject.GetAllRole();
                if (roleList.Count() > 0)
                {
                    return Ok(roleList);
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
    }
}
