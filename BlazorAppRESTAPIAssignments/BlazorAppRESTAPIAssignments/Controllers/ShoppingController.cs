using BlazorAppRESTAPIAssignments.Components.Models;
using BlazorAppRESTAPIAssignments.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlazorAppRESTAPIAssignments.Controllers
{
    [ApiController]
    [Route("api/shopapi")]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingRepository Repository = new ShoppingRepository();

        public ShoppingController(IShoppingRepository shoppingRepository)
        {
            if (Repository == null && shoppingRepository != null)
            {
                Repository = shoppingRepository;
                Console.WriteLine("Repository initialized");
            }
        }

        [HttpGet]
        public IEnumerable<ShoppingItem> GetAllItems()
        {
            return Repository.GetAllItems();
        }

        [HttpDelete("{id:int}")]
        public StatusCodeResult DeleteItem(int id)
        {
            Console.WriteLine("Server: Delete item called: id = " + id);

            bool deleted = Repository.DeleteItem(id);
            if (deleted)
            {
                Console.WriteLine("Server: Item deleted succces");
                int code = (int)HttpStatusCode.OK;
                return new StatusCodeResult(code);
            }
            else
            {
                Console.WriteLine("Server: Item deleted fail - not found");
                int code = (int)HttpStatusCode.NotFound;
                return new StatusCodeResult(code);
            }
        }

        [HttpPost]
        public IActionResult AddItem(ShoppingItem item)
        {
            Console.WriteLine("Add item called: " + item.ToString());
            Repository.AddItem(item);
            return Ok(); // return Ok = errorcode 200
        }

        [HttpGet("{id:int}")]
        public ShoppingItem FindItem(int id)
        {
            var result = Repository.FindItem(id);
            return result;
        }

        [HttpPut]
        public bool UpdateItem(ShoppingItem item)
        {
            var result = Repository.UpdateItem(item);
            return result;
        }
    }
}
