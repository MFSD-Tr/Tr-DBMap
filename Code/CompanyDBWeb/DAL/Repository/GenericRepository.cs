using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal CompanyDBEntities context;
        internal DbSet<T> dbSet;
        public GenericRepository(CompanyDBEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public IEnumerable<T> GetAllByProperty(String property)
        {
            return dbSet.Include(property).ToList();
        }
        public T GetById(long ModelId)
        {
            T newmodel = dbSet.Find(ModelId);
            return newmodel;
        }

        public T GetByProperty(String property)
        {
            T newmodel = dbSet.Include(property).First();
            return newmodel;
        }

        public T Add(T model)
        {
            T newModel = dbSet.Add(model);
            context.SaveChanges();
            return newModel;
        }

        public T Delete(long ModelId)
        {
            T modelToDelete = GetById(ModelId);
            dbSet.Remove(modelToDelete);


            return modelToDelete;
        }

        public T Update(T model)
        {
            dbSet.Attach(model);
            context.Entry(model).State = EntityState.Modified;
            return model;
        }

        public void Dispose()
        {
            if (context != null)
                context.Dispose();
        }
    }
}
