using UnityEngine;
using UnityEngine.Events;

namespace Common
{
    public class QuestItem : MonoBehaviour
    {
        public UnityEvent Taken;
        private bool _isActivated = true;

        public void Activate()
        {
            _isActivated = true;
        }

        public void Deactivate()
        {
            _isActivated = false;
        }
        
        public void Take()
        {
            if (_isActivated == false)
                return;
            
            Taken?.Invoke();
        }
    }
}