using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBMobile.Items
{
    public interface IInventoryView
    {
        event EventHandler<IItem> Selected;
        event EventHandler<IItem> Deselected;
        void Display(IReadOnlyList<IItem> items);
    }
}