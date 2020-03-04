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
    public class CompanyDBMapBL
    {
        #region "Public Methods"

        /// <summary>
        /// This function returns List of all Company Databases in CompanyDB Table from the Database.
        /// </summary>
        /// <returns></returns>
        public List<CompanyDBDTO> GetAll()
        {
            List<CompanyDBDTO> companyList = new List<CompanyDBDTO>();
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    List<CompanyDB> list = uow.CompanyDBRepo.GetAll().ToList();

                    foreach (var row in list)
                    {
                        companyList.Add(new CompanyDBDTO()
                            {
                                CompanyDBId = row.CompanyDBId,
                                Active = row.Active,
                                RecordStatus = row.RecordStatus,
                                CreatedBy = row.CreatedBy,
                                CreatedDate = row.CreatedDate,
                                LastModifiedBy = row.LastModifiedBy,
                                LastModifiedDate = row.LastModifiedDate,
                                FkCompanyId = row.FkCompanyId,
                                Company = new CompanyDTO
                                {
                                    CompanyId = row.Company.CompanyId,
                                    Company1 = row.Company.Company1,
                                    CompanyCode = row.Company.CompanyCode,
                                    Active = row.Company.Active,
                                    RecordStatus = row.Company.RecordStatus,
                                    CreatedBy = row.Company.CreatedBy,
                                    CreatedDate = row.Company.CreatedDate,
                                    LastModifiedBy = row.Company.LastModifiedBy,
                                    LastModifiedDate = row.Company.LastModifiedDate
                                },

                                FkDatabaseInfoId = row.FkDatabaseInfoId,
                                DatabaseInfo = new DatabaseInfoDTO
                                {
                                    DatabaseInfoId = row.DatabaseInfo.DatabaseInfoId,
                                    ServerName = row.DatabaseInfo.ServerName,
                                    Authentication = row.DatabaseInfo.Authentication,
                                    UserName = row.DatabaseInfo.UserName,
                                    Password = row.DatabaseInfo.Password,
                                    Active = row.DatabaseInfo.Active,
                                    RecordStatus = row.DatabaseInfo.RecordStatus,
                                    CreatedBy = row.DatabaseInfo.CreatedBy,
                                    CreatedDate = row.DatabaseInfo.CreatedDate,
                                    LastModifiedBy = row.DatabaseInfo.LastModifiedBy,
                                    LastModifiedDate = row.DatabaseInfo.LastModifiedDate
                                }
                            });
                    }
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return companyList;
        }


        /// <summary>
        /// This fuction returns List of all CompanyDatabases on the basis of CountryId provided by the user
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<CompanyDBDTO> GetAllByCompanyId(int CompanyId)
        {
            List<CompanyDBDTO> companyList = new List<CompanyDBDTO>();
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    List<CompanyDB> list = uow.CompanyDBRepo.GetAll().Where(a => a.Company.CompanyId == CompanyId).ToList();

                    foreach (var row in list)
                    {
                        companyList.Add(new CompanyDBDTO()
                        {
                            CompanyDBId = row.CompanyDBId,
                            Active = row.Active,
                            RecordStatus = row.RecordStatus,
                            CreatedBy = row.CreatedBy,
                            CreatedDate = row.CreatedDate,
                            LastModifiedBy = row.LastModifiedBy,
                            LastModifiedDate = row.LastModifiedDate,
                            FkCompanyId = row.FkCompanyId,
                            Company = new CompanyDTO
                            {
                                CompanyId = row.Company.CompanyId,
                                Company1 = row.Company.Company1,
                                CompanyCode = row.Company.CompanyCode,
                                Active = row.Company.Active,
                                RecordStatus = row.Company.RecordStatus,
                                CreatedBy = row.Company.CreatedBy,
                                CreatedDate = row.Company.CreatedDate,
                                LastModifiedBy = row.Company.LastModifiedBy,
                                LastModifiedDate = row.Company.LastModifiedDate
                            },

                            FkDatabaseInfoId = row.FkDatabaseInfoId,
                            DatabaseInfo = new DatabaseInfoDTO
                            {
                                DatabaseInfoId = row.DatabaseInfo.DatabaseInfoId,
                                ServerName = row.DatabaseInfo.ServerName,
                                Authentication = row.DatabaseInfo.Authentication,
                                UserName = row.DatabaseInfo.UserName,
                                Password = row.DatabaseInfo.Password,
                                Active = row.DatabaseInfo.Active,
                                RecordStatus = row.DatabaseInfo.RecordStatus,
                                CreatedBy = row.DatabaseInfo.CreatedBy,
                                CreatedDate = row.DatabaseInfo.CreatedDate,
                                LastModifiedBy = row.DatabaseInfo.LastModifiedBy,
                                LastModifiedDate = row.DatabaseInfo.LastModifiedDate
                            }
                        });
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return companyList;
        }


        /// <summary>
        /// This function returns the details of CompanyDBData on the basis of CompanyDBId given by the user
        /// </summary>
        /// <param name="CompanyDBId"></param>
        /// <returns></returns>
        public CompanyDBDTO GetById(int CompanyDBId)
        {
            CompanyDBDTO CompanyDBDTOobject = new CompanyDBDTO();
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    CompanyDB companydbObj = uow.CompanyDBRepo.GetById(CompanyDBId);

                    CompanyDBDTOobject.CompanyDBId = companydbObj.CompanyDBId;
                    CompanyDBDTOobject.Active = companydbObj.Active;
                    CompanyDBDTOobject.RecordStatus = companydbObj.RecordStatus;
                    CompanyDBDTOobject.CreatedBy = companydbObj.CreatedBy;
                    CompanyDBDTOobject.CreatedDate = companydbObj.CreatedDate;
                    CompanyDBDTOobject.LastModifiedBy = companydbObj.LastModifiedBy;
                    CompanyDBDTOobject.LastModifiedDate = companydbObj.LastModifiedDate;
                    CompanyDBDTOobject.FkCompanyId = companydbObj.FkCompanyId;
                    CompanyDBDTOobject.FkDatabaseInfoId = companydbObj.FkDatabaseInfoId;

                    CompanyDBDTOobject.Company = new CompanyDTO
                    {
                        CompanyId = companydbObj.Company.CompanyId,
                        Company1 = companydbObj.Company.Company1,
                        CompanyCode = companydbObj.Company.CompanyCode,
                        Active = companydbObj.Company.Active,
                        RecordStatus = companydbObj.Company.RecordStatus,
                        CreatedBy = companydbObj.Company.CreatedBy,
                        CreatedDate = companydbObj.Company.CreatedDate,
                        LastModifiedBy = companydbObj.Company.LastModifiedBy,
                        LastModifiedDate = companydbObj.Company.LastModifiedDate
                    };
                    CompanyDBDTOobject.DatabaseInfo = new DatabaseInfoDTO
                    {
                        DatabaseInfoId = companydbObj.DatabaseInfo.DatabaseInfoId,
                        ServerName = companydbObj.DatabaseInfo.ServerName,
                        Authentication = companydbObj.DatabaseInfo.Authentication,
                        UserName = companydbObj.DatabaseInfo.UserName,
                        Password = companydbObj.DatabaseInfo.Password,
                        Active = companydbObj.DatabaseInfo.Active,
                        RecordStatus = companydbObj.DatabaseInfo.RecordStatus,
                        CreatedBy = companydbObj.DatabaseInfo.CreatedBy,
                        CreatedDate = companydbObj.DatabaseInfo.CreatedDate,
                        LastModifiedBy = companydbObj.DatabaseInfo.LastModifiedBy,
                        LastModifiedDate = companydbObj.DatabaseInfo.LastModifiedDate
                    };
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return CompanyDBDTOobject;
        }


        /// <summary>
        /// This function adds Company's Database Details in the database on the basis of data provided by the user
        /// </summary>
        /// <param name="CompanyDBDTOobject"></param>
        /// <returns></returns>
        public Boolean AddCompanyDBInfo(CompanyDBDTO CompanyDBDTOobject)
        {
            bool flag = false;
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    CompanyDB companydbObj = new CompanyDB();
                    DatabaseInfo databaseinfoObj = new DatabaseInfo();

                    databaseinfoObj.ServerName = CompanyDBDTOobject.DatabaseInfo.ServerName;
                    databaseinfoObj.Authentication = CompanyDBDTOobject.DatabaseInfo.Authentication;
                    databaseinfoObj.UserName = CompanyDBDTOobject.DatabaseInfo.UserName;
                    databaseinfoObj.Password = CompanyDBDTOobject.DatabaseInfo.Password;
                    databaseinfoObj.Active = true;
                    databaseinfoObj.RecordStatus = 1;
                    databaseinfoObj.CreatedBy = 123;
                    databaseinfoObj.CreatedDate = DateTime.Now.Date;
                    databaseinfoObj.LastModifiedBy = DateTime.Now;
                    databaseinfoObj.LastModifiedDate = DateTime.Now.Date;
                    uow.DatabaseInfoRepo.Add(databaseinfoObj);
                    uow.Complete();

                    companydbObj.FkDatabaseInfoId = uow.DatabaseInfoRepo.GetAll().Where(a => a.ServerName == CompanyDBDTOobject.DatabaseInfo.ServerName
                                                                                      && a.Authentication == CompanyDBDTOobject.DatabaseInfo.Authentication
                                                                                      && a.UserName == CompanyDBDTOobject.DatabaseInfo.UserName
                                                                                      && a.Password == CompanyDBDTOobject.DatabaseInfo.Password).SingleOrDefault().DatabaseInfoId;
                    companydbObj.FkCompanyId = CompanyDBDTOobject.FkCompanyId;
                    companydbObj.Active = true;
                    companydbObj.RecordStatus = 1;
                    companydbObj.CreatedBy = 123;
                    companydbObj.CreatedDate = DateTime.Now.Date;
                    companydbObj.LastModifiedDate = DateTime.Now.Date;
                    companydbObj.LastModifiedBy = DateTime.Now;
                    uow.CompanyDBRepo.Add(companydbObj);
                    uow.Complete();

                    flag = true;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return flag;
        }


        /// <summary>
        /// This function updates Company's Database Details in the database on the basis of "edited" details provided by the user
        /// </summary>
        /// <param name="CompanyDBDTOobject"></param>
        /// <returns></returns>
        public Boolean UpdateCompanyDBInfo(CompanyDBDTO CompanyDBDTOobject)
        {
            bool flag = false;
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    CompanyDB companydbObj = new CompanyDB();
                    DatabaseInfo databaseinfoObj = new DatabaseInfo();

                    databaseinfoObj.DatabaseInfoId = CompanyDBDTOobject.DatabaseInfo.DatabaseInfoId;
                    databaseinfoObj.ServerName = CompanyDBDTOobject.DatabaseInfo.ServerName;
                    databaseinfoObj.Authentication = CompanyDBDTOobject.DatabaseInfo.Authentication;
                    databaseinfoObj.UserName = CompanyDBDTOobject.DatabaseInfo.UserName;
                    databaseinfoObj.Password = CompanyDBDTOobject.DatabaseInfo.Password;
                    databaseinfoObj.Active = CompanyDBDTOobject.DatabaseInfo.Active;
                    databaseinfoObj.RecordStatus = CompanyDBDTOobject.DatabaseInfo.RecordStatus;
                    databaseinfoObj.CreatedBy = CompanyDBDTOobject.DatabaseInfo.CreatedBy;
                    databaseinfoObj.CreatedDate = CompanyDBDTOobject.DatabaseInfo.CreatedDate;
                    databaseinfoObj.LastModifiedBy = DateTime.Now;
                    databaseinfoObj.LastModifiedDate = DateTime.Now.Date;
                    uow.DatabaseInfoRepo.Update(databaseinfoObj);
                    uow.Complete();

                    flag = true;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return flag;
        }


        /// <summary>
        /// This function changes the "ActiveStatus" of the CompanyDB Detail object to "False"
        /// </summary>
        /// <param name="CompanyDBId"></param>
        /// <returns></returns>
        public Boolean DeleteCompanyDB(CompanyDBDTO CompanyDBDTOobject)
        {
            bool flag = false;
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    CompanyDB companydbObj = new CompanyDB();

                    companydbObj.CompanyDBId = CompanyDBDTOobject.CompanyDBId;
                    companydbObj.FkCompanyId = CompanyDBDTOobject.FkCompanyId;
                    companydbObj.FkDatabaseInfoId = CompanyDBDTOobject.FkDatabaseInfoId;
                    companydbObj.Active = false;
                    companydbObj.RecordStatus = CompanyDBDTOobject.RecordStatus;
                    companydbObj.CreatedBy = CompanyDBDTOobject.CreatedBy;
                    companydbObj.CreatedDate = CompanyDBDTOobject.CreatedDate;
                    companydbObj.LastModifiedBy = DateTime.Now;
                    companydbObj.LastModifiedDate = DateTime.Now.Date;
                    uow.CompanyDBRepo.Update(companydbObj);
                    uow.Complete();
                    flag = true;
                }
            }

            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return flag;

        }
        #endregion
    }
}
