using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using CompanyDBWeb.Models;
using CompanyDBWeb.Controllers;
using DTOs;

namespace CompanyDBWeb.Controllers
{
    public class HomeController : Controller
    {
        #region "HomePage Actions"
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
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CheckLogin(LoginDataModel model)
        {
            int UserId = -1;
            UserDataModel userDataModelObj = new UserDataModel();
            string role = "";
            UserDTO UserDTOobject = new UserDTO();
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
                        if(response2.IsSuccessStatusCode)
                        {
                            UserDTOobject = response2.Content.ReadAsAsync<UserDTO>().Result;
                        }
                        Session["UserName"] = UserDTOobject.FirstName;
                        if(UserDTOobject.Role.Role1=="ADMIN")
                        {
                            Session["AdminId"] = UserId;
                            Session["UserId"] = null;
                        }
                        else
                        {
                            Session["AdminId"] = null;
                            Session["UserId"] = UserId;
                        }
                        //HttpResponseMessage response2 = await client.GetAsync("api/CompanyDBMap/GetUser/?UserId=" + UserId);
                        //if (response2.IsSuccessStatusCode)
                        //{
                        //    userDataModelObj.userDTO = response2.Content.ReadAsAsync<UserDTO>().Result;
                        //    if (userDataModelObj.userDTO.Role.Role1 == "ADMIN")
                        //    {
                        //        Session["AdminId"] = UserId;
                        //    }
                        //    else
                        //    {
                        //        Session["UserId"] = UserId;
                        //    }
                        //    return View("CompanyDetailList", "Home");
                        //}
                        return RedirectToAction("CompanyDetailList", "Home");
                    }
                }
                return View("Index", "Home");
            }
        }

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
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(UserDataModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50297/");
                HttpResponseMessage response = await client.PostAsJsonAsync("api/CompanyDBMap/CreateUser", model);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
        }
        #endregion


        #region "Company Data Actions"
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
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> CompanyDetailList(CompanyDataModel model)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50297/");
                HttpResponseMessage response = await client.PostAsJsonAsync("api/CompanyDBMap/CreateCompany", model.companyaddressDTO);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("CompanyDetailList", "Home");
                }
                return View();
            }
        }

        /// <summary>
        /// "Edit" Action is used to provide user with a choice to edit CompanyPersonalData
        /// </summary>
        /// <param name="id">PK CompanyAddressId</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> CompanyDataById(int id)
        {
            CompanyDataModel model = new CompanyDataModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50297/");
                HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/CompanyDataById/?CompanyId=" + id);
                if (response.IsSuccessStatusCode)
                {
                    model.companyaddressDTO = response.Content.ReadAsAsync<CompanyAddressDTO>().Result;
                }
                return View(model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update(CompanyDataModel model)
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
            return View("CompanyDataById", new { id=model.companyaddressDTO.CompanyAddressId});
        }
        #endregion


        #region "CompanyDB Actions"
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
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> CompanyDBList(CompanyDBDataModel model)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50297/");
                HttpResponseMessage response = await client.PostAsJsonAsync("api/CompanyDBMap/CreateCompanyDB", model.companydbDTO);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("CompanyDBList", "Home");
                }
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> CompanyDBInfoById(int id)
        {
            CompanyDBDataModel model = new CompanyDBDataModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50297/");
                HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/CompanyDBDataById/?CompanyDBId=" + id);
                if (response.IsSuccessStatusCode)
                {
                    model.companydbDTO = response.Content.ReadAsAsync<CompanyDBDTO>().Result;
                }
                return View(model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateCompanyDBInfo(CompanyDBDataModel model)
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
            return View("CompanyDBInfoById", new { id=model.companydbDTO.CompanyDBId});
        }
        #endregion


        #region "User Data Actions"
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
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> UserList(UserDataModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50297/");
                HttpResponseMessage response = await client.PostAsJsonAsync("api/CompanyDBMap/CreateUser", model);
                if (response.IsSuccessStatusCode)
                {
                    if (Session["AdminId"] == null && Session["UserId"] == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction("UserList", "Home");
                }
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> UserInfoById(int id)
        {
            UserDataModel model = new UserDataModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50297/");
                HttpResponseMessage response = await client.GetAsync("api/CompanyDBMap/UserDataById/?UserAddressId=" + id);
                if (response.IsSuccessStatusCode)
                {
                    model.useraddressDTO = response.Content.ReadAsAsync<UserAddressDTO>().Result;
                }
                return View(model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUserInfo(UserDataModel model)
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
            return RedirectToAction("UserInfoById","Home", new { id = model.useraddressDTO.UserAddressId });
        }
        #endregion


        #region "StateList Action"
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


        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}