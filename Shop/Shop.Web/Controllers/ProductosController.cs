namespace Shop.Web.Controllers
{
    using Data;
    using Data.Entities;
    using Helper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Models;
    using System;
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
                return new NotFoundViewResult("ProductNotFound");
            }

            var product = await this.repositorioProductos.GetByIdAsync(id.Value);
            if (product == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            return View(product);
        }

        [Authorize(Roles = "Admin")]
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
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    var nombre = view.ImageFile.FileName.Substring(0, view.ImageFile.FileName.Length - 4);

                    path = Path.Combine(Directory.GetCurrentDirectory(),
                       "wwwroot\\images\\Productos", nombre + "-" + file);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Productos/{nombre + "-" + file}";
                }
                var product = this.toProduct(view, path);
                product.Usuarios = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var product = await this.repositorioProductos.GetByIdAsync(id.Value);
            if (product == null)
            {
                return new NotFoundViewResult("ProductNotFound");
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
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";
                        var nombre = view.ImageFile.FileName.Substring(0, view.ImageFile.FileName.Length - 4);

                        path = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Productos", nombre + "-" + file);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Productos/{nombre + "-" + file}";
                    }
                    var product = this.toProduct(view, path);
                    product.Usuarios = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    await this.repositorioProductos.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.repositorioProductos.ExistAsync(view.Id))
                    {
                        return new NotFoundViewResult("ProductNotFound");
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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var product = await this.repositorioProductos.GetByIdAsync(id.Value);
            if (product == null)
            {
                return new NotFoundViewResult("ProductNotFound");
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

        public IActionResult ProductNotFound()
        {
            return this.View();
        }

    }
}