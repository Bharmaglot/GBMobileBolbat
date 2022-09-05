using System.Collections.Generic;

namespace GBMobile.Items
{
    public class ItemRepository : BaseController, IItemsRepository
    {
        public ItemRepository(List<ItemConfig> items)
        {
            PopulateItems(ref _items, items);
        }



        public IReadOnlyDictionary<int, IItem> Items => _items;
        public Dictionary<int, IItem> _items;
        
        private void PopulateItems(ref Dictionary<int, IItem> items, List<ItemConfig> itemConfigs)
        {
            items = new Dictionary<int, IItem>();
            foreach (var item in itemConfigs)
            {
                items[item.Id] = CreateItem(item);
            }
        }

        private IItem CreateItem(ItemConfig item)
        {
            return new Item()
            {
                Id = item.Id,
                ItemInfo = new ItemInfo()
                {
                    Title = item.Title
                }
            };
        }

        protected override void OnDispose()
        {
            _items.Clear();
            base.OnDispose();
        }
    }
}
