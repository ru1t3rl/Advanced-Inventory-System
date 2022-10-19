using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ru1t3rl.InventorySystem.Behaviours
{
    [RequireComponent(typeof(InventoryItem))]
    public class InventoryItemBehaviour : MonoBehaviour
    {
        [SerializeField] protected string inventoryName;
        protected InventoryItem item;
        public InventoryItem Item => item;

        protected virtual void Awake()
        {
            item = GetComponent<InventoryItem>();
        }

        /// <summary> OnTriggerEnter is called when the Collider other enters the trigger.</summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        protected virtual void OnTriggerEnter(Collider other)
        {
            InventoriesManager.Instance.GetInventory(inventoryName, true)?.Add(item);
        }
    }
}