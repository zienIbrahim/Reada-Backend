using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reada_Backend.Models
{
    public class Unit
    {
        public Unit()
        {
           Id= Guid.NewGuid();     
        }
        [Key]
        public  Guid Id { get; set; }
        public string Price { get; set; }
        public string Quntity { get; set; }
        public string barcode { get; set; }
        public string UnitName { get; set; }
        public virtual Product product { get; set; }
        [ForeignKey("Product")]
        public string productId { get; set; }
    }
}
