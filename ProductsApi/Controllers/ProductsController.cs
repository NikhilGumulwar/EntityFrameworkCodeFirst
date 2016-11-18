using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        private readonly ProductsApiContext _db = new ProductsApiContext();

        // GET: api/Products
        [Route("")]
        [HttpGet]
        public IQueryable<Product> Getproducts()
        {
            // Loads the Products AND all related ProductsReviews using Eager Loading

            return _db.Products.Include(p=>p.Reviews);   /*---------------The Eager Loading function is useful when you want to load 
                                                                         the main Entity togheter with its (theirs) related entities right
                                                                         from the start, possibly using a single query command. 
                                                                         In order to use that you need to use the Include() method-----------------*/

           
        }
        #region GerProduct without EagerLoading
        //public IList<ProductDTO> GetProducts()
        //{
        //    return db.Products.Select(p => new ProductDTO
        //    {
        //        Name = p.Name,
        //        Category = p.Category,
        //        Price = p.Price,
        //        Reviews = p.Reviews.ToList()
        //    }).ToList();
        //return db.entry(product).collection(i => i.reviews).load();
        //} 
        #endregion

        // GET: api/Products/5
        [HttpGet]
        [ResponseType(typeof(Product))]
        [Route("{id}")]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
           
            _db.Entry(product).Collection(i => i.Reviews).Load();
          
            //db.Products.Select(p => new ProductDTO
            //{
            //    Name = p.Name,
            //    Category = p.Category,
            //    Price = p.Price,
            //    ProductId=product.ProductId,
            //    Reviews = p.Reviews.ToList()
            //}).ToList();


            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _db.Entry(product).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try {
                _db.Products.Add(product);
            }
            catch (Exception)
            {
                // ignored
            }
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
            //Ok("Data Inserted");
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _db.Products.Remove(product);
            _db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return _db.Products.Count(e => e.ProductId == id) > 0;
        }
    }
}