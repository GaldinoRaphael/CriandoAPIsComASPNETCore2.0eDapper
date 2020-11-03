namespace RaphaStore.Domain.StoreContext.ValueObjects
{
    public class Email
    {
        public string Adress { get; private set; }

        public Email(string adress)
        {
            Adress = adress;
        }

        public override string ToString()
        {
            return $"{Adress}";
        }
    }
}