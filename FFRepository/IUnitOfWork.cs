using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace FFRepository
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Return the database reference for this UOW
        /// </summary>
        DbContext Db { get; }

        /// <summary>
        /// Call this to commit the UOW
        /// </summary>
        void Commit();

        /// <summary>
        /// Starts a transaction on this UOW 
        /// </summary>
        void StartTransaction();
    }
}