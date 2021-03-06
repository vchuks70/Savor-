using System;
using System.Collections.Generic;
using System.Text;
using Savor.DataAccess.Data.Repository.IRepository;
using Stripe;

namespace Savor.DataAccess.Data.Repository
{
   public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
