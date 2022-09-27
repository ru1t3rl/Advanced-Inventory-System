using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ru1t3rl.InventorySystem.Behaviours;

namespace Ru1t3rl.InventorySystem.UI
{
    [RequireComponent(typeof(IStackable))]
    public class StackableItemUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Image icon;

        private StackableItemBehaviour stackable;

        private void Awake()
        {
            stackable = GetComponent<StackableItemBehaviour>();
        }

        private void OnEnable()
        {
            stackable?.SubscribeToEvents(UpdateUI);
        }

        private void OnDisable()
        {
            stackable?.UnSubscribeToEvents(UpdateUI);
        }

        private void UpdateUI()
        {
            icon.sprite = stackable.Icon;
            text.text = stackable.Count.ToString();
        }
    }
}