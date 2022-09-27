using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ru1t3rl.InventorySystem.Behaviours
{
    public class CollectionItemBehaviour : Inventory, IInventoryItem
    {
        [SerializeField] protected string name;
        public string Name => name;

        [SerializeField] protected Sprite icon;
        public Sprite Icon => icon;

        public void Use()
        {
            // Call the UI to show a list of items in the collection
        }
    }
}