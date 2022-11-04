using Code.Entities.Ships.Common;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Code.Entities.Projectiles
{
    public class BulletFactory
    {
        private BulletFactoryConfiguration _BulletfactoryBuletsConfiguration;

        public BulletFactory(BulletFactoryConfiguration factoryBuletsConfiguration)
        {
            _BulletfactoryBuletsConfiguration = factoryBuletsConfiguration;
        }

        public Projectile Create(string id, Vector3 position, Quaternion rotation, TEAMS team)
        {
            var bulletPrefab = _BulletfactoryBuletsConfiguration.GetBulletId(id);
            var projectile = Object.Instantiate(bulletPrefab, position, rotation);
            projectile.Configure(team);
            return projectile;
        }
    }

}