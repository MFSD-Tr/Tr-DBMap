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
        UnitOfWork uow = new UnitOfWork();
        public Boolean CreateState(StateDTO StateDTOobject)
        {
            bool flag = false;
            try
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
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return flag;
        }

        public Boolean CreateCountry(CountryDTO CountryDTOobject)
        {
            bool flag = false;
            try 
            { 
                Country country = new Country();
                country.Country1 = CountryDTOobject.Country1;
                country.CountryCode = CountryDTOobject.CountryCode;
                country.Active =true;
                country.RecordStatus = 1;
                country.CreatedBy = 123;
                country.CreatedDate = DateTime.Now.Date;
                country.LastModifiedBy = DateTime.Now;
                country.LastModifiedDate = DateTime.Now.Date;
                uow.CountryRepo.Add(country);
                uow.Complete();
                flag = true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return flag;
        }

        
    }
}
