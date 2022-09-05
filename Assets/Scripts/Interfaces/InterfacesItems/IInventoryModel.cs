using System.Collections.Generic;

namespace GBMobile.Items
{
    public interface IInventoryModel 
    {
        IReadOnlyList<IItem> GetEquipedItems();
        void Equip(IItem item);
        void Unequip(IItem item);

    }
}
