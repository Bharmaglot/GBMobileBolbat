using System.Collections;
using System.Collections.Generic;

namespace GBMobile.Items
{
    public interface IItemsRepository
    {
        IReadOnlyDictionary<int, IItem> Items { get; }
    }
}