using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBMobile.Items
{
    public class Item : IItem
    {
        public int Id { get; set; }
        public ItemInfo ItemInfo { get; set; }
    }
}
