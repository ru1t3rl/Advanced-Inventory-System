using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Ru1t3rl.Events;
using System;

namespace Ru1t3rl.InventorySystem.Behaviours
{
    public class StackableItemBehaviour : InventoryItem, IStackable
    {
        public UnityEvent onAdd, onRemove;

        private int count = 0;
        public int Count => count;

        protected override void Awake()
        {
            base.Awake();

            EventManager.Instance.AddEvent($"OnAdd_{this.GetHashCode()}", onAdd);
            EventManager.Instance.AddEvent($"OnRemove_{this.GetHashCode()}", onRemove);
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

        public override void Use()
        {
            base.Use();
            Remove();
        }

        /// <summary>Destroy this item</summary>
        public override void Destroy()
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
        public override void SubscribeToEvents(Action action)
        {
            base.SubscribeToEvents(action);

            EventManager.Instance.AddListener($"OnAdd_{this.GetHashCode()}", action);
            EventManager.Instance.AddListener($"OnRemove_{this.GetHashCode()}", action);
        }

        /// <summary>Remove the specified method from the listeners</summary>
        /// <param name="action">The method to remove</param>
        public override void UnSubscribeToEvents(Action action)
        {
            base.UnSubscribeToEvents(action);

            EventManager.Instance.RemoveListener($"OnAdd_{this.GetHashCode()}", action);
            EventManager.Instance.RemoveListener($"OnRemove_{this.GetHashCode()}", action);
        }
    }
}