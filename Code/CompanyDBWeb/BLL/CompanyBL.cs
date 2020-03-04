using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.UnitOfWork;
using DTOs;

namespace BLL
{
    public class CompanyBL
    {
        #region "Variable Declaration"
        public UnitOfWork uow = new UnitOfWork();
        #endregion

        #region "Public Methods"

        /// <summary>
        /// This function returns List of all countries from the Database.
        /// </summary>
        /// <returns></returns>
        public List<CountryDTO> CountryList()
        {
            List<CountryDTO> countryList = new List<CountryDTO>();
            try 
            {
                List<Country> list = uow.CountryRepo.GetAll().ToList();
                foreach(var row in list)
                {
                    countryList.Add(new CountryDTO()
                    {
                        CountryId = row.CountryId,
                        Country1 = row.Country1,
                        CountryCode = row.CountryCode,
                        CreatedBy = row.CreatedBy,
                        CreatedDate = row.CreatedDate,
                        LastModifiedBy = row.LastModifiedBy,
                        LastModifiedDate = row.LastModifiedDate,
                        RecordStatus = row.RecordStatus,
                        Active = row.Active
                    });
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return countryList;
        }

        /// <summary>
        /// This function returns List of All states.
        /// </summary>
        /// <returns></returns>
        public List<StateDTO> StateList()
        {
            List<StateDTO> stateList = new List<StateDTO>();
            try
            {
                List<State> list = uow.StateRepo.GetAll().ToList();
                foreach (var row in list)
                {
                    stateList.Add(new StateDTO()
                    {
                        StateId = row.StateId,
                        State1 = row.State1,
                        StateCode = row.StateCode,
                        CreatedBy = row.CreatedBy,
                        CreatedDate = row.CreatedDate,
                        LastModifiedBy = row.LastModifiedBy,
                        LastModifiedDate = row.LastModifiedDate,
                        RecordStatus = row.RecordStatus,
                        Active = row.Active,
                        FkCountryId=row.FkCountryId
                    });
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return stateList;
        }

        /// <summary>
        /// This function returns List of states on the basis of CountryId.
        /// </summary>
        /// <returns></returns>
        public List<StateDTO> StateListByCountryId(int CountryId)
        {
           List<StateDTO> stateList = new List<StateDTO>();
            try
            {
                List<State> list = uow.StateRepo.GetAll().Where(a=>a.FkCountryId==CountryId).ToList();
                foreach (var row in list)
                {
                    stateList.Add(new StateDTO()
                    {
                        StateId = row.StateId,
                        State1 = row.State1,
                        StateCode = row.StateCode,
                        CreatedBy = row.CreatedBy,
                        CreatedDate = row.CreatedDate,
                        LastModifiedBy = row.LastModifiedBy,
                        LastModifiedDate = row.LastModifiedDate,
                        RecordStatus = row.RecordStatus,
                        Active = row.Active,
                        FkCountryId=row.FkCountryId
                    });
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return stateList;
        }
        

        /// <summary>
        /// This function returns List of all Companies in the CompanyAddress Table.
        /// </summary>
        /// <returns></returns>
        public List<CompanyAddressDTO> GetCompanyList()
        {
            List<CompanyAddressDTO> companyList = new List<CompanyAddressDTO>();
            try 
            {
                List<CompanyAddress> list = uow.CompanyAddressRepo.GetAll().ToList();
                foreach(var row in list)
                {
                    companyList.Add(new CompanyAddressDTO() 
                    { 
                        CompanyAddressId=row.CompanyAddressId,
                        CreatedBy=row.CreatedBy,
                        CreatedDate=row.CreatedDate,
                        FkCompanyId = row.FkCompanyId,
                        Company=new CompanyDTO
                        {
                            CompanyId=row.Company.CompanyId,
                            Company1=row.Company.Company1,
                            CompanyCode=row.Company.CompanyCode,
                            Active=row.Company.Active,
                            RecordStatus=row.Company.RecordStatus,
                            CreatedDate=row.Company.CreatedDate,
                            CreatedBy=row.Company.CreatedBy,
                            LastModifiedBy=row.Company.LastModifiedBy,
                            LastModifiedDate=row.Company.LastModifiedDate
                        },
                        FkAddressId = row.FkAddressId,
                        Address = new AddressDTO
                        {
                            AddressId=row.Address.AddressId,
                            AddressType=row.Address.AddressType,
                            Address1=row.Address.Address1,
                            Address2=row.Address.Address2,
                            City=row.Address.City,
                            CreatedBy=row.Address.CreatedBy,
                            CreatedDate=row.Address.CreatedDate,
                            LastModifiedBy=row.Address.LastModifiedBy,
                            LastModifiedDate=row.Address.LastModifiedDate,
                            FkStateId=row.Address.FkStateId,
                            State = new StateDTO
                            {
                                StateId=row.Address.State.StateId,
                                State1=row.Address.State.State1,
                                StateCode=row.Address.State.StateCode,
                                Active=row.Address.State.Active,
                                RecordStatus=row.Address.State.RecordStatus,
                                CreatedBy=row.Address.State.CreatedBy,
                                CreatedDate=row.Address.State.CreatedDate,
                                LastModifiedBy=row.Address.State.LastModifiedBy,
                                LastModifiedDate=row.Address.State.LastModifiedDate,
                                FkCountryId=row.Address.State.FkCountryId,
                                Country = new CountryDTO
                                {
                                    CountryId=row.Address.State.Country.CountryId,
                                    Country1=row.Address.State.Country.Country1,
                                    CountryCode=row.Address.State.Country.CountryCode,
                                    CreatedBy=row.Address.State.Country.CreatedBy,
                                    CreatedDate=row.Address.State.Country.CreatedDate,
                                    LastModifiedBy=row.Address.State.Country.LastModifiedBy,
                                    LastModifiedDate=row.Address.State.Country.LastModifiedDate,
                                    RecordStatus=row.Address.State.Country.RecordStatus,
                                    Active=row.Address.State.Country.Active
                                }
                            }
                        }
                    });
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return companyList;
        }


        /// <summary>
        /// This function returns the details of CompanyPersonalData on the basis of CompanyId given by the user
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public CompanyAddressDTO GetCompanyPersonalDataById(int CompanyId)
        {
            CompanyAddressDTO CompanyAddressDTOobject = new CompanyAddressDTO();
            try 
            {
                CompanyAddress companyaddressObj = uow.CompanyAddressRepo.GetById(CompanyId);

                CompanyAddressDTOobject.CompanyAddressId = companyaddressObj.CompanyAddressId;
                CompanyAddressDTOobject.CreatedBy = companyaddressObj.CreatedBy;
                CompanyAddressDTOobject.CreatedDate = companyaddressObj.CreatedDate;
                CompanyAddressDTOobject.FkCompanyId = companyaddressObj.FkCompanyId;
                CompanyAddressDTOobject.FkAddressId = companyaddressObj.FkAddressId;

                CompanyAddressDTOobject.Company = new CompanyDTO
                {
                    CompanyId=companyaddressObj.Company.CompanyId,
                    Company1=companyaddressObj.Company.Company1,
                    CompanyCode=companyaddressObj.Company.CompanyCode,
                    CreatedBy = companyaddressObj.Company.CreatedBy,
                    CreatedDate = companyaddressObj.Company.CreatedDate,
                    Active = companyaddressObj.Company.Active,
                    LastModifiedBy = companyaddressObj.Company.LastModifiedBy,
                    LastModifiedDate = companyaddressObj.Company.LastModifiedDate,
                    RecordStatus = companyaddressObj.Company.RecordStatus
                };

                CompanyAddressDTOobject.Address = new AddressDTO
                {
                    AddressId = companyaddressObj.Address.AddressId,
                    AddressType = companyaddressObj.Address.AddressType,
                    Address1 = companyaddressObj.Address.Address1,
                    Address2 = companyaddressObj.Address.Address2,
                    CreatedBy = companyaddressObj.Address.CreatedBy,
                    CreatedDate = companyaddressObj.Address.CreatedDate,
                    LastModifiedBy = companyaddressObj.Address.LastModifiedBy,
                    LastModifiedDate = companyaddressObj.Address.LastModifiedDate,
                    City = companyaddressObj.Address.City,
                    FkStateId = companyaddressObj.Address.FkStateId
                };

                CompanyAddressDTOobject.Address.State = new StateDTO
                {
                    StateId = companyaddressObj.Address.State.StateId,
                    State1 = companyaddressObj.Address.State.State1,
                    StateCode = companyaddressObj.Address.State.StateCode,
                    FkCountryId = companyaddressObj.Address.State.FkCountryId,
                    Active = companyaddressObj.Address.State.Active,
                    RecordStatus = companyaddressObj.Address.State.RecordStatus,
                    CreatedBy = companyaddressObj.Address.State.CreatedBy,
                    CreatedDate = companyaddressObj.Address.State.CreatedDate,
                    LastModifiedBy = companyaddressObj.Address.State.LastModifiedBy,
                    LastModifiedDate = companyaddressObj.Address.State.LastModifiedDate
                };
                
                CompanyAddressDTOobject.Address.State.Country = new CountryDTO 
                { 
                    CountryId = companyaddressObj.Address.State.Country.CountryId,
                    Country1 = companyaddressObj.Address.State.Country.Country1,
                    CountryCode = companyaddressObj.Address.State.Country.CountryCode,
                    Active = companyaddressObj.Address.State.Country.Active,
                    RecordStatus = companyaddressObj.Address.State.Country.RecordStatus,
                    CreatedBy = companyaddressObj.Address.State.Country.CreatedBy,
                    CreatedDate = companyaddressObj.Address.State.Country.CreatedDate,
                    LastModifiedBy = companyaddressObj.Address.State.Country.LastModifiedBy,
                    LastModifiedDate = companyaddressObj.Address.State.Country.LastModifiedDate, 
                };
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return CompanyAddressDTOobject;
        }


        /// <summary>
        /// This function creates Company in the database on the basis of details provided by the user
        /// </summary>
        /// <param name="CompanyAddressDTOobject"></param>
        /// <returns></returns>
        public Boolean CreateCompany(CompanyAddressDTO CompanyAddressDTOobject)
        {
            bool flag = false;
            try 
            {
                CompanyAddress companyaddressObj = new CompanyAddress();
                Company companyObj = new Company();
                Address addressObj = new Address();

                companyObj.Company1 = CompanyAddressDTOobject.Company.Company1;
                companyObj.CompanyCode = GenerateCompanyCode(uow.StateRepo.GetById(Convert.ToInt64(CompanyAddressDTOobject.Address.FkStateId)).StateCode,CompanyAddressDTOobject.Company.Company1,CompanyAddressDTOobject.Address.City);
                companyObj.Active = true;
                companyObj.RecordStatus = 1;
                companyObj.CreatedBy = 123;
                companyObj.CreatedDate = DateTime.Now.Date;
                companyObj.LastModifiedDate = DateTime.Now.Date;
                companyObj.LastModifiedBy = DateTime.Now;
                uow.CompanyRepo.Add(companyObj);
                uow.Complete();

                addressObj.AddressType = 1;
                addressObj.Address1 = CompanyAddressDTOobject.Address.Address1;
                addressObj.Address2 = CompanyAddressDTOobject.Address.Address2;
                addressObj.City = CompanyAddressDTOobject.Address.City;
                addressObj.FkStateId = CompanyAddressDTOobject.Address.FkStateId;
                addressObj.CreatedBy = 123;
                addressObj.CreatedDate = DateTime.Now.Date;
                addressObj.LastModifiedDate = DateTime.Now.Date;
                addressObj.LastModifiedBy = DateTime.Now;

                uow.AddressRepo.Add(addressObj);
                uow.Complete();
               

                var CompanyId = uow.CompanyRepo.GetAll().Where(a => a.Company1 == CompanyAddressDTOobject.Company.Company1).FirstOrDefault().CompanyId;
                var AddressId = uow.AddressRepo.GetAll().Where(a=>a.Address1 == CompanyAddressDTOobject.Address.Address1 
                                                               && a.Address2 == CompanyAddressDTOobject.Address.Address2 
                                                               && a.City == CompanyAddressDTOobject.Address.City 
                                                               && a.FkStateId == CompanyAddressDTOobject.Address.FkStateId).FirstOrDefault().AddressId;

                companyaddressObj.FkCompanyId = CompanyId;
                companyaddressObj.FkAddressId = AddressId;
                companyaddressObj.CreatedBy = 123;
                companyaddressObj.CreatedDate = DateTime.Now.Date;

                uow.CompanyAddressRepo.Add(companyaddressObj);
                uow.Complete();
                flag = true;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return flag;
        }


        /// <summary>
        /// This function updates Company Personal Data in the database on the basis of "edited" details provided by the user
        /// </summary>
        /// <param name="CompanyAddressDTOobject"></param>
        /// <returns></returns>
        public Boolean UpdateCompanyPersonalData(CompanyAddressDTO CompanyAddressDTOobject)
        {
            bool flag = false;
            try
            {
                Company companyObj = new Company();
                Address addressObj = new Address();

                companyObj.CompanyId = CompanyAddressDTOobject.Company.CompanyId;
                companyObj.Company1 = CompanyAddressDTOobject.Company.Company1;
                companyObj.CompanyCode = CompanyAddressDTOobject.Company.CompanyCode;
                companyObj.Active = true;
                companyObj.RecordStatus = CompanyAddressDTOobject.Company.RecordStatus;
                companyObj.CreatedBy =CompanyAddressDTOobject.Company.CreatedBy;
                companyObj.CreatedDate = CompanyAddressDTOobject.Company.CreatedDate;
                companyObj.LastModifiedDate = DateTime.Now.Date;
                companyObj.LastModifiedBy = DateTime.Now;

                addressObj.AddressId = CompanyAddressDTOobject.Address.AddressId;
                addressObj.AddressType = CompanyAddressDTOobject.Address.AddressType;
                addressObj.Address1 = CompanyAddressDTOobject.Address.Address1;
                addressObj.Address2 = CompanyAddressDTOobject.Address.Address2;
                addressObj.City = CompanyAddressDTOobject.Address.City;
                addressObj.FkStateId = CompanyAddressDTOobject.Address.FkStateId;
                addressObj.CreatedBy = CompanyAddressDTOobject.Address.CreatedBy;
                addressObj.CreatedDate = CompanyAddressDTOobject.Address.CreatedDate;
                addressObj.LastModifiedDate = DateTime.Now.Date;
                addressObj.LastModifiedBy = DateTime.Now;

                uow.AddressRepo.Update(addressObj);
                uow.CompanyRepo.Update(companyObj);
                uow.Complete();
                flag = true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return flag;
        }


        /// <summary>
        /// This function changes the Active Status of the Company to "false".
        /// </summary>
        /// <param name="CompanyAddressDTOobject"></param>
        /// <returns></returns>
        public Boolean DeleteCompany(CompanyAddressDTO CompanyAddressDTOobject)
        {
            bool flag = false;
            try
            {
                Company companyObj = new Company();
                
                companyObj.CompanyId = CompanyAddressDTOobject.Company.CompanyId;
                companyObj.Company1 = CompanyAddressDTOobject.Company.Company1;
                companyObj.CompanyCode = CompanyAddressDTOobject.Company.CompanyCode;
                companyObj.Active = false;
                companyObj.RecordStatus = CompanyAddressDTOobject.Company.RecordStatus;
                companyObj.CreatedBy = CompanyAddressDTOobject.Company.CreatedBy;
                companyObj.CreatedDate = CompanyAddressDTOobject.Company.CreatedDate;
                companyObj.LastModifiedDate = DateTime.Now.Date;
                companyObj.LastModifiedBy = DateTime.Now;

                uow.CompanyRepo.Update(companyObj);
                uow.Complete();
                flag = true;
                
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return flag;
        }

        #endregion

        #region "Private Methods"
        /*
         * CompanyName = Mindfire Solutions Pvt. Ltd.
         * State Code = UP
         * City = Noida
         * 
         * CompanyCode = UP32MIND101NOI
         */

        private String GenerateCompanyCode(String StateCode,String CompanyName,String City)
        {
            String CompanyCode = "";
            int i,f=0;
            CompanyCode += StateCode + "32" ;
            
            for (i = 0; i < CompanyName.Length && f <= 3; i++)
            {
                if (CompanyName[i] != ' ')
                {
                    CompanyCode += Char.ToUpper(CompanyName[i]);
                    f++;
                }
                else
                    continue;
            }

            CompanyCode += "101";
            f = 0;
            for (i = 0; i < City.Length && f <= 2; i++)
            {
                CompanyCode += Char.ToUpper(City[i]);
                f++;
            }

            return CompanyCode;
        }

        #endregion
    }
}
