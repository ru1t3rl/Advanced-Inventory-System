using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ru1t3rl.Utilities;

namespace Ru1t3rl.InventorySystem
{
    public class InventoriesManager : UnitySingleton<InventoriesManager>
    {
        private Dictionary<string, Inventory> inventories = new Dictionary<string, Inventory>();
        public Dictionary<string, Inventory> Inventorie => inventories;

        /// <summary>Add a new inventory to the manager</summary>
        /// <param name="inventory">The inventory to add</param>
        /// <param name="key">The key of the inventory to add. Used for reference</param>
        public void AddInventory(Inventory inventory, string key)
        {
            if (ContainsInventory(key))
            {
                Debug.LogError($"<b>[Inventories Manager]</b>   Inventory with key {key} already exists");
                return;
            }
            else if (ContainsInventory(inventory))
            {
                Debug.LogError($"<b>[Inventories Manager]</b>   The inventory already exists with a different key | {GetKey(inventory)}");
                return;
            }

            inventories.Add(key, inventory);
        }

        /// <summary>Remove the inventory with the given key from the manager</summary>
        /// <param name="key">The key of the inventory to remove</param>
        public void RemoveInventory(string key)
        {
            if (!ContainsInventory(key))
            {
                Debug.LogError($"<b>[Inventories Manager]</b>   Inventory with key {key} does not exist");
                return;
            }

            inventories.Remove(key);
        }

        /// <summary>Check if the manager contains the given inventory and if so remove it</summary>
        /// <param name="Inventory">The inventory to remove</param>
        public void RemoveInventory(Inventory inventory)
        {
            if (!ContainsInventory(inventory))
            {
                Debug.LogError($"<b>[Inventories Manager]</b>   The inventory does not exist");
                return;
            }

            inventories.Remove(GetKey(inventory));
        }

        /// <summary>Empty the inventory manager</summary>
        public void Clear()
        {
            inventories.Clear();
        }

        /// <summary>Get the inventory with the given key</summary>
        /// <param name="key">The key of the inventory</param>
        /// <param name="createIfNotExists">Create the inventory if it does not exist</param>
        /// <returns>The inventory with the given key</returns>
        public Inventory GetInventory(string key, bool createWhenNull = true)
        {
            if (ContainsInventory(key))
            {
                return inventories[key];
            }
            else if (createWhenNull)
            {
                AddInventory(new Inventory(), key);
            }

            Debug.LogError($"<b>[Inventories Manager]</b>   Inventory with key {key} does not exist");
            return null;
        }

        /// <summary>Get the key of the given inventory</summary>
        /// <param name="inventory">The inventory to get the key for</param>
        /// <returns>The key of the given inventory</returns>
        public string GetKey(Inventory inventory)
        {
            foreach (var item in inventories)
            {
                if (item.Value == inventory)
                {
                    return item.Key;
                }
            }

            Debug.LogError($"<b>[Inventories Manager]</b>   The inventory does not exist");
            return null;
        }

        /// <summary>Check if the inventory with the given key exists</summary>
        public bool ContainsInventory(string key) => inventories.ContainsKey(key);

        /// <summary>Check if the given inventory exists</summary>
        public bool ContainsInventory(Inventory inventory) => inventories.ContainsValue(inventory);
    }
}