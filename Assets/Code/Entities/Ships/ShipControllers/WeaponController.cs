using System.Linq;
using Code.Entities.Projectiles;
using Code.Entities.Ships.Common;
using UnityEngine;

namespace Code.Entities.Ships.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] BulletFactoryConfiguration _factoryBuletsConfiguration;
        [SerializeField] Transform _bulletSpawnTransform;


        private float _fireRateInSeconds;
        private float _remainingSecondsToBeAbleToShoot;
        private string _activeProjectileId;

        private BulletFactory _mFactory;

        private IShip _shipMediator;

        private TEAMS _team;
        private void Awake()
        {
            var instanceConfiguration = Instantiate(_factoryBuletsConfiguration);
            _mFactory = new BulletFactory(instanceConfiguration);
        }

        public void Configure(IShip mediator, float fireRate, BulletConfiguration defaultPRojectileID , TEAMS team)
        {
            _shipMediator = mediator;
            _fireRateInSeconds = fireRate;
            _activeProjectileId = defaultPRojectileID.Value;
            _team = team;

        }

        public void TryShoot()
        {
            _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
            if (_remainingSecondsToBeAbleToShoot > 0)
            {
                return;
            }

            Shoot();
        }

        private void Shoot()
        {
            var projectile = _mFactory.Create(_activeProjectileId,
                _bulletSpawnTransform.position,
                _bulletSpawnTransform.rotation, _team);

            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
        }
    }

}