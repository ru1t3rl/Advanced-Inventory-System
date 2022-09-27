using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Ru1t3rl.Events;

namespace Ru1t3rl.InventorySystem
{
    public class InventoryItem : MonoBehaviour, IInventoryItem, IStackable
    {
        public UnityEvent onAdd, onRemove, onUse, onDestroy;

        [SerializeField] private Sprite icon;
        public Sprite Icon => icon;

        [SerializeField] private new string name;
        public string Name => name;

        [SerializeField] private int count;
        public int Count => count;

        protected virtual void Awake()
        {
            EventManager.Instance.AddEvent($"OnUse_{this.GetHashCode()}", onUse);
            EventManager.Instance.AddEvent($"OnDestroy_{this.GetHashCode()}", onDestroy);
            EventManager.Instance.AddEvent($"OnAdd_{this.GetHashCode()}", onAdd);
            EventManager.Instance.AddEvent($"OnRemove_{this.GetHashCode()}", onRemove);
        }

        public virtual void Use()
        {
            count--;

            if (count <= 0)
            {
                Destroy();
            }
        }

        /// <summary>Add one item to the amount of this item</summary>
        public virtual void Add(int count = 1)
        {
            this.count += count;
            EventManager.Instance.Invoke($"OnAdd_{this.GetHashCode()}");
        }

        /// <summary>Remove one item from the amount of this item</summary>
        public virtual void Remove(int count = 1)
        {
            this.count -= count;
            EventManager.Instance.Invoke($"OnRemove_{this.GetHashCode()}");
        }

        /// <summary>Set the number of items</summary>
        public void SetCount(int count)
        {
            this.count = count;
        }

        /// <summary>Destroy this item</summary>
        public void Destroy()
        {
            EventManager.Instance.Invoke($"OnDestroy_{this.GetHashCode()}");

            EventManager.Instance.RemoveEvent($"OnAdd_{this.GetHashCode()}");
            EventManager.Instance.RemoveEvent($"OnRemove_{this.GetHashCode()}");
            EventManager.Instance.RemoveEvent($"OnUse_{this.GetHashCode()}");
            EventManager.Instance.RemoveEvent($"OnDestroy_{this.GetHashCode()}");

            Destroy(gameObject);
        }

        /// <summary>Add the specified method to the listeners</summary>
        /// <param name="action">The method to add</param>
        public void SubscribeToEvents(System.Action action)
        {
            EventManager.Instance.AddListener($"OnUse_{this.GetHashCode()}", action);
            EventManager.Instance.AddListener($"OnDestroy_{this.GetHashCode()}", action);
            EventManager.Instance.AddListener($"OnAdd_{this.GetHashCode()}", action);
            EventManager.Instance.AddListener($"OnRemove_{this.GetHashCode()}", action);
        }

        /// <summary>Remove the specified method from the listeners</summary>
        /// <param name="action">The method to remove</param>
        public void UnSubscribeToEvents(System.Action action)
        {
            EventManager.Instance.RemoveListener($"OnUse_{this.GetHashCode()}", action);
            EventManager.Instance.RemoveListener($"OnDestroy_{this.GetHashCode()}", action);
            EventManager.Instance.RemoveListener($"OnAdd_{this.GetHashCode()}", action);
            EventManager.Instance.RemoveListener($"OnRemove_{this.GetHashCode()}", action);
        }
    }
}