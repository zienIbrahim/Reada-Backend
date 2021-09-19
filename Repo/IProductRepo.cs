using Reada_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reada_Backend.Repo
{
   public interface IProductRepo
    {
        Product SaveProduct(ProductDto user);
    }
}
