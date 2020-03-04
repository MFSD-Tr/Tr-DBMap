using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DAL;
using DAL.UnitOfWork;
using DTOs;

namespace BLL
{
    public class UserBL
    {
        #region "Variable Declaration"
        public UnitOfWork uow = new UnitOfWork();
        #endregion

        #region "Public Methods"

        /// <summary>
        /// This function returns the list of all Users in the UserAddress Table.
        /// </summary>
        /// <returns></returns>
        public List<UserAddressDTO> GetAllUser()
        {
            List<UserAddressDTO> userAddressList = new List<UserAddressDTO>();
            try
            {
                List<UserAddress> list = uow.UserAddressRepo.GetAll().ToList();
                foreach(var row in list)
                {
                    userAddressList.Add(new UserAddressDTO()
                    {
                        UserAddressId=row.UserAddressId,
                        FkUserId=row.FkUserId,
                        FkAddressId=row.FkAddressId,
                        CreatedBy=row.CreatedBy,
                        CreatedDate=row.CreatedDate,

                        User = new UserDTO
                        {
                            UserId=row.User.UserId,
                            FirstName=row.User.FirstName,
                            MiddleName=row.User.MiddleName,
                            LastName=row.User.LastName,
                            DOB=row.User.DOB,
                            HireDate=row.User.HireDate,
                            ReleaseDate=row.User.ReleaseDate,
                            FkRoleId=row.User.FkRoleId,
                            Active=row.User.Active,
                            RecordStatus=row.User.RecordStatus,
                            CreatedBy=row.User.CreatedBy,
                            CreatedDate=row.User.CreatedDate,
                            LastModifiedBy=row.User.LastModifiedBy,
                            LastModifiedDate=row.User.LastModifiedDate,
                            Role = new RoleDTO
                            {
                                RoleId=row.User.Role.RoleId,
                                Role1=row.User.Role.Role1,
                                Active=row.User.Role.Active,
                                RecordStatus=row.User.Role.RecordStatus,
                                CreatedBy=row.User.Role.CreatedBy,
                                CreatedDate=row.User.Role.CreatedDate,
                                LastModifiedBy=row.User.Role.LastModifiedBy,
                                LastModifiedDate=row.User.Role.LastModifiedDate
                            }
                        },
                        
                        Address = new AddressDTO
                        {
                            AddressId=row.Address.AddressId,
                            Address1=row.Address.Address1,
                            Address2=row.Address.Address2,
                            AddressType=row.Address.AddressType,
                            City=row.Address.City,
                            FkStateId=row.Address.FkStateId,
                            CreatedDate=row.Address.CreatedDate,
                            CreatedBy=row.Address.CreatedBy,
                            LastModifiedBy=row.Address.LastModifiedBy,
                            LastModifiedDate=row.Address.LastModifiedDate,
                           
                            State = new StateDTO
                            {
                                StateId=row.Address.State.StateId,
                                State1=row.Address.State.State1,
                                StateCode=row.Address.State.StateCode,
                                FkCountryId=row.Address.State.FkCountryId,
                                Active=row.Address.State.Active,
                                RecordStatus=row.Address.State.RecordStatus,
                                CreatedDate=row.Address.State.CreatedDate,
                                CreatedBy=row.Address.State.CreatedBy,
                                LastModifiedBy=row.Address.State.LastModifiedBy,
                                LastModifiedDate=row.Address.State.LastModifiedDate,
                                
                                Country = new CountryDTO
                                {
                                    CountryId=row.Address.State.Country.CountryId,
                                    Country1=row.Address.State.Country.Country1,
                                    CountryCode=row.Address.State.Country.CountryCode,
                                    Active=row.Address.State.Country.Active,
                                    RecordStatus=row.Address.State.Country.RecordStatus,
                                    CreatedBy=row.Address.State.Country.CreatedBy,
                                    CreatedDate=row.Address.State.Country.CreatedDate,
                                    LastModifiedBy=row.Address.State.Country.LastModifiedBy,
                                    LastModifiedDate=row.Address.State.Country.LastModifiedDate
                                }
                            }
                        }
                    });
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return userAddressList;
        }


        /// <summary>
        /// This function returns the list of all available roles in the Role table.
        /// </summary>
        /// <returns></returns>
        public List<RoleDTO> GetAllRole()
        {
            List<RoleDTO> roleList = new List<RoleDTO>();
            try
            {
                List<Role> list = uow.RoleRepo.GetAll().ToList();
                foreach(var row in list)
                {
                    roleList.Add(new RoleDTO()
                    {
                        RoleId=row.RoleId,
                        Role1=row.Role1,
                        Active=row.Active,
                        RecordStatus=row.RecordStatus,
                        CreatedBy=row.CreatedBy,
                        CreatedDate=row.CreatedDate,
                        LastModifiedBy=row.LastModifiedBy,
                        LastModifiedDate=row.LastModifiedDate
                    });
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return roleList;
        }


        /// <summary>
        /// This function returns User's Personal and Address Details on the basis of UserAddressId.
        /// </summary>
        /// <param name="UserAddressId"></param>
        /// <returns></returns>
        public UserAddressDTO GetUserByUserAddressId(int UserAddressId)
        {
            UserAddressDTO UserAddressDTOobject = new UserAddressDTO();
            try
            {
                UserAddress useraddressObj = uow.UserAddressRepo.GetById(UserAddressId);

                UserAddressDTOobject.UserAddressId=useraddressObj.UserAddressId;
                UserAddressDTOobject.FkUserId=useraddressObj.FkUserId;
                UserAddressDTOobject.FkAddressId=useraddressObj.FkAddressId;
                UserAddressDTOobject.CreatedBy=useraddressObj.CreatedBy;
                UserAddressDTOobject.CreatedDate=useraddressObj.CreatedDate;

                UserAddressDTOobject.User = new UserDTO
                {
                    UserId=useraddressObj.User.UserId,
                    FirstName=useraddressObj.User.FirstName,
                    MiddleName=useraddressObj.User.MiddleName,
                    LastName=useraddressObj.User.LastName,
                    UserProfilePicture=useraddressObj.User.UserProfilePicture,
                    DOB=useraddressObj.User.DOB,
                    HireDate=useraddressObj.User.HireDate,
                    ReleaseDate=useraddressObj.User.ReleaseDate,
                    FkRoleId=useraddressObj.User.FkRoleId,
                    Active=useraddressObj.User.Active,
                    RecordStatus=useraddressObj.User.RecordStatus,
                    CreatedBy=useraddressObj.User.CreatedBy,
                    CreatedDate=useraddressObj.User.CreatedDate,
                    LastModifiedBy=useraddressObj.User.LastModifiedBy,
                    LastModifiedDate=useraddressObj.User.LastModifiedDate,
                    Role = new RoleDTO
                    {
                        RoleId=useraddressObj.User.Role.RoleId,
                        Role1=useraddressObj.User.Role.Role1,
                        Active=useraddressObj.User.Role.Active,
                        RecordStatus=useraddressObj.User.Role.RecordStatus,
                        CreatedBy=useraddressObj.User.Role.CreatedBy,
                        CreatedDate=useraddressObj.User.Role.CreatedDate,
                        LastModifiedBy=useraddressObj.User.Role.LastModifiedBy,
                        LastModifiedDate=useraddressObj.User.Role.LastModifiedDate
                    }
                };

                UserAddressDTOobject.Address = new AddressDTO
                {
                    AddressId = useraddressObj.Address.AddressId,
                    Address1 = useraddressObj.Address.Address1,
                    Address2 = useraddressObj.Address.Address2,
                    AddressType = useraddressObj.Address.AddressType,
                    City = useraddressObj.Address.City,
                    FkStateId = useraddressObj.Address.FkStateId,
                    CreatedDate = useraddressObj.Address.CreatedDate,
                    CreatedBy = useraddressObj.Address.CreatedBy,
                    LastModifiedBy = useraddressObj.Address.LastModifiedBy,
                    LastModifiedDate = useraddressObj.Address.LastModifiedDate,

                    State = new StateDTO
                    {
                        StateId = useraddressObj.Address.State.StateId,
                        State1 = useraddressObj.Address.State.State1,
                        StateCode = useraddressObj.Address.State.StateCode,
                        FkCountryId = useraddressObj.Address.State.FkCountryId,
                        Active = useraddressObj.Address.State.Active,
                        RecordStatus = useraddressObj.Address.State.RecordStatus,
                        CreatedDate = useraddressObj.Address.State.CreatedDate,
                        CreatedBy = useraddressObj.Address.State.CreatedBy,
                        LastModifiedBy = useraddressObj.Address.State.LastModifiedBy,
                        LastModifiedDate = useraddressObj.Address.State.LastModifiedDate,

                        Country = new CountryDTO
                        {
                            CountryId = useraddressObj.Address.State.Country.CountryId,
                            Country1 = useraddressObj.Address.State.Country.Country1,
                            CountryCode = useraddressObj.Address.State.Country.CountryCode,
                            Active = useraddressObj.Address.State.Country.Active,
                            RecordStatus = useraddressObj.Address.State.Country.RecordStatus,
                            CreatedBy = useraddressObj.Address.State.Country.CreatedBy,
                            CreatedDate = useraddressObj.Address.State.Country.CreatedDate,
                            LastModifiedBy = useraddressObj.Address.State.Country.LastModifiedBy,
                            LastModifiedDate = useraddressObj.Address.State.Country.LastModifiedDate
                        }
                    }
                };
            }
            catch(Exception e)
            { 
                Debug.WriteLine(e.Message); 
            }
            return UserAddressDTOobject;
        }


        /// <summary>
        /// This function returns User's Personal Data on the basis of UserId.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public UserDTO GetUserByUserId(int UserId)
        {
            UserDTO UserDTOobject = new UserDTO();
            try
            {
                User userObj = uow.UserRepo.GetById(UserId);

                UserDTOobject.UserId = userObj.UserId;
                UserDTOobject.FirstName = userObj.FirstName;
                UserDTOobject.MiddleName = userObj.MiddleName;
                UserDTOobject.LastName = userObj.LastName;
                UserDTOobject.UserProfilePicture = userObj.UserProfilePicture;
                UserDTOobject.DOB = userObj.DOB;
                UserDTOobject.HireDate = userObj.HireDate;
                UserDTOobject.ReleaseDate = userObj.ReleaseDate;
                UserDTOobject.Active = userObj.Active;
                UserDTOobject.RecordStatus = userObj.RecordStatus;
                UserDTOobject.FkRoleId = userObj.FkRoleId;
                UserDTOobject.CreatedBy = userObj.CreatedBy;
                UserDTOobject.CreatedDate = userObj.CreatedDate;
                UserDTOobject.LastModifiedBy = userObj.LastModifiedBy;
                UserDTOobject.LastModifiedDate = userObj.LastModifiedDate;

                UserDTOobject.Role = new RoleDTO
                {
                    RoleId = userObj.Role.RoleId,
                    Role1 = userObj.Role.Role1,
                    Active = userObj.Role.Active,
                    RecordStatus = userObj.Role.RecordStatus,
                    CreatedBy = userObj.Role.CreatedBy,
                    CreatedDate = userObj.Role.CreatedDate,
                    LastModifiedBy = userObj.Role.LastModifiedBy,
                    LastModifiedDate = userObj.Role.LastModifiedDate
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return UserDTOobject;
        }


        /// <summary>
        /// This function returns the User's Role on the basis of UserId.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public String GetUserRole(int UserId)
        {
            //UserDTO UserDTOobject = new UserDTO();
            string role = "";
            try
            {
                User userObj = uow.UserRepo.GetById(UserId);

                role = userObj.Role.Role1;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            //return UserDTOobject;
            return role;
        }


        /// <summary>
        /// This function adds User's Details in the Database.
        /// </summary>
        /// <param name="UserAddressDTOobject"></param>
        /// <param name="LoginDTOobject"></param>
        /// <returns></returns>
        public Boolean CreateUser(UserAddressDTO UserAddressDTOobject, LoginDTO LoginDTOobject)
        {
            bool flag = false;
            try
            {
                UserAddress useraddressObj = new UserAddress();
                User userObj = new User();
                Address addressObj = new Address();
                Login loginObj = new Login();

                userObj.FirstName = UserAddressDTOobject.User.FirstName;
                userObj.LastName = UserAddressDTOobject.User.LastName;
                userObj.MiddleName = UserAddressDTOobject.User.MiddleName;
                userObj.DOB = UserAddressDTOobject.User.DOB;
                userObj.HireDate = UserAddressDTOobject.User.HireDate;
                userObj.ReleaseDate = UserAddressDTOobject.User.ReleaseDate;
                userObj.UserProfilePicture = UserAddressDTOobject.User.UserProfilePicture;
                if (UserAddressDTOobject.User.FkRoleId == null || UserAddressDTOobject.User.FkRoleId <=0)
                { 
                    userObj.FkRoleId = 2; 
                }
                else
                { 
                    userObj.FkRoleId = UserAddressDTOobject.User.FkRoleId; 
                }
                userObj.Active = true;
                userObj.RecordStatus = 1;
                userObj.CreatedBy = 123;
                userObj.CreatedDate = DateTime.Now.Date;
                userObj.LastModifiedBy = DateTime.Now;
                userObj.LastModifiedDate = DateTime.Now.Date;

                var User=uow.UserRepo.Add(userObj);
                uow.Complete();

                addressObj.AddressType = 1;
                addressObj.Address1 = UserAddressDTOobject.Address.Address1;
                addressObj.Address2 = UserAddressDTOobject.Address.Address2;
                addressObj.City = UserAddressDTOobject.Address.City;
                addressObj.FkStateId = UserAddressDTOobject.Address.FkStateId;
                addressObj.CreatedBy = 123;
                addressObj.CreatedDate = DateTime.Now.Date;
                addressObj.LastModifiedBy = DateTime.Now;
                addressObj.LastModifiedDate = DateTime.Now.Date;

                var Address = uow.AddressRepo.Add(addressObj);
                uow.Complete();

                useraddressObj.FkUserId = User.UserId;
                useraddressObj.FkAddressId = Address.AddressId;
                useraddressObj.CreatedBy = 123;
                useraddressObj.CreatedDate = DateTime.Now.Date;

                uow.UserAddressRepo.Add(useraddressObj);
                uow.Complete();
                

                loginObj.FkUserId = User.UserId;
                loginObj.Username = LoginDTOobject.Username;
                loginObj.Password = LoginDTOobject.Password;
                loginObj.CreatedBy = 123;
                loginObj.CreatedDate = DateTime.Now.Date;
                loginObj.LastModifiedBy = DateTime.Now;
                loginObj.LastModifiedDate = DateTime.Now.Date;

                uow.LoginRepo.Add(loginObj);
                uow.Complete();
                flag = true;


            }
             catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return flag;
        }


        /// <summary>
        /// This function updates User's Data in the database on the basis of "edited" data provided by the user.
        /// </summary>
        /// <param name="UserAddressDTOobject"></param>
        /// <returns></returns>
        public Boolean UpdateUser(UserAddressDTO UserAddressDTOobject)
        {
            bool flag = false;
            try
            {
                User userObj = new User();
                Address addressObj = new Address();
                
                userObj.UserId = UserAddressDTOobject.User.UserId;
                userObj.FirstName = UserAddressDTOobject.User.FirstName;
                userObj.LastName = UserAddressDTOobject.User.LastName;
                userObj.MiddleName = UserAddressDTOobject.User.MiddleName;
                userObj.DOB = UserAddressDTOobject.User.DOB;
                userObj.HireDate = UserAddressDTOobject.User.HireDate;
                userObj.ReleaseDate = UserAddressDTOobject.User.ReleaseDate;
                userObj.FkRoleId = UserAddressDTOobject.User.FkRoleId;
                userObj.Active = UserAddressDTOobject.User.Active;
                userObj.RecordStatus = UserAddressDTOobject.User.RecordStatus;
                userObj.CreatedBy = UserAddressDTOobject.User.CreatedBy;
                userObj.CreatedDate = UserAddressDTOobject.User.CreatedDate;
                userObj.LastModifiedBy = DateTime.Now;
                userObj.LastModifiedDate = DateTime.Now.Date;

                uow.UserRepo.Update(userObj);
                //uow.Complete();

                addressObj.AddressId = UserAddressDTOobject.Address.AddressId;
                addressObj.AddressType = UserAddressDTOobject.Address.AddressType;
                addressObj.Address1 = UserAddressDTOobject.Address.Address1;
                addressObj.Address2 = UserAddressDTOobject.Address.Address2;
                addressObj.City = UserAddressDTOobject.Address.City;
                addressObj.FkStateId = UserAddressDTOobject.Address.FkStateId;
                addressObj.CreatedBy = UserAddressDTOobject.Address.CreatedBy;
                addressObj.CreatedDate = UserAddressDTOobject.Address.CreatedDate;
                addressObj.LastModifiedBy = DateTime.Now;
                addressObj.LastModifiedDate = DateTime.Now.Date;

                uow.AddressRepo.Update(addressObj);
                uow.Complete();

                flag = true;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return flag;
        }


        /// <summary>
        /// This function changes the Active Status of the User to "False".
        /// </summary>
        /// <param name="UserAddressDTOobject"></param>
        /// <returns></returns>
        public Boolean DeleteUser(UserAddressDTO UserAddressDTOobject)
        {
            bool flag = false;
            try
            {
                User userObj = new User();
                Address addressObj = new Address();

                userObj.UserId = UserAddressDTOobject.User.UserId;
                userObj.FirstName = UserAddressDTOobject.User.FirstName;
                userObj.LastName = UserAddressDTOobject.User.LastName;
                userObj.MiddleName = UserAddressDTOobject.User.MiddleName;
                userObj.DOB = UserAddressDTOobject.User.DOB;
                userObj.HireDate = UserAddressDTOobject.User.HireDate;
                userObj.ReleaseDate = UserAddressDTOobject.User.ReleaseDate;
                userObj.FkRoleId = UserAddressDTOobject.User.FkRoleId;
                userObj.Active = false;
                userObj.RecordStatus = UserAddressDTOobject.User.RecordStatus;
                userObj.CreatedBy = UserAddressDTOobject.User.CreatedBy;
                userObj.CreatedDate = UserAddressDTOobject.User.CreatedDate;
                userObj.LastModifiedBy = DateTime.Now;
                userObj.LastModifiedDate = DateTime.Now.Date;

                uow.UserRepo.Update(userObj);
                uow.Complete();
                flag = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return flag;
        }

        #endregion
    }
}
