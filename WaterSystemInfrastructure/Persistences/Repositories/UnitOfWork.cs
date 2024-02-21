using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterSystem.Infrastructure.Persistences.Contexts;
using WaterSystem.Infrastructure.Persistences.Interfaces;

namespace WaterSystem.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SistemasCobroAgua2024Context _context;
        public ISettlementRepository Settlement { get; private set; }

        public IUserRepository User { get; private set; }

        //public IUserRepository User { get; private set; }
        public UnitOfWork(SistemasCobroAgua2024Context context)
        {
            this._context = context;
            Settlement= new SettlementRepository(_context);
            User = new UserRepository(_context);
        }
        //liberar los recurso en memeoria
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            _context.SaveChanges(); 
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
