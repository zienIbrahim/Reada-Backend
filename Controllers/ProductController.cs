using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reada_Backend.Models;
using Reada_Backend.Repo;

namespace Reada_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        
        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [Authorize]
        [HttpPost]
        [Route("Save")]
        public  IActionResult Save([FromBody] ProductDto product) {

            var model =  _productRepo.SaveProduct(product);
            return Ok("Seved Sucssufuly");
        }
    }
}
