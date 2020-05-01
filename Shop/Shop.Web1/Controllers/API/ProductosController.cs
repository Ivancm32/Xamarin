namespace Shop.Web1.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using Data;

    [Route("api/[Controller]")]
    public class ProductosController : Controller
    {
        private readonly IRepositorioProductos repositorioProductos;

        public ProductosController(IRepositorioProductos repositorioProductos)
        {
            this.repositorioProductos = repositorioProductos;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            return this.Ok(this.repositorioProductos.GetAllWithUsers());
        }
    }

}