using Code.Entities.Ships.Configurations;
using Code.Entities.Ships.Controllers;
using Code.Inputs;
using UnityEngine;
using Code.Entities.Ships.Common;

namespace Code.Entities.Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : MonoBehaviour, IShip
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private HealthController _healthController;
        

        [SerializeField] ShipId _shipConfig;
        private IInputAdapter _input;
        private Vector2 _dir;
        private TEAMS _team;
        private int _score;


        public string Id => _shipConfig.Value;


        public void Configure(ShipConfiguration configuration)
        {
            _input = configuration.Input;
            _movementController.Configure(this, configuration.CheckLimits, configuration.Speed);
            _weaponController.Configure(this, configuration.FireRate, configuration.DefaultProjectileId , configuration.Team);
            _healthController.Configure(this , configuration.Health , configuration.Team);
            _team = configuration.Team;
            _score = configuration.Score;

        }


        private void FixedUpdate()
        {
            _movementController.Move(_dir);
        }
        private void Update()
        {
            _dir = _input.GetDirection();
            TryShoot();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
           var damageable =  collision.GetComponent<IDamageable>();

            if(damageable.Team == _team)
            {
                return;
            }

            damageable.ApplyDamage(1);

            Debug.Log("Nave colisiono con: " + collision.name);
        }

        public void OnDamageReceived(bool isDead)
        {
            if (!isDead)
            {
                return;
            }

            var scoreView = FindObjectOfType<ScoreView>();
            scoreView.AddScore(_team, _score);
            Destroy(gameObject);
        }


        private void TryShoot()
        {
            if (_input.IsFireActionPressed())
            {
                _weaponController.TryShoot();
            }
        }


    }
}
