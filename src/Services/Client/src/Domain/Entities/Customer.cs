using Client.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Domain.Entities
{
    public class Customer : BaseEntity
    {
        [Column("PASSPORT_NO")]
        public string PassportNo { get; set; } = null!;

        [Column("NAME")]
        public string Name { get; set; } = null!;

       
    }
}
