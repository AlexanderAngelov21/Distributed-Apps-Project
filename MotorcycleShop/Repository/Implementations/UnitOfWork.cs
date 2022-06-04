using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private MotorcycleShopDb context = new MotorcycleShopDb();
        private GenericRepository<Brand> brandRepository;
        private GenericRepository<Motorcycle> motorcycleRepository;
        private GenericRepository<Sale> saleRepository;

        public GenericRepository<Brand> BrandRepository
        {
            get
            {

                if (this.brandRepository == null)
                {
                    this.brandRepository = new GenericRepository<Brand>(context);
                }
                return brandRepository;
            }
        }

        public GenericRepository<Motorcycle> MotorcycleRepository
        {
            get
            {

                if (this.motorcycleRepository == null)
                {
                    this.motorcycleRepository = new GenericRepository<Motorcycle>(context);
                }
                return motorcycleRepository;
            }
        }

        public GenericRepository<Sale> SaleRepository
        {
            get
            {

                if (this.saleRepository == null)
                {
                    this.saleRepository = new GenericRepository<Sale>(context);
                }
                return saleRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}