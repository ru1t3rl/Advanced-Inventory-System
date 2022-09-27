using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ru1t3rl.InventorySystem
{
    public interface IInventory
    {
        List<IInventoryItem> Items { get; }
        int Count(IStackable item);
        bool Contains(IInventoryItem item);
        void Add(IInventoryItem item, int count);
        void Remove(IInventoryItem item, int count);
    }
}