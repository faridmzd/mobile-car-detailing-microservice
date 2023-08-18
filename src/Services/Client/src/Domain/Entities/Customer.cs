using Client.Domain.Common;


namespace Client.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string PassportNo { get; set; } = null!;

        public string Name { get; set; } = null!;

       
    }
}
