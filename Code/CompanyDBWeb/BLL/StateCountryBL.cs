using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using DAL;
using DAL.UnitOfWork;

namespace BLL
{
    public class StateCountryBL
    {

        /// <summary>
        /// This function returns List of All states.
        /// </summary>
        /// <returns></returns>
        public List<StateDTO> StateList()
        {
            List<StateDTO> stateList = new List<StateDTO>();
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
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
                            FkCountryId = row.FkCountryId
                        });
                    }
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
                using (UnitOfWork uow = new UnitOfWork())
                {
                    List<State> list = uow.StateRepo.GetAll().Where(a => a.FkCountryId == CountryId).ToList();
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
                            FkCountryId = row.FkCountryId
                        });
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return stateList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="StateDTOobject"></param>
        /// <returns></returns>
        public Boolean CreateState(StateDTO StateDTOobject)
        {
            bool flag = false;
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    State state = new State();
                    state.State1 = StateDTOobject.State1;
                    state.StateCode = StateDTOobject.StateCode;
                    state.FkCountryId = StateDTOobject.FkCountryId;
                    state.Active = true;
                    state.RecordStatus = 1;
                    state.CreatedBy = 123;
                    state.CreatedDate = DateTime.Now.Date;
                    state.LastModifiedBy = DateTime.Now;
                    state.LastModifiedDate = DateTime.Now.Date;
                    uow.StateRepo.Add(state);
                    uow.Complete();
                    flag = true;
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return flag;
        }


        /// <summary>
        /// This function returns List of all countries from the Database.
        /// </summary>
        /// <returns></returns>
        public List<CountryDTO> CountryList()
        {
            List<CountryDTO> countryList = new List<CountryDTO>();
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    List<Country> list = uow.CountryRepo.GetAll().ToList();
                    foreach (var row in list)
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
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return countryList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CountryDTOobject"></param>
        /// <returns></returns>
        public Boolean CreateCountry(CountryDTO CountryDTOobject)
        {
            bool flag = false;
            try 
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Country country = new Country();
                    country.Country1 = CountryDTOobject.Country1;
                    country.CountryCode = CountryDTOobject.CountryCode;
                    country.Active = true;
                    country.RecordStatus = 1;
                    country.CreatedBy = 123;
                    country.CreatedDate = DateTime.Now.Date;
                    country.LastModifiedBy = DateTime.Now;
                    country.LastModifiedDate = DateTime.Now.Date;
                    uow.CountryRepo.Add(country);
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

        
    }
}
