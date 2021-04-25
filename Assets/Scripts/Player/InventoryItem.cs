using System;
using Common;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class InventoryItem
    {
        public BonusType Type;
        public GameObject Prefab;
    }
}