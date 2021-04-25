using System;
using System.Collections.Generic;
using System.Linq;
using CameraLogic;
using Common;
using UnityEngine;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private int _capacity = 6;

        [SerializeField] 
        private ChestAnimator _animator;

        public event Action<GameObject> Changed;
        public event Action ElementTaken;

        private Stack<BonusType> _bonusStack;

        private bool _isOpenNow;
        private CameraFollow _cameraFollow;

        private void Awake()
        {
            _bonusStack = new Stack<BonusType>(_capacity);
            _cameraFollow = Camera.main.GetComponent<CameraFollow>();
        }
        
        public void Toggle()
        {
            if (_isOpenNow)
                Hide();
            else
                Open();
        }

        public void Open()
        {
            if (_isOpenNow)
                return;
            
            _animator.PlayShowInventory();
            _cameraFollow.ZoomIn();
            _isOpenNow = true;
        }

        public void Hide()
        {
            if (_isOpenNow == false)
                return;
            
            _animator.PlayHideInventory();
            _cameraFollow.ResetZoom();
            _isOpenNow = false;
        }

        public void AddItem(BonusData item)
        {
            if (_bonusStack.Count >= _capacity)
                _bonusStack.Pop();
            
            _bonusStack.Push(item.Type);
            Changed?.Invoke(item.ItemPrefab);
        }

        public bool TryUseItem(out BonusType type)
        {
            type = BonusType.LightSkull;

            if (_bonusStack.Count <= 0) 
                return false;
            
            ElementTaken?.Invoke();
            type = _bonusStack.Pop();
            return true;
        }
        
    }
}