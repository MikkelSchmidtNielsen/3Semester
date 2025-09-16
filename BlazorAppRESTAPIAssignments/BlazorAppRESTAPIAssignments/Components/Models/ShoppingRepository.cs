using BlazorAppRESTAPIAssignments.Shared.Models;

namespace BlazorAppRESTAPIAssignments.Components.Models
{
    public class ShoppingRepository : IShoppingRepository
    {
        private static readonly List<ShoppingItem> Items;
        private static int _id;

		static ShoppingRepository()
		{
			Items = new List<ShoppingItem>();
			Items.Clear();
			InsertTestData();

            _id = Items.Count;
		}

		public void AddItem(ShoppingItem item)
        {
            _id++;
            item.Id = _id;
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
            ShoppingItem oldShoppingItem = Items.FirstOrDefault(x => x.Id == item.Id);

            if (oldShoppingItem != null)
            {
                oldShoppingItem.Name = item.Name;
                oldShoppingItem.Quantity = item.Quantity;

                return true;
            }
            else
            {
                return false;
            }
        }


        //return item with id = -1 if not found
        public ShoppingItem FindItem(int id)
        {
            foreach (var item in Items)
            {
                if (item.Id == id)
                    return item;
            }
            return new ShoppingItem(-1);
        }

        public List<ShoppingItem> GetAllItems()
        {
            return Items;
        }

        public static void InsertTestData()
        {
            Items.Add(new ShoppingItem(id: 1, "Bananer", 5, false));
            Items.Add(new ShoppingItem(id: 2, "Gulerødder", 10, true));
        }
    }
}
