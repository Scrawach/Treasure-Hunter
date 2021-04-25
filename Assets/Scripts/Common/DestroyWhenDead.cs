using System;
using UnityEngine;

namespace Common
{
    [RequireComponent(typeof(Death))]
    public class DestroyWhenDead : MonoBehaviour
    {
        private Death _death;
        
        private void Awake() => 
            _death = GetComponent<Death>();

        private void OnEnable() => 
            _death.Happened.AddListener(OnDeathHappened);

        private void OnDisable() => 
            _death.Happened.RemoveListener(OnDeathHappened);

        private void OnDeathHappened() => 
            Destroy(gameObject);
    }
}