using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] 
        private Transform _firePoint;

        [SerializeField] 
        private Inventory _inventory;

        [SerializeField] 
        private AudioSource _shootEffect;
        
        [SerializeField] 
        private List<BulletData> _bullets;

        private Dictionary<BonusType, GameObject> _bulletsDictionary;
        
        private void Awake()
        {
            _bulletsDictionary = _bullets
                .ToDictionary(x => x.Type, x => x.BulletPrefab);
        }

        public void TryFire()
        {
            if (_inventory.TryUseItem(out BonusType type))
            {
                Fire(type);
            }
        }
        
        public void Fire(BonusType bulletType)
        {
            Instantiate(_shootEffect, _firePoint.position, transform.rotation);
            Instantiate(_bulletsDictionary[bulletType], _firePoint.position, transform.rotation);
        }
    }
}