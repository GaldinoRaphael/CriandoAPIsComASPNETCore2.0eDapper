using FluentValidator;
using FluentValidator.Validation;

namespace RaphaStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "O email é invalido")
            );
        }

        public override string ToString()
        {
            return $"{Address}";
        }
    }
}