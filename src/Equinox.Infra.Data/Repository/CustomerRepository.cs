using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Equinox.Domain.Interfaces; // Importing the interface namespace
using Equinox.Domain.Models; // Importing the models namespace
using Equinox.Infra.Data.Context; // Importing the data context namespace
using Microsoft.EntityFrameworkCore; // Importing the Entity Framework Core namespace
using NetDevPack.Data; // Importing the NetDevPack data namespace

namespace Equinox.Infra.Data.Repository // Defining the repository namespace
{
    public class CustomerRepository : ICustomerRepository // Implementing the ICustomerRepository interface
    {
        // Declaring the EquinoxContext object and DbSet for Customer
        protected readonly EquinoxContext Db;
        protected readonly DbSet<Customer> DbSet;

        // Constructor with dependency injection of EquinoxContext
        public CustomerRepository(EquinoxContext context)
        {
            Db = context;
            DbSet = Db.Set<Customer>();
        }

        // Implementing the IUnitOfWork interface from the Domain layer
        public IUnitOfWork UnitOfWork => Db;

        // Implementing the GetById method from the ICustomerRepository interface
        public async Task<Customer> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        // Implementing the GetAll method from the ICustomerRepository interface
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        // Implementing the GetByEmail method from the ICustomerRepository interface
        public async Task<Customer> GetByEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        }

        // Implementing the Add method from the ICustomerRepository interface
        public void Add(Customer customer)
        {
            DbSet.Add(customer);
        }

        // Implementing the Update method from the ICustomerRepository interface
        public void Update(Customer customer)
        {
            DbSet.Update(customer);
        }

        // Implementing the Remove method from the ICustomerRepository interface
        public void Remove(Customer customer)
        {
            DbSet.Remove(customer);
        }

        //
