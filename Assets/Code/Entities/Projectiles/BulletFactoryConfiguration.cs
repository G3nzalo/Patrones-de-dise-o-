using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Entities.Projectiles
{
    [CreateAssetMenu(menuName = "Factory/Bullet FactoryConfig", fileName = "Bullet FactoryConfig", order = 0)]
    public class BulletFactoryConfiguration : ScriptableObject
    {
        [SerializeField] Projectile[] _bulletsPrefabs;

        Dictionary<string, Projectile> _bulletsConfiguration;

        private void Awake()
        {
            _bulletsConfiguration = new Dictionary<string, Projectile>();

            foreach (var item in _bulletsPrefabs)
            {
                _bulletsConfiguration.Add(item.Id, item);
            }
        }
        public Projectile GetBulletId(string id)
        {
            if (_bulletsConfiguration.TryGetValue(id, out var bullet))
            {
                return bullet;
            }

            else throw new Exception($"Projectile {id} not found");
        }

    }
}