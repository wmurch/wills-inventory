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
        [HttpPut("location/{Id}")]
        public ActionResult<Location> AddLoc(int Id, [FromBody]Location location)
        {
            var results = db.Locations.FirstOrDefault(w => w.Id == Id);
            results.Address = location.Address;
            results.ManagerName = location.ManagerName;
            results.PhoneNumber = location.PhoneNumber;
            db.SaveChanges();
            return results;
        }

    }
}