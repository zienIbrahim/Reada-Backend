using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reada_Backend.Models
{
    [Table("Product")]
    public class Product
    {

        public Product()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        public string ProductName { get; set; }
        public string Categery { get; set; }
        public string IsSold { get; set; }
        public string ProductionType { get; set; }
        public virtual ICollection<Unit> Unit { get; set; }
    }
}
