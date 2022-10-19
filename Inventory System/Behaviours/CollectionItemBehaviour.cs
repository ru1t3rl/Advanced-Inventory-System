using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Ru1t3rl.Events;

namespace Ru1t3rl.InventorySystem.Behaviours
{
    public class CollectionItemBehaviour : Inventory, IInventoryItem
    {
        public string inventoryParentName;

        public bool isCollection = true;
        public string collectionName;

        [SerializeField] protected string name;
        public string Name => name;

        [SerializeField] protected Sprite icon;
        public Sprite Icon => icon;

        [SerializeField] protected bool collected = false;
        public bool Collected => collected;

        public UnityEvent onCollect, onDrop;

        private void Awake()
        {
            InventoriesManager.Instance.GetInventory(inventoryParentName).Add(this);

            if (isCollection)
                InventoriesManager.Instance.AddInventory(this, collectionName);
        }

        private void Start()
        {
            EventManager.Instance.AddEvent($"OnCollect_{name}", onCollect);
            EventManager.Instance.AddEvent($"OnDrop_{name}", onDrop);
        }

        private void OnDestroy()
        {
            EventManager.Instance.RemoveEvent($"OnCollect_{name}");
            EventManager.Instance.RemoveEvent($"OnDrop_{name}");
        }

        public void Use()
        {
            // Call the UI to show a list of items in the collection
        }

        public void SubscribeToEvents(System.Action listener)
        {
            EventManager.Instance.AddListener($"OnCollect_{name}", listener.Invoke);
            EventManager.Instance.AddListener($"OnDrop_{name}", listener.Invoke);
        }

        public void UnSubscribeToEvents(System.Action listener)
        {
            EventManager.Instance.RemoveListener($"OnCollect_{name}", listener.Invoke);
            EventManager.Instance.RemoveListener($"OnDrop_{name}", listener.Invoke);
        }
    }
}