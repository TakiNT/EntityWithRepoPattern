using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace FFRepository
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        internal DbSet<T> dbSet;

        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
        internal DbContext Database { get { return _unitOfWork.Db; } }

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Null UOW");
            }

            _unitOfWork = unitOfWork;
            this.dbSet = _unitOfWork.Db.Set<T>();
        }

        public T Single(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }

        public T SingleOrDefault(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }

        public bool Exists(object primaryKey)
        {
            return dbSet.Find(primaryKey) == null ? false : true;
        }

        public virtual int Insert(T entity)
        {
            dynamic obj = dbSet.Add(entity);
            this._unitOfWork.Db.SaveChanges();
            return obj.pid;
        }

        public virtual int Delete(T entity)
        {
            if (_unitOfWork.Db.Entry(entity).State == EntityState.Deleted)
            {
                dbSet.Attach(entity);
            }

            dynamic obj = dbSet.Remove(entity);
            this._unitOfWork.Db.SaveChanges();
            return obj.pid;
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            this._unitOfWork.Db.SaveChanges();
        }

        public Dictionary<string, string> GetAuditNames(dynamic dynamicObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable().ToList();
        }
    }
}
