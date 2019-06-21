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
        [HttpPut("{Id}")]
        public ActionResult<Location> UpdateLoc(int Id, [FromBody]Location location)
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