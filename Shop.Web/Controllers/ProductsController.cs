namespace Shop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Data;
    using Shop.Web.Data.Entities;
    using Shop.Web.Helpers;
    using System.Threading.Tasks;


    public class ProductsController : Controller
    {
        private readonly IRepository repository;

        private readonly IUserHelper userHelper;

        public ProductsController(IRepository repository, IUserHelper userHelper)
        {
            this.repository = repository;
            this.userHelper = userHelper;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(repository.GetProducts());
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = repository.GetProduct(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                //TODO:  Change fot the logger user
                product.User = await this.userHelper.GetUserByMailAsync("magdiel.palacios@csfacturacion.com");

                repository.AddProduct(product);

                await repository.SaveAllAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = repository.GetProduct(id.Value);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    //TODO:  Change fot the logger user
                    product.User = await this.userHelper.GetUserByMailAsync("magdiel.palacios@csfacturacion.com");
                    repository.UpdateProduct(product);
                    await repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!repository.ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = repository.GetProduct(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = repository.GetProduct(id);

            repository.RemoveProduct(product);

            await repository.SaveAllAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
