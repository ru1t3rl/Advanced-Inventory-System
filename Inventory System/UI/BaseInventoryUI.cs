using UnityEngine;

namespace Ru1t3rl.InventorySystem.UI
{
    public abstract class BaseInventoryUI : MonoBehaviour
    {
        [SerializeField] protected GameObject inventoryUIItemPrefab;

        protected Inventory inventory;

        public abstract void UpdateUI();
        public abstract void Show(Inventory inventory);
        public abstract void Hide();
    }
}