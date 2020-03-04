using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DTOs;
using DAL;
using DAL.UnitOfWork;

namespace BLL
{
    public class LoginBL
    {
        #region "Variable Declaration"
        public UnitOfWork uow = new UnitOfWork();
        #endregion

        #region "Public Methods"
        /// <summary>
        /// This function check whether the login credentials provided by the User are present in the Login table
        /// If present then the fuction returns the UserId to which the LoginCredentials are associsted with
        /// Otherwise it returns -1;
        /// </summary>
        /// <param name="LoginDTOobject"></param>
        /// <returns></returns>
        public int CheckLoginData(LoginDTO LoginDTOobject)
        {
            int UserId = -1;
            try
            {
                Login loginObj = uow.LoginRepo.GetAll().Where(a => a.Username == LoginDTOobject.Username && a.Password == LoginDTOobject.Password).FirstOrDefault();
                UserId=Convert.ToInt32(loginObj.FkUserId);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return UserId;
        }
        #endregion
    }
}
