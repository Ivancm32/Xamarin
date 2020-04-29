namespace Shop.Web.Controllers
{
    using Data;
    using Data.Entities;
    using Helper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    public class ProductosController : Controller
    {
        private readonly IRepositorioProductos repositorioProductos;

        //private readonly DataContext _context;


        private readonly IUserHelper userHelper;

        public ProductosController(IRepositorioProductos RepositorioProductos, IUserHelper userHelper)
        {
            repositorioProductos = RepositorioProductos;
            this.userHelper = userHelper;
        }

        public IActionResult Index()
        {
            return View(this.repositorioProductos.GetAll());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.repositorioProductos.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Productos productos)
        {
            if (ModelState.IsValid)
            {
                //TODO: Cambiar cuando se cree el login dato quemado
                productos.Usuarios = await this.userHelper.GetUserByEmailAsync("Icastro@tas-seguridad.com");
                await this.repositorioProductos.CreateAsync(productos);
                return RedirectToAction(nameof(Index));
            }
            return View(productos);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.repositorioProductos.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Productos productos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    productos.Usuarios = await this.userHelper.GetUserByEmailAsync("Icastro@tas-seguridad.com");
                    await this.repositorioProductos.UpdateAsync(productos);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.repositorioProductos.ExistAsync(productos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productos);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.repositorioProductos.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await this.repositorioProductos.GetByIdAsync(id);
            await this.repositorioProductos.DeleteAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}