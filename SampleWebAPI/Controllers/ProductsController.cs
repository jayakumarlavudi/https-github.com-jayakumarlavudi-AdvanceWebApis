using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SampleWebAPI.Controllers
{
    #region "Api Versioning using URI"
    //[ApiVersion("1.0")]
    ////[Route("api/[controller]")]
    //[Route("v{v:apiversion}/Products")]
    //[ApiController]
    //public class Productsv1Controller : ControllerBase
    //{

    //    private readonly ShopContext _shopContext;

    //    public Productsv1Controller(ShopContext shopContext)
    //    {
    //        _shopContext = shopContext;
    //        _shopContext.Database.EnsureCreated();
    //    }

    //    //[HttpGet]
    //    //public IEnumerable<Product> GetAllProducts()
    //    //{
    //    //    return _shopContext.products.ToList();
    //    //}

    //    //Using Action result

    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts([FromQuery] ProductQueryParameters productQueryParameters)
    //    {
    //        IQueryable<Product> products = _shopContext.products;
    //        products = products
    //        .Skip(productQueryParameters.Size * (productQueryParameters.Page - 1))
    //        .Take(productQueryParameters.Size);

    //        if (productQueryParameters.minPrice != null)
    //        {
    //            products = products.Where(p => p.Price >= productQueryParameters.minPrice.Value);
    //        }

    //        if (productQueryParameters.maxPrice != null)
    //        {
    //            products = products.Where(p => p.Price <= productQueryParameters.maxPrice.Value);
    //        }

    //        if (!string.IsNullOrEmpty(productQueryParameters.SearchTerm))
    //        {
    //            products = products.Where(p => p.Sku.ToLower().Contains(productQueryParameters.SearchTerm.ToLower()) ||
    //                                      p.Name.ToLower().Contains(productQueryParameters.SearchTerm.ToLower()));

    //        }

    //        if (!string.IsNullOrEmpty(productQueryParameters.sku))
    //        {
    //            products = products.Where(p => p.Sku.Equals(productQueryParameters.sku));
    //        }

    //        if (!string.IsNullOrEmpty(productQueryParameters.Name))
    //        {
    //            products = products.Where(p => p.Name.ToLower().Contains(productQueryParameters.Name.ToLower()));
    //        }

    //        if (!string.IsNullOrEmpty(productQueryParameters.SortBy))
    //        {
    //            if (typeof(Product).GetProperty(productQueryParameters.SortBy) != null)
    //            {
    //                products = products.OrderByCustom(
    //                    productQueryParameters.SortBy,
    //                    productQueryParameters.SortOrder);
    //            }
    //        }

    //        //var products = await _shopContext.products.ToListAsync();
    //        return Ok(await products.ToArrayAsync());// return 200 status code and return payload.
    //    }

    //    [HttpGet("{Id}")]
    //    public async Task<ActionResult> GetProduct(int Id)
    //    {
    //        var product = await _shopContext.products.FindAsync(Id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(product);

    //    }

    //    [HttpPost]
    //    public async Task<ActionResult<Product>> AddProduct(Product product)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest();
    //        }

    //        _shopContext.products.Add(product);
    //        await _shopContext.SaveChangesAsync();
    //        return CreatedAtAction("GetProduct", new { id = product.Id }, product);

    //    }

    //    [HttpPut("Id")]
    //    public async Task<IActionResult> PutProduct(int Id, [FromBody] Product product)
    //    {
    //        if (!ModelState.IsValid) { BadRequest(); }

    //        if (Id != product.Id)
    //        {
    //            return BadRequest();
    //        }

    //        _shopContext.Entry(product).State = EntityState.Modified;
    //        try
    //        {
    //            await _shopContext.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            //Concurrency exception can occure if the object is already updated or deleted
    //            if (!_shopContext.products.Any(x => x.Id == Id))
    //            {
    //                return NotFound();
    //            }
    //            else throw;

    //        }

    //        return NoContent();

    //    }

    //    [HttpDelete("Id")]

    //    public async Task<ActionResult<Product>> DeleteProduct(int Id)
    //    {
    //        if (!ModelState.IsValid) { BadRequest(); }

    //        var product = await _shopContext.products.FindAsync(Id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }
    //        _shopContext.products.Remove(product);
    //        await _shopContext.SaveChangesAsync();
    //        return product;
    //    }

    //    [HttpPost]
    //    [Route("Delete")]
    //    public async Task<ActionResult> BulkDelete([FromQuery] int[] productList)
    //    {
    //        List<Product> deletedList = new List<Product>();
    //        foreach (var item in productList)
    //        {
    //            var product = await _shopContext.products.FindAsync(item);
    //            if (product == null) { return NotFound(); }
    //            else
    //            {

    //                deletedList.Add(product);
    //            }

    //            _shopContext.products.RemoveRange(deletedList);
    //            await _shopContext.SaveChangesAsync();

    //            // return all the deleted products

    //        }
    //        return Ok(productList);
    //    }


    //}

    //[ApiVersion("2.0")]
    ////[Route("api/[controller]")]
    //[Route("v{v:apiversion}/Products")]
    //[ApiController]
    //public class Productsv2Controller : ControllerBase
    //{

    //    private readonly ShopContext _shopContext;

    //    public Productsv2Controller(ShopContext shopContext)
    //    {
    //        _shopContext = shopContext;
    //        _shopContext.Database.EnsureCreated();
    //    }

    //    //[HttpGet]
    //    //public IEnumerable<Product> GetAllProducts()
    //    //{
    //    //    return _shopContext.products.ToList();
    //    //}

    //    //Using Action result

    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts([FromQuery] ProductQueryParameters productQueryParameters)
    //    {
    //        IQueryable<Product> products = _shopContext.products.Where(p => p.IsAvailable == true);
    //        products = products
    //        .Skip(productQueryParameters.Size * (productQueryParameters.Page - 1))
    //        .Take(productQueryParameters.Size);

    //        if (productQueryParameters.minPrice != null)
    //        {
    //            products = products.Where(p => p.Price >= productQueryParameters.minPrice.Value);
    //        }

    //        if (productQueryParameters.maxPrice != null)
    //        {
    //            products = products.Where(p => p.Price <= productQueryParameters.maxPrice.Value);
    //        }

    //        if (!string.IsNullOrEmpty(productQueryParameters.SearchTerm))
    //        {
    //            products = products.Where(p => p.Sku.ToLower().Contains(productQueryParameters.SearchTerm.ToLower()) ||
    //                                      p.Name.ToLower().Contains(productQueryParameters.SearchTerm.ToLower()));

    //        }

    //        if (!string.IsNullOrEmpty(productQueryParameters.sku))
    //        {
    //            products = products.Where(p => p.Sku.Equals(productQueryParameters.sku));
    //        }

    //        if (!string.IsNullOrEmpty(productQueryParameters.Name))
    //        {
    //            products = products.Where(p => p.Name.ToLower().Contains(productQueryParameters.Name.ToLower()));
    //        }

    //        if (!string.IsNullOrEmpty(productQueryParameters.SortBy))
    //        {
    //            if (typeof(Product).GetProperty(productQueryParameters.SortBy) != null)
    //            {
    //                products = products.OrderByCustom(
    //                    productQueryParameters.SortBy,
    //                    productQueryParameters.SortOrder);
    //            }
    //        }

    //        //var products = await _shopContext.products.ToListAsync();
    //        return Ok(await products.ToArrayAsync());// return 200 status code and return payload.
    //    }

    //    [HttpGet("{Id}")]
    //    public async Task<ActionResult> GetProduct(int Id)
    //    {
    //        var product = await _shopContext.products.FindAsync(Id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(product);

    //    }

    //    [HttpPost]
    //    public async Task<ActionResult<Product>> AddProduct(Product product)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest();
    //        }

    //        _shopContext.products.Add(product);
    //        await _shopContext.SaveChangesAsync();
    //        return CreatedAtAction("GetProduct", new { id = product.Id }, product);

    //    }

    //    [HttpPut("Id")]
    //    public async Task<IActionResult> PutProduct(int Id, [FromBody] Product product)
    //    {
    //        if (!ModelState.IsValid) { BadRequest(); }

    //        if (Id != product.Id)
    //        {
    //            return BadRequest();
    //        }

    //        _shopContext.Entry(product).State = EntityState.Modified;
    //        try
    //        {
    //            await _shopContext.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            //Concurrency exception can occure if the object is already updated or deleted
    //            if (!_shopContext.products.Any(x => x.Id == Id))
    //            {
    //                return NotFound();
    //            }
    //            else throw;

    //        }

    //        return NoContent();

    //    }

    //    [HttpDelete("Id")]

    //    public async Task<ActionResult<Product>> DeleteProduct(int Id)
    //    {
    //        if (!ModelState.IsValid) { BadRequest(); }

    //        var product = await _shopContext.products.FindAsync(Id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }
    //        _shopContext.products.Remove(product);
    //        await _shopContext.SaveChangesAsync();
    //        return product;
    //    }

    //    [HttpPost]
    //    [Route("Delete")]
    //    public async Task<ActionResult> BulkDelete([FromQuery] int[] productList)
    //    {
    //        List<Product> deletedList = new List<Product>();
    //        foreach (var item in productList)
    //        {
    //            var product = await _shopContext.products.FindAsync(item);
    //            if (product == null) { return NotFound(); }
    //            else
    //            {

    //                deletedList.Add(product);
    //            }

    //            _shopContext.products.RemoveRange(deletedList);
    //            await _shopContext.SaveChangesAsync();

    //            // return all the deleted products

    //        }
    //        return Ok(productList);
    //    }


    //}
    #endregion

    #region"API Versioning using HTTP Header"
    [ApiVersion("1.0")]
    [Route("Products")]
    [ApiController]
    public class ProductsV1Controller : ControllerBase
    {

        private readonly ShopContext _shopContext;

        public ProductsV1Controller(ShopContext shopContext)
        {
            _shopContext = shopContext;
            _shopContext.Database.EnsureCreated();
        }

        //[HttpGet]
        //public IEnumerable<Product> GetAllProducts()
        //{
        //    return _shopContext.products.ToList();
        //}

        //Using Action result

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts([FromQuery] ProductQueryParameters productQueryParameters)
        {
            IQueryable<Product> products = _shopContext.products;
            products = products
            .Skip(productQueryParameters.Size * (productQueryParameters.Page - 1))
            .Take(productQueryParameters.Size);

            if (productQueryParameters.minPrice != null)
            {
                products = products.Where(p => p.Price >= productQueryParameters.minPrice.Value);
            }

            if (productQueryParameters.maxPrice != null)
            {
                products = products.Where(p => p.Price <= productQueryParameters.maxPrice.Value);
            }

            if (!string.IsNullOrEmpty(productQueryParameters.SearchTerm))
            {
                products = products.Where(p => p.Sku.ToLower().Contains(productQueryParameters.SearchTerm.ToLower()) ||
                                          p.Name.ToLower().Contains(productQueryParameters.SearchTerm.ToLower()));

            }

            if (!string.IsNullOrEmpty(productQueryParameters.sku))
            {
                products = products.Where(p => p.Sku.Equals(productQueryParameters.sku));
            }

            if (!string.IsNullOrEmpty(productQueryParameters.Name))
            {
                products = products.Where(p => p.Name.ToLower().Contains(productQueryParameters.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(productQueryParameters.SortBy))
            {
                if (typeof(Product).GetProperty(productQueryParameters.SortBy) != null)
                {
                    products = products.OrderByCustom(
                        productQueryParameters.SortBy,
                        productQueryParameters.SortOrder);
                }
            }

            //var products = await _shopContext.products.ToListAsync();
            return Ok(await products.ToArrayAsync());// return 200 status code and return payload.
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetProduct(int Id)
        {
            var product = await _shopContext.products.FindAsync(Id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _shopContext.products.Add(product);
            await _shopContext.SaveChangesAsync();
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);

        }

        [HttpPut("Id")]
        public async Task<IActionResult> PutProduct(int Id, [FromBody] Product product)
        {
            if (!ModelState.IsValid) { BadRequest(); }

            if (Id != product.Id)
            {
                return BadRequest();
            }

            _shopContext.Entry(product).State = EntityState.Modified;
            try
            {
                await _shopContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Concurrency exception can occure if the object is already updated or deleted
                if (!_shopContext.products.Any(x => x.Id == Id))
                {
                    return NotFound();
                }
                else throw;

            }

            return NoContent();

        }

        [HttpDelete("Id")]

        public async Task<ActionResult<Product>> DeleteProduct(int Id)
        {
            if (!ModelState.IsValid) { BadRequest(); }

            var product = await _shopContext.products.FindAsync(Id);
            if (product == null)
            {
                return NotFound();
            }
            _shopContext.products.Remove(product);
            await _shopContext.SaveChangesAsync();
            return product;
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult> BulkDelete([FromQuery] int[] productList)
        {
            List<Product> deletedList = new List<Product>();
            foreach (var item in productList)
            {
                var product = await _shopContext.products.FindAsync(item);
                if (product == null) { return NotFound(); }
                else
                {

                    deletedList.Add(product);
                }

                _shopContext.products.RemoveRange(deletedList);
                await _shopContext.SaveChangesAsync();

                // return all the deleted products

            }
            return Ok(productList);
        }


    }


    [ApiVersion("2.0")]
    [Route("Products")]
    [ApiController]
    public class ProductsV2Controller : ControllerBase
    {

        private readonly ShopContext _shopContext;

        public ProductsV2Controller(ShopContext shopContext)
        {
            _shopContext = shopContext;
            _shopContext.Database.EnsureCreated();
        }

        //[HttpGet]
        //public IEnumerable<Product> GetAllProducts()
        //{
        //    return _shopContext.products.ToList();
        //}

        //Using Action result

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts([FromQuery] ProductQueryParameters productQueryParameters)
        {
            IQueryable<Product> products = _shopContext.products;
            products = products
            .Skip(productQueryParameters.Size * (productQueryParameters.Page - 1))
            .Take(productQueryParameters.Size);

            if (productQueryParameters.minPrice != null)
            {
                products = products.Where(p => p.Price >= productQueryParameters.minPrice.Value);
            }

            if (productQueryParameters.maxPrice != null)
            {
                products = products.Where(p => p.Price <= productQueryParameters.maxPrice.Value);
            }

            if (!string.IsNullOrEmpty(productQueryParameters.SearchTerm))
            {
                products = products.Where(p => p.Sku.ToLower().Contains(productQueryParameters.SearchTerm.ToLower()) ||
                                          p.Name.ToLower().Contains(productQueryParameters.SearchTerm.ToLower()));

            }

            if (!string.IsNullOrEmpty(productQueryParameters.sku))
            {
                products = products.Where(p => p.Sku.Equals(productQueryParameters.sku));
            }

            if (!string.IsNullOrEmpty(productQueryParameters.Name))
            {
                products = products.Where(p => p.Name.ToLower().Contains(productQueryParameters.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(productQueryParameters.SortBy))
            {
                if (typeof(Product).GetProperty(productQueryParameters.SortBy) != null)
                {
                    products = products.OrderByCustom(
                        productQueryParameters.SortBy,
                        productQueryParameters.SortOrder);
                }
            }

            //var products = await _shopContext.products.ToListAsync();
            return Ok(await products.ToArrayAsync());// return 200 status code and return payload.
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetProduct(int Id)
        {
            var product = await _shopContext.products.FindAsync(Id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _shopContext.products.Add(product);
            await _shopContext.SaveChangesAsync();
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);

        }

        [HttpPut("Id")]
        public async Task<IActionResult> PutProduct(int Id, [FromBody] Product product)
        {
            if (!ModelState.IsValid) { BadRequest(); }

            if (Id != product.Id)
            {
                return BadRequest();
            }

            _shopContext.Entry(product).State = EntityState.Modified;
            try
            {
                await _shopContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Concurrency exception can occure if the object is already updated or deleted
                if (!_shopContext.products.Any(x => x.Id == Id))
                {
                    return NotFound();
                }
                else throw;

            }

            return NoContent();

        }

        [HttpDelete("Id")]

        public async Task<ActionResult<Product>> DeleteProduct(int Id)
        {
            if (!ModelState.IsValid) { BadRequest(); }

            var product = await _shopContext.products.FindAsync(Id);
            if (product == null)
            {
                return NotFound();
            }
            _shopContext.products.Remove(product);
            await _shopContext.SaveChangesAsync();
            return product;
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult> BulkDelete([FromQuery] int[] productList)
        {
            List<Product> deletedList = new List<Product>();
            foreach (var item in productList)
            {
                var product = await _shopContext.products.FindAsync(item);
                if (product == null) { return NotFound(); }
                else
                {

                    deletedList.Add(product);
                }

                _shopContext.products.RemoveRange(deletedList);
                await _shopContext.SaveChangesAsync();

                // return all the deleted products

            }
            return Ok(productList);
        }


    }

    #endregion
}
