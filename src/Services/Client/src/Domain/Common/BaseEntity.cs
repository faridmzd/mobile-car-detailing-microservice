using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set;}

        [Column("UPDATED_AT")]
        public DateTime UpdatedAt { get; set;}
    }
}
