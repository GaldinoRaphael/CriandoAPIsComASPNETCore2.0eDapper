using RaphaStore.Domain.StoreContext.Entities;
using RaphaStore.Domain.StoreContext.Repositories;

namespace RaphaStore.Tests
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public FakeCustomerRepository() { }
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void save(Customer customer)
        {
        }
    }
}