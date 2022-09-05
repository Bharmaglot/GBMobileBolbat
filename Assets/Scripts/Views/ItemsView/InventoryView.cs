using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GBMobile.Items
{
    public class InventoryView : IInventoryView
    {
        public event EventHandler<IItem> Selected;

        public event EventHandler<IItem> Deselected;

        public void Display(IReadOnlyList<IItem> items)
        {
            Debug.Log("Equiped: " + string.Join(", ", items.Select(i =>$"{i.Id}::{i.ItemInfo.Title}").ToArray()));
        }

    }
}