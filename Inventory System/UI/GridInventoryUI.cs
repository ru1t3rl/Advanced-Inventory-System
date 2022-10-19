using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ru1t3rl.InventorySystem.UI
{
    public class GridInventoryUI : BaseInventoryUI
    {
        [SerializeField] private Transform inventoryItemsParent;
        private List<BaseInventoryItemUI> inventoryItemUIs = new List<BaseInventoryItemUI>();

        public override void UpdateUI()
        {
            for (int i = 0; i < inventoryItemUIs.Count; i++)
            {
                inventoryItemUIs[i].UpdateUI();
            }
        }

        public override void Show(Inventory inventory)
        {
            gameObject.SetActive(true);

            Clean(inventory);

            this.inventory = inventory;

            for (int iItem = 0; iItem < inventory.Items.Count; iItem++)
            {
                IInventoryItem item = inventory.Items[iItem];
                inventoryItemUIs.Add(Instantiate(inventoryUIItemPrefab, inventoryItemsParent).GetComponent<BaseInventoryItemUI>());
                inventoryItemUIs[iItem].SetItem(inventoryItemUIs[iItem].GetComponent<InventoryItem>());
            }

            for (int iItem = inventoryItemsParent.childCount; iItem-- > inventoryItemUIs.Count;)
            {
                Destroy(inventoryItemsParent.GetChild(iItem).gameObject);
            }
        }

        private void Clean(Inventory inventory)
        {
            if (this.inventory.GetHashCode() != inventory.GetHashCode())
            {
                for (int iItem = inventoryItemsParent.childCount; iItem-- > 0;)
                {
                    Destroy(inventoryItemsParent.GetChild(iItem).gameObject);
                }
            }
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}