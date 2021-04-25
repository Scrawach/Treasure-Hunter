using JetBrains.Annotations;
using UnityEngine;

namespace Environment
{
    public class Door : MonoBehaviour
    {
        [SerializeField] 
        private GameObject _wall;

        [SerializeField] 
        private DoorAnimator _animator;

        public void Open() => 
            _animator.PlayOpen();

        public void Close() => 
            _animator.PlayClose();

        [UsedImplicitly]
        public void OnOpen()
        {
            _wall.SetActive(false);
        }

        [UsedImplicitly]
        public void OnClose()
        {
            _wall.SetActive(true);
        }
    }
}