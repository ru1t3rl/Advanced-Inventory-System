using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ru1t3rl.InventorySystem.Behaviours;

namespace Ru1t3rl.InventorySystem.UI
{
    public abstract class BaseInventoryItemUI : MonoBehaviour
    {
        [SerializeField] protected Image icon;
        [SerializeField] protected new TextMeshProUGUI name;

        protected IInventoryItem inventoryItem;

        public virtual void SetItem(IInventoryItem item)
        {
            inventoryItem = item;
            icon.sprite = item.Icon;
            name.text = item.Name;
        }

        public abstract void UpdateUI();
        public abstract void OnCollect();
        public abstract void OnDrop();
    }
}
