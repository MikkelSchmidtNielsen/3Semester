using BlazorAppRESTAPIAssignments.Shared.Models;

namespace BlazorAppRESTAPIAssignments.Components.Models
{
    public class ShoppingRepository : IShoppingRepository
    {
        private static readonly List<ShoppingItem> Items;

        public void AddItem(ShoppingItem item)
        {
            Items.Add(item);
        }

        public bool DeleteItem(int id)
        {
            ShoppingItem FoundItem = FindItem(id);
            if (FoundItem.Id != -1)
            {
                Items.Remove(FoundItem);
                return true;
            }
            else return false;
        }


        public bool UpdateItem(ShoppingItem item)
        {
            throw new NotImplementedException();
        }


        //return item with id = -1 if not found
        public ShoppingItem FindItem(int id)
        {
            foreach (var item in Items)
            {
                if (item.Id == id)
                    return item;
            }
            return new ShoppingItem(-1, "", 0, false);
        }

        public List<ShoppingItem> GetAllItems()
        {
            return Items;
        }


        static ShoppingRepository()
        {
            Items = new List<ShoppingItem>();
            Items.Clear();
            InsertTestData();

        }

        public static void InsertTestData()
        {
            Items.Add(new ShoppingItem(id: 1, "Bananer", 5, false));
            Items.Add(new ShoppingItem(id: 2, "Gulerødder", 10, true));

        }
    }
}
