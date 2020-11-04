using RaphaStore.Domain.StoreContext.Entities;

namespace RaphaStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void save(Customer customer);
    }
}