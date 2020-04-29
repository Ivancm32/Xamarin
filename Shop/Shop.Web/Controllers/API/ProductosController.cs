using Microsoft.AspNetCore.Mvc;
using Shop.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers.API
{
    [Route("api/[Controller]")]
    public class ProductosController : Controller
    {
        private readonly IRepositorioProductos  repositorioProductos;

        public ProductosController(IRepositorioProductos repositorioProductos)
        {
            this.repositorioProductos = repositorioProductos;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            return this.Ok(this.repositorioProductos.GetAll());
        }
    }

}