using RaphaStore.Domain.StoreContext.Entities;
using RaphaStore.Domain.StoreContext.Repositories;
using RaphaStore.Infra.DataContexts;

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
            throw new System.NotImplementedException();
        }

        public bool CheckEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public void save(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}