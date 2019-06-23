using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using wills_inventory.Models;

namespace wills_inventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private DatabaseContext db;

        public LocationsController()
        {
            this.db = new DatabaseContext();
        }
        [HttpPost]
        public ActionResult<Location> Add([FromBody] Location addLoc)
        {
            db.Locations.Add(addLoc);
            db.SaveChanges();
            return addLoc;
        }
        [HttpGet]
        public ActionResult<List<Location>> Get()
        {
            var results = db.Locations;
            return results.ToList();
        }

    }
}