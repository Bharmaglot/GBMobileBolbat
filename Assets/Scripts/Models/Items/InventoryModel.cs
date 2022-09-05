using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBMobile.Items
{
    public class InventoryModel : IInventoryModel
    {
        private List<IItem> _equiped = new List<IItem>();

        public IReadOnlyList<IItem> GetEquipedItems() => _equiped;


        public void Equip(IItem item)
        {
            if (_equiped.Contains(item))
                return;
            _equiped.Add(item);
        }

        public void Unequip(IItem item)
        {
            _equiped.Remove(item);
        }
    }
}
