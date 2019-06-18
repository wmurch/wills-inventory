using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using wills_inventory.Models;

namespace wills_inventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController
    {
        [HttpPost]
        public ActionResult<Item> Post([FromBody]Item postItem)
        {
            var db = new DatabaseContext();
            db.Items.Add(postItem);
            db.SaveChanges();
            return postItem;
        }
        [HttpGet]
        public ActionResult<List<Item>> Get()
        {
            var db = new DatabaseContext();
            var results = db.Items;
            return results.ToList();
        }
        [HttpGet("{Id}")]
        public ActionResult<Item> Get(int Id)
        {
            var db = new DatabaseContext();
            var results = db.Items.FirstOrDefault(w => w.Id == Id);

            return results;
        }


    }
}