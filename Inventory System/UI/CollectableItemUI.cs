using System.Collections;
using System.Collections.Generic;
using Ru1t3rl.InventorySystem.Behaviours;
using Ru1t3rl.Events;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Ru1t3rl.InventorySystem.UI
{
    [RequireComponent(typeof(CollectionItemBehaviour))]
    public class CollectableItemUI : BaseInventoryItemUI
    {
        [SerializeField] private Color collectedTint = Color.white;
        [SerializeField] private Color notCollectedTint = Color.gray;

        public override void OnCollect()
        {
            icon.color = collectedTint;
        }

        public override void OnDrop()
        {
            icon.color = notCollectedTint;
        }

        public override void UpdateUI()
        {
            if ((inventoryItem as CollectionItemBehaviour).Collected)
            {
                icon.color = collectedTint;
            }
            else
            {
                icon.color = notCollectedTint;
            }
        }
    }
}