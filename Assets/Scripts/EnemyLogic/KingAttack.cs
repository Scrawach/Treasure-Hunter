using Bullets;
using JetBrains.Annotations;
using UnityEngine;

namespace EnemyLogic
{
    public class KingAttack : EnemyAttack
    {
        [SerializeField] 
        private int _bulletCount;

        private float _offset;
        
        [UsedImplicitly]
        protected override void OnAttack()
        {
            var angleStep = 360f / (_bulletCount);

            for (var i = 0; i < _bulletCount; i++)
            {
                _offset = Random.Range(-25, 25);
                var skullBullet =  Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
                skullBullet.transform.rotation = Quaternion.Euler(new Vector3(0, angleStep * i + _offset, 0));
            }

        }
    }
}