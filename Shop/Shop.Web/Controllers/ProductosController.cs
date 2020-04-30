namespace Shop.Web.Controllers
{
    using Data;
    using Data.Entities;
    using Helper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Models;
    using System.IO;
    using System.Linq;
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
            return View(this.repositorioProductos.GetAll().OrderBy(p => p.Nombre));
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
        public async Task<IActionResult> Create(ProductosViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot\\images\\Productos", view.ImageFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Productos/{view.ImageFile.FileName}";
                }
                var product = this.toProduct(view, path);
                //TODO: Cambiar cuando se cree el login dato quemado
                product.Usuarios = await this.userHelper.GetUserByEmailAsync("Icastro@tas-seguridad.com");
                await this.repositorioProductos.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Productos toProduct(ProductosViewModel view, string path)
        {
            return new Productos
            {
                Id = view.Id,
                ImageUrl = path,
                Disponi = view.Disponi,
                UltComp = view.UltComp,
                UltVent = view.UltVent,
                Nombre = view.Nombre,
                Precio = view.Precio,
                Stock = view.Stock,
                Usuarios = view.Usuarios


            };
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
            var view = this.ToProductViewModel(product);
            return View(view);
        }

        private ProductosViewModel ToProductViewModel(Productos product)
        {
            return new ProductosViewModel
            {
                Id = product.Id,
                Disponi = product.Disponi,
                UltComp = product.UltComp,
                UltVent = product.UltVent,
                ImageUrl = product.ImageUrl,
                Nombre = product.Nombre,
                Precio = product.Precio,
                Stock = product.Stock,
                Usuarios = product.Usuarios
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductosViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        path = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Productos", view.ImageFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Productos/{view.ImageFile.FileName}";
                    }
                    var product = this.toProduct(view, path);
                    product.Usuarios = await this.userHelper.GetUserByEmailAsync("Icastro@tas-seguridad.com");
                    await this.repositorioProductos.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.repositorioProductos.ExistAsync(view.Id))
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
            return View(view);
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