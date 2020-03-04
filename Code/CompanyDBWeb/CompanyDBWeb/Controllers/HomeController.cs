using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using CompanyDBWeb.Models;
using DTOs;

namespace CompanyDBWeb.Controllers
{
    public class HomeController : Controller
    {
        #region "HomePage Actions"

        /// <summary>
        /// This action method gives View of the HomePage.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> HomePage()
        {
            HomePageDataModel model = new HomePageDataModel();
            try
            {
                using(var client=new HttpClient())
                {
                    //CompanyList
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/CompanyList");
                    if (response.IsSuccessStatusCode)
                    {
                        model.companyaddressList = response.Content.ReadAsAsync<List<CompanyAddressDTO>>().Result;
                    }
                    //DBList
                    HttpResponseMessage response2 = await client.GetAsync("api/CompanyDBMap/CompanyDBList");
                    if (response2.IsSuccessStatusCode)
                    {
                        model.companydbList = response2.Content.ReadAsAsync<List<CompanyDBDTO>>().Result;
                    }
                    //UserList
                    HttpResponseMessage response3 = await client.GetAsync("api/CompanyDBMap/UserList");
                    if (response3.IsSuccessStatusCode)
                    {
                        model.useraddressList = response3.Content.ReadAsAsync<List<UserAddressDTO>>().Result;
                    }
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return View(model);
        }

        /// <summary>
        /// This action method returns List of CompanyDB objects linked to a particular company in Json Format.
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> CompanyDBListByCompanyIdInJson(int CompanyId)
        {
            List<CompanyDBDTO> list2 = new List<CompanyDBDTO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50297/");
                HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/CompanyDBListByCompanyId/?CompanyId=" + CompanyId);
                if (response.IsSuccessStatusCode)
                {
                    list2 = response.Content.ReadAsAsync<List<CompanyDBDTO>>().Result;
                }
                return Json(list2,JsonRequestBehavior.AllowGet);
            }
        }
        
        /// <summary>
        /// This function gives the details of the Database and the Company to which that Database is alloted
        /// in Json format.
        /// </summary>
        /// <param name="CompanyDBId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> CompanyDBInfoByIdInJson(int CompanyDBId)
        {
            CompanyDBDTO CompanyDBDTOobject = new CompanyDBDTO();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50297/");
                HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/CompanyDBDataById/?CompanyDBId=" + CompanyDBId);
                if (response.IsSuccessStatusCode)
                {
                    CompanyDBDTOobject = response.Content.ReadAsAsync<CompanyDBDTO>().Result;
                }
                return Json(CompanyDBDTOobject, JsonRequestBehavior.AllowGet);
            }
        }
        
        /// <summary>
        /// This method gives the UserData in Json Format.
        /// </summary>
        /// <param name="UserAddressId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> UserAddressInfoByIdInJson(int UserAddressId)
        {
            UserAddressDTO UserAddressDTOobject = new UserAddressDTO();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50297/");
                HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/UserDataById/?UserAddressId=" + UserAddressId);
                if (response.IsSuccessStatusCode)
                {
                    UserAddressDTOobject = response.Content.ReadAsAsync<UserAddressDTO>().Result;
                }
                return Json(UserAddressDTOobject, JsonRequestBehavior.AllowGet);
            }
        }
        
        #endregion


        #region "LogIn SignUp Actions"

        /// <summary>
        /// This action gives the View of SignIn Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Session["UserName"] = "";
            Session["AdminId"] = null;
            Session["UserId"] = null;
            return View();
        }

        /// <summary>
        /// This Action checks the login credentials entered by the user and redirected the user to the HomePage
        /// if the credentials are correct.
        /// This Action also stores Session values.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CheckLogin(LoginDataModel model)
        {
            int UserId = -1;
            UserDTO UserDTOobject = new UserDTO();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/CheckLoginData/?UserName=" + model.loginDTO.Username + "&Password=" + model.loginDTO.Password);
                    if (response.IsSuccessStatusCode)
                    {
                        UserId = response.Content.ReadAsAsync<int>().Result;
                        if (UserId > 0)
                        {
                            HttpResponseMessage response2 = await client.GetAsync("api/CompanyDBMap/GetUserByUserId/?UserId=" + UserId);
                            if (response2.IsSuccessStatusCode)
                            {
                                UserDTOobject = response2.Content.ReadAsAsync<UserDTO>().Result;
                            }
                            Session["UserName"] = UserDTOobject.FirstName;
                            if (UserDTOobject.Role.Role1 == "ADMIN")
                            {
                                Session["AdminId"] = UserId;
                                Session["UserId"] = null;
                            }
                            else
                            {
                                Session["AdminId"] = null;
                                Session["UserId"] = UserId;
                            }
                            return RedirectToAction("HomePage", "Home");
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// This action method gives View to the SignUp Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> SignUp()
        {
            UserDataModel model = new UserDataModel();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    //getting CountryList
                    HttpResponseMessage response3 = await client.GetAsync("api/CompanyDBMap/CountryList");
                    if (response3.IsSuccessStatusCode)
                    {
                        model.countryList = response3.Content.ReadAsAsync<List<CountryDTO>>().Result;
                    }
                    //getting StateList
                    HttpResponseMessage response4 = await client.GetAsync("api/CompanyDBMap/StateList");
                    if (response4.IsSuccessStatusCode)
                    {
                        model.stateList = response4.Content.ReadAsAsync<List<StateDTO>>().Result;
                    }
                    return View(model);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return RedirectToAction("Index","Home");
        }

        /// <summary>
        /// This Action method converts Image to the binary data stream and binds it to the UserAddressDTO to
        /// transfer it to UserBL through API to create a new User.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SignUp(UserDataModel model)
        {
            try
            {
                HttpPostedFileBase imgFile = Request.Files["Image"];
                byte[] imgBytes = null;
                BinaryReader reader = new BinaryReader(imgFile.InputStream);
                imgBytes = reader.ReadBytes((int)imgFile.ContentLength);
                model.useraddressDTO.User.UserProfilePicture = imgBytes;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/CompanyDBMap/CreateUser", model);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return View();
        }
        
        #endregion


        #region "Company Data Actions"

        /// <summary>
        /// This action gives view to the CompanyDetail Page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> CompanyDetailList()
        {
            CompanyDataModel model = new CompanyDataModel();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    //getting CompanyList
                    HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/CompanyList");
                    if (response.IsSuccessStatusCode)
                    {
                        model.companyaddressList = response.Content.ReadAsAsync<List<CompanyAddressDTO>>().Result;
                    }

                    //getting CountryList
                    HttpResponseMessage response2 = await client.GetAsync("api/CompanyDBMap/CountryList");
                    if (response2.IsSuccessStatusCode)
                    {
                        model.countryList = response2.Content.ReadAsAsync<List<CountryDTO>>().Result;
                    }

                    //getting StateList
                    HttpResponseMessage response3 = await client.GetAsync("api/CompanyDBMap/StateList");
                    if (response3.IsSuccessStatusCode)
                    {
                        model.stateList = response3.Content.ReadAsAsync<List<StateDTO>>().Result;
                    }
                    return View(model);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return RedirectToAction("Index","Home");
        }

        /// <summary>
        /// This Method create company by passing data entered by user to the CompanyBL through API.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CompanyDetailList(CompanyDataModel model)
        {
            try 
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/CompanyDBMap/CreateCompany", model.companyaddressDTO);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("CompanyDetailList", "Home");
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return View("CompanyDetailList");
        }

        /// <summary>
        /// This Action is used to show a particular Company's Data and give user a choice either to edit
        /// or to delete or to return back.
        /// </summary>
        /// <param name="id">PK CompanyAddressId</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> CompanyDataById(int id)
        {
            CompanyDataModel model = new CompanyDataModel();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/CompanyDataById/?CompanyId=" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        model.companyaddressDTO = response.Content.ReadAsAsync<CompanyAddressDTO>().Result;
                        return View(model);
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return RedirectToAction("CompanyDetailList", "Home");
        }

        /// <summary>
        /// This Action Method calls the API to Update Company Data.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Update(CompanyDataModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/CompanyDBMap/UpdateCompanyInfo", model.companyaddressDTO);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("CompanyDetailList", "Home");
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return RedirectToAction("CompanyDataById","Home", new { id=model.companyaddressDTO.CompanyAddressId});
        }

        /// <summary>
        /// This Action method calls API to Delete Company Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> DeleteCompany(CompanyDataModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/CompanyDBMap/DeleteCompany", model.companyaddressDTO);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("CompanyDetailList", "Home");
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return RedirectToAction("CompanyDataById","Home", new { id = model.companyaddressDTO.CompanyAddressId });
        }

        #endregion


        #region "CompanyDB Actions"

        /// <summary>
        /// This action gives view to the CompanyDBDetail Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> CompanyDBList()
        {

            CompanyDBDataModel model = new CompanyDBDataModel();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/CompanyDBList");
                    if (response.IsSuccessStatusCode)
                    {
                        model.companydbList = response.Content.ReadAsAsync<List<CompanyDBDTO>>().Result;
                    }
                    HttpResponseMessage response2 = await client.GetAsync("api/CompanyDBMap/ActiveCompanyList");
                    if(response2.IsSuccessStatusCode)
                    {
                        model.companyList = response2.Content.ReadAsAsync<List<CompanyDTO>>().Result;
                    }
                    return View(model);
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// This Method create CompanyDB by passing data entered by user to the CompanyDBMapBL through API.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CompanyDBList(CompanyDBDataModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/CompanyDBMap/CreateCompanyDB", model.companydbDTO);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("CompanyDBList", "Home");
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return View("CompanyDBList");
        }

        /// <summary>
        /// Returns CompanyDB info on the basis of Id entered by the user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> CompanyDBInfoById(int id)
        {
            CompanyDBDataModel model = new CompanyDBDataModel();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/CompanyDBDataById/?CompanyDBId=" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        model.companydbDTO = response.Content.ReadAsAsync<CompanyDBDTO>().Result;
                        return View(model);
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return RedirectToAction("CompanyDBList", "Home");
        }

        /// <summary>
        /// This Action Method calls the API to Update CompanyDB Data.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> UpdateCompanyDBInfo(CompanyDBDataModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/CompanyDBMap/UpdateCompanyDBInfo", model.companydbDTO);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("CompanyDBList", "Home");
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return RedirectToAction("CompanyDBInfoById","Home", new { id=model.companydbDTO.CompanyDBId});
        }

        /// <summary>
        /// This Action Method calls the API to Delete CompanyDB Data.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> DeleteCompanyDB(CompanyDBDataModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/CompanyDBMap/DeleteCompanyDB", model.companydbDTO);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("CompanyDBList", "Home");
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return RedirectToAction("CompanyDBInfoById","Home", new { id = model.companydbDTO.CompanyDBId });
        }
        
        #endregion


        #region "User Data Actions"

        /// <summary>
        /// This function gives View to the UserList Page. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> UserList()
        {
            UserDataModel model=new UserDataModel();
            try
            {
                using (var client =new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    //getting UserList
                    HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/UserList");
                    if(response.IsSuccessStatusCode)
                    {
                        model.useraddressList = response.Content.ReadAsAsync<List<UserAddressDTO>>().Result;
                    }
                    //getting RoleList
                    HttpResponseMessage response2 = await client.GetAsync("api/CompanyDBMap/RoleList");
                    if (response2.IsSuccessStatusCode)
                    {
                        model.roleList = response2.Content.ReadAsAsync<List<RoleDTO>>().Result;
                    }
                    //getting CountryList
                    HttpResponseMessage response3 = await client.GetAsync("api/CompanyDBMap/CountryList");
                    if (response3.IsSuccessStatusCode)
                    {
                        model.countryList = response3.Content.ReadAsAsync<List<CountryDTO>>().Result;
                    }
                    //getting StateList
                    HttpResponseMessage response4 = await client.GetAsync("api/CompanyDBMap/StateList");
                    if (response4.IsSuccessStatusCode)
                    {
                        model.stateList = response4.Content.ReadAsAsync<List<StateDTO>>().Result;
                    }
                    return View(model);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// This Action method converts Image to the binary data stream and binds it to the UserAddressDTO to
        /// transfer it to UserBL through API to create a new User.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> UserList(UserDataModel model)
        {
            try
            {
                HttpPostedFileBase imgFile = Request.Files["Image"];
                byte[] imgBytes = null;
                BinaryReader reader = new BinaryReader(imgFile.InputStream);
                imgBytes = reader.ReadBytes((int)imgFile.ContentLength);
                model.useraddressDTO.User.UserProfilePicture = imgBytes;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/CompanyDBMap/CreateUser", model);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("UserList", "Home");
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Returns User info on the basis of Id entered.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> UserInfoById(int id)
        {
            UserDataModel model = new UserDataModel();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/UserDataById/?UserAddressId=" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        model.useraddressDTO = response.Content.ReadAsAsync<UserAddressDTO>().Result;
                        return View(model);
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return RedirectToAction("UserList", "Home");
        }

        /// <summary>
        /// This Action Method calls the API to Update User Data.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> UpdateUserInfo(UserDataModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/CompanyDBMap/UpdateUserInfo", model.useraddressDTO);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("UserList", "Home");
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return RedirectToAction("UserInfoById","Home", new { id = model.useraddressDTO.UserAddressId });
        }

        /// <summary>
        /// This Action Method calls the API to Delete User Data.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> DeleteUser(UserDataModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/CompanyDBMap/DeleteUser", model.useraddressDTO);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("UserList", "Home");
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return RedirectToAction("UserInfoById", "Home", new { id = model.useraddressDTO.UserAddressId });
        }

        #endregion


        #region "Retrieval Of User Profile Image"

        public async Task<ActionResult> RetrieveUserProfileImage(int id)
        {
            UserDTO UserDTOobject = new UserDTO();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50297/");
                    HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/GetUserByUserId/?UserId=" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        UserDTOobject = response.Content.ReadAsAsync<UserDTO>().Result;
                        byte[] imgFile = UserDTOobject.UserProfilePicture;
                        Console.WriteLine(imgFile);
                        if(imgFile!=null)
                        {
                            return File(imgFile, "image/jpeg");
                        }
                        else
                        {
                            var d = System.IO.File.ReadAllBytes("C:\\Users\\Mayank Taliwal\\Videos\\pexels-photo-1820567.jpeg");
                            return File(d, "image/jpeg");
                        }
                        
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return RedirectToAction("Index","Home");
        }
        #endregion


        #region "StateList on The Basis Of Country In Json Format"
        /// <summary>
        /// This Action method returns stateList in Json Format on the basis of countryID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> StateListByCountryId(int id)
        {
            List<StateDTO> stateList = new List<StateDTO>();
            
            using (var client =new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50297/");
                //getting StateList
                HttpResponseMessage response4 = await client.GetAsync("api/CompanyDBMap/StateListByCountryId/?CountryId=" + id);
                if (response4.IsSuccessStatusCode)
                {
                    stateList = response4.Content.ReadAsAsync<List<StateDTO>>().Result;
                }
            }
           
           return Json(new { stateList, JsonRequestBehavior.AllowGet });
        }
        #endregion

    }
}