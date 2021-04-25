using System;
using JetBrains.Annotations;
using UnityEngine;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] 
        private GameObject _gameMenu;

        private bool _isOpen;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !_isOpen)
            {
                _gameMenu.SetActive(true);
                _isOpen = true;
            }
        }

        [UsedImplicitly]
        public void Close()
        {
            _isOpen = false;
            _gameMenu.SetActive(false);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}