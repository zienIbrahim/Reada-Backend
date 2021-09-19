using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reada_Backend.Models
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public string Categery { get; set; }
        public string IsSold { get; set; }
        public string ProductionType { get; set; }
        public List<UnitDto> Unit { get; set; }
    }
    public class UnitDto
    {
        public string Price { get; set; }
        public string Quntity { get; set; }
        public string barcode { get; set; }
        public string UnitName { get; set; } 
        public string productId { get; set; }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UnitDto, Unit>();
            CreateMap<ProductDto, Product> ();
        }

    }

}
