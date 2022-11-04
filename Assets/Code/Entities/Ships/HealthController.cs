using System;
using UnityEngine;
using Code.Entities.Ships.Common;

namespace Code.Entities.Ships
{
    public class HealthController : MonoBehaviour, IDamageable
    {
        private int _health;
        private IShip _ship;
        public TEAMS Team { get; set; }

        public void Configure(IShip shipMediator, int health , TEAMS team)
        {
            _ship = shipMediator;
            _health = health;
            Team = team;
        }


        public void ApplyDamage(int amount)
        {
            _health = Math.Max(0, _health - amount);

            var isDead = _health <= 0;
            _ship.OnDamageReceived(isDead);
        }

    }
}
