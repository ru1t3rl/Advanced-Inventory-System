using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ru1t3rl.InventorySystem
{
    public class Inventory : IInventory
    {
        public List<IInventoryItem> Items { get; protected set; }

        public Inventory()
        {
            Items = new List<IInventoryItem>();
        }

        public int Count(IStackable item)
        {
            int count = 0;
            foreach (IStackable i in Items)
            {
                IInventoryItem inventoryItem = i as IInventoryItem;
                if (inventoryItem.Name == (item as IInventoryItem).Name)
                {
                    count += i.Count;
                }
            }
            return count;
        }

        public bool Contains(IInventoryItem item)
        {
            foreach (IInventoryItem i in Items)
            {
                if (i.Name == item.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(IInventoryItem item, int count = 1)
        {
            if (Contains(item))
            {
                foreach (IStackable i in Items)
                {
                    if ((i as IInventoryItem).Name == item.Name)
                    {
                        i.Add(count);
                    }
                }
            }
            else
            {
                Items.Add(item);
            }
        }

        public void Remove(IInventoryItem item, int count = 1)
        {
            if (Contains(item))
            {
                foreach (IStackable i in Items)
                {
                    if ((i as IInventoryItem).Name == item.Name)
                    {
                        i.Remove(count);
                        if (i.Count <= 0)
                        {
                            Items.Remove(i as IInventoryItem);
                        }
                    }
                }
            }
        }

        public void Clear()
        {
            Items.Clear();
        }

        public int Count(IInventoryItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}