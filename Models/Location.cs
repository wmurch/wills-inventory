using System.Collections.Generic;
namespace wills_inventory.Models
{
    public class Location
    {

        public int Id { get; set; }
        public string Address { get; set; }

        public string ManagerName { get; set; }
        public string PhoneNumber { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
    }
}