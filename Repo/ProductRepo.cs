using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reada_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reada_Backend.Repo
{
    public class ProductRepo: IProductRepo
    {
        private readonly DbEFContext _db;
        private readonly IMapper _mapper;
        public ProductRepo(DbEFContext db ,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public Product SaveProduct(ProductDto model)
        {
            var productModel =   _mapper.Map<ProductDto,Product>(model);
             productModel.Unit =   _mapper.Map<List<UnitDto>,List<Unit>>(model.Unit);
          _db.products.Add(productModel);
           _db.SaveChanges();
            return productModel;
        }
     
    }
}
