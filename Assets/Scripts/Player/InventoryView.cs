using System;
using System.Collections.Generic;
using Common;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Inventory))]
    public class InventoryView : MonoBehaviour
    {
        [SerializeField]
        private Inventory _inventory;

        [SerializeField] 
        private Transform[] _slots;

        [SerializeField] 
        private InventoryItem[] _items;
        
        private int _availableSlot;
        private List<GameObject> _viewObjects;

        [SerializeField]
        private GameObject[] _itemViews;

        private void Awake()
        {
            _viewObjects = new List<GameObject>(_slots.Length);
            _itemViews = new GameObject[6] {null, null, null, null, null, null};
        }

        private void OnEnable()
        {
            _inventory.Changed += OnInventoryChanged;
            _inventory.ElementTaken += OnElementTaken;
        }
        
        private void OnDisable()
        {
            _inventory.Changed -= OnInventoryChanged;
            _inventory.ElementTaken -= OnElementTaken;
        }

        private void OnInventoryChanged(GameObject data)
        {
            if (_itemViews[_itemViews.Length - 1] != null)
                Delete(_itemViews.Length - 1);
            
            for (var i =  _itemViews.Length - 1; i > 0; i--)
            {
                var obj = _itemViews[i - 1];
                _itemViews[i] = obj;
                
                if (obj == null)
                    continue;
                
                obj.transform.SetParent(_slots[i]);
                obj.transform.localPosition = Vector3.zero;
            }

            _itemViews[0] =  Instantiate(data, _slots[0]);
        }
        
        private void OnElementTaken()
        {
            ReplaceElements();
        }

        private void Delete(int index)
        {
            var obj = _itemViews[index];
            _itemViews[index] = null;
            Destroy(obj);
        }

        private void ReplaceElements()
        {
            if (_itemViews[0] != null)
                Delete(0);
            
            for (var i =  0; i < _itemViews.Length - 1; i++)
            {
                var obj = _itemViews[i + 1];
                _itemViews[i] = obj;
                
                if (obj == null)
                    break;
                
                obj.transform.SetParent(_slots[i]);
                obj.transform.localPosition = Vector3.zero;
            }
        }
    }
}