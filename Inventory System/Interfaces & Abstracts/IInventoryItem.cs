using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ru1t3rl.InventorySystem
{
    public interface IInventoryItem
    {
        string Name { get; }
        Sprite Icon { get; }

        void Use();
    }
}