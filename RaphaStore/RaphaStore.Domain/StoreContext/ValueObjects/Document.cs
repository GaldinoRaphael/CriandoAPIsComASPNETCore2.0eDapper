using RaphaelStore.Domain.StoreContext.Enums;

namespace RaphaStore.Domain.StoreContext.ValueObjects
{
    public class Document
    {
        public string Number { get; set; }
        public EDocumentType DocumentType { get; set; }
        public Document(string number)
        {
            Number = number;
        }

        public override string ToString()
        {
            return $"{Number}";
        }
    }
}