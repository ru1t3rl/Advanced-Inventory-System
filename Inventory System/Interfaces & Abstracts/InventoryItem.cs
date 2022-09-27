using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Ru1t3rl.Events;

namespace Ru1t3rl.InventorySystem
{
    public class InventoryItem : MonoBehaviour, IInventoryItem
    {
        public UnityEvent onUse, onDestroy;

        [SerializeField] private Sprite icon;
        public Sprite Icon => icon;

        [SerializeField] private new string name;
        public string Name => name;

        protected virtual void Awake()
        {
            EventManager.Instance.AddEvent($"OnUse_{this.GetHashCode()}", onUse);
            EventManager.Instance.AddEvent($"OnDestroy_{this.GetHashCode()}", onDestroy);
        }

        public virtual void Use()
        {
        }

        /// <summary>Destroy this item</summary>
        public virtual void Destroy()
        {
            EventManager.Instance.Invoke($"OnDestroy_{this.GetHashCode()}");

            EventManager.Instance.RemoveEvent($"OnUse_{this.GetHashCode()}");
            EventManager.Instance.RemoveEvent($"OnDestroy_{this.GetHashCode()}");

            Destroy(gameObject);
        }

        /// <summary>Add the specified method to the listeners</summary>
        /// <param name="action">The method to add</param>
        public virtual void SubscribeToEvents(System.Action action)
        {
            EventManager.Instance.AddListener($"OnUse_{this.GetHashCode()}", action);
            EventManager.Instance.AddListener($"OnDestroy_{this.GetHashCode()}", action);
        }

        /// <summary>Remove the specified method from the listeners</summary>
        /// <param name="action">The method to remove</param>
        public virtual void UnSubscribeToEvents(System.Action action)
        {
            EventManager.Instance.RemoveListener($"OnUse_{this.GetHashCode()}", action);
            EventManager.Instance.RemoveListener($"OnDestroy_{this.GetHashCode()}", action);
        }
    }
}