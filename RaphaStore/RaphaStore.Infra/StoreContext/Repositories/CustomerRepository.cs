using Dapper;
using RaphaStore.Domain.StoreContext.Entities;
using RaphaStore.Domain.StoreContext.Repositories;
using RaphaStore.Infra.DataContexts;
using System.Data;
using System.Linq;

namespace RaphaStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RaphaDataContext _context;

        public CustomerRepository(RaphaDataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document)
        {
            return _context
            .Connection
            .Query<bool>(
                "spCheckDocument",
                new { Document = document },
                commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context
            .Connection
            .Query<bool>(
                "spCheckEmail",
                new { Email = email },
                commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public void save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
            new
            {
                Id = customer.Id,
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                Document = customer.Document.Number,
                Email = customer.Email.Address,
                Phone = customer.Phone
            }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                new
                {
                    Id = address.Id,
                    CustomerId = customer.Id,
                    number = address.Number,
                    Complement = address.Complement,
                    District = address.District,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipeCode = address.ZipCode,
                    Type = address.Type,
                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}