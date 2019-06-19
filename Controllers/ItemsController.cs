using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using wills_inventory.Models;

namespace wills_inventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private DatabaseContext db;

        public ItemsController()
        {
            this.db = new DatabaseContext();
        }
        [HttpPost]
        public ActionResult<Item> Post([FromBody]Item postItem)
        {
            //var db = new DatabaseContext();
            db.Items.Add(postItem);
            db.SaveChanges();
            return postItem;
        }
        [HttpGet]
        public ActionResult<List<Item>> Get()
        {
            // var db = new DatabaseContext();
            var results = db.Items;
            return results.ToList();
        }
        [HttpGet("id/{Id}")]
        public ActionResult<Item> Get(int Id)
        {
            //var db = new DatabaseContext();
            var results = db.Items.FirstOrDefault(w => w.Id == Id);

            return results;
        }
        [HttpGet("OutOfStock")]
        public ActionResult<List<Item>> GetOutOfStock()
        {
            //var db = new DatabaseContext();
            var results = db.Items.Where(w => w.NumberInStock == 0);

            return results.ToList();
        }
        [HttpGet("SKU/{SKU}")]
        public ActionResult<Item> GetSKU(int SKU)
        {
            //var db = new DatabaseContext();
            var results = db.Items.FirstOrDefault(w => w.SKU == SKU);

            return results;
        }
        [HttpPut("{Id}")]
        public ActionResult<Item> Update(int Id, [FromBody]Item item)
        {
            //var db = new DatabaseContext();
            var results = db.Items.FirstOrDefault(w => w.Id == Id);
            results.SKU = item.SKU;
            results.Name = item.Name;
            results.NumberInStock = item.NumberInStock;
            results.ShortDescription = item.ShortDescription;
            results.Price = item.Price;
            results.DateOrdered = item.DateOrdered;
            db.SaveChanges();
            return results;
        }
        [HttpDelete("{Id}")]
        public ActionResult<Item> Delete(int Id)
        {
            //var db = new DatabaseContext();
            var results = db.Items.FirstOrDefault(w => w.Id == Id);
            db.Items.Remove(results);
            db.SaveChanges();
            return Ok();
        }
    }
}