using Client.Domain.Common;


namespace Client.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = null!;

        public Customer()
        {
        }
    }
}
