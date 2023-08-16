using Client.Domain.Common;


namespace Client.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string PassportNo { get; set; }

        public string Name { get; set; } = null!;

        public Customer()
        {
        }
    }
}
