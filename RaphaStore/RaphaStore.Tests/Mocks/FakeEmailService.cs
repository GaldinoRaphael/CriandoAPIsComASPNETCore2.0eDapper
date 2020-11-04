using RaphaStore.Domain.StoreContext.Entities;
using RaphaStore.Domain.StoreContext.Repositories;
using RaphaStore.Domain.StoreContext.Services;

namespace RaphaStore.Tests
{
    public class FakeEmailService : IEmailService
    {
        public FakeEmailService()
        {
        }

        public void Send(string to, string from, string body)
        {
        }
    }
}