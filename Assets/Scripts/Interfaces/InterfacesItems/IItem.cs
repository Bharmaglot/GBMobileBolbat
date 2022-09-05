using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBMobile.Items
{
    public interface IItem
    {
        int Id { get; }
        ItemInfo ItemInfo { get; }
    }
}