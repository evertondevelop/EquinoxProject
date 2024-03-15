using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace Equinox.Infra.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EquinoxContext _dbContext;
        private readonly DbSet<Customer> _dbSet;

        public CustomerRepository(EquinoxContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Customer>();
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public async Task<Customer> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Customer> GetByEmail(string email)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        }

        public void Add(Customer customer)
        {
            _dbSet.Add(customer);
        }

        public void Update(Customer customer)
        {
            _dbSet.Update(customer);
        }

        public void Remove(Customer customer)
        {
            _dbSet.Remove(customer);
        }

        public IQueryable<Customer> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<Customer> GetQueryable(Expression<Func<Customer, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
