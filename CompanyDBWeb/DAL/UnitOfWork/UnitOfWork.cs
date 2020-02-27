using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private CompanyDBEntities context = new CompanyDBEntities();
        private GenericRepository<Address> addressRepo;
        private GenericRepository<Company> companyRepo;
        private GenericRepository<CompanyAddress> companyAddressRepo;
        private GenericRepository<CompanyDB> companyDBRepo;
        private GenericRepository<Country> countryRepo;
        private GenericRepository<DatabaseInfo> databaseInfoRepo;
        private GenericRepository<Login> loginRepo;
        private GenericRepository<Role> roleRepo;
        private GenericRepository<State> stateRepo;
        private GenericRepository<User> userRepo;
        private GenericRepository<UserAddress> userAddressRepo;
        private GenericRepository<UserHistory> userHistoryRepo;


        public GenericRepository<Address> AddressRepo
        {
            get
            {
                if (addressRepo == null)
                {
                    addressRepo = new GenericRepository<Address>(context);
                }
                return addressRepo;
            }
        }

        public GenericRepository<Company> CompanyRepo
        {
            get
            {
                if (companyRepo == null)
                {
                    companyRepo = new GenericRepository<Company>(context);
                }
                return companyRepo;
            }
        }

        public GenericRepository<CompanyAddress> CompanyAddressRepo
        {
            get
            {
                if(companyAddressRepo==null)
                {
                    companyAddressRepo = new GenericRepository<CompanyAddress>(context);
                }
                return companyAddressRepo;
            }
        }

        public GenericRepository<CompanyDB> CompanyDBRepo
        {
            get
            {
                if (companyDBRepo == null)
                {
                    companyDBRepo = new GenericRepository<CompanyDB>(context);
                }
                return companyDBRepo;
            }
        }

        public GenericRepository<Country> CountryRepo
        {
            get
            {
                if (countryRepo == null)
                {
                    countryRepo = new GenericRepository<Country>(context);
                }
                return countryRepo;
            }
        }

        public GenericRepository<DatabaseInfo> DatabaseInfoRepo
        {
            get
            {
                if (databaseInfoRepo == null)
                {
                    databaseInfoRepo = new GenericRepository<DatabaseInfo>(context);
                }
                return databaseInfoRepo;
            }
        }

        public GenericRepository<Login> LoginRepo
        {
            get
            {
                if (loginRepo == null)
                {
                    loginRepo = new GenericRepository<Login>(context);
                }
                return loginRepo;
            }
        }

        public GenericRepository<Role> RoleRepo
        {
            get
            {
                if (roleRepo == null)
                {
                    roleRepo = new GenericRepository<Role>(context);
                }
                return roleRepo;
            }
        }

        public GenericRepository<State> StateRepo
        {
            get
            {
                if (stateRepo == null)
                {
                    stateRepo = new GenericRepository<State>(context);
                }
                return stateRepo;
            }
        }

        public GenericRepository<User> UserRepo
        {
            get
            {
                if (userRepo == null)
                {
                    userRepo = new GenericRepository<User>(context);
                }
                return userRepo;
            }
        }

        public GenericRepository<UserAddress> UserAddressRepo
        {
            get
            {
                if (userAddressRepo == null)
                {
                    userAddressRepo = new GenericRepository<UserAddress>(context);
                }
                return userAddressRepo;
            }
        }

        public GenericRepository<UserHistory> UserHistoryRepo
        {
            get
            {
                if (userHistoryRepo == null)
                {
                    userHistoryRepo = new GenericRepository<UserHistory>(context);
                }
                return userHistoryRepo;
            }
        }

        public void Complete()
        {
            context.SaveChangesAsync();
        }
        public void CompleteSync()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
