using Code.Entities.Projectiles;
using Code.Inputs;
using Code.Viewport;
using UnityEngine;

namespace Code.Entities.Ships.Common
{

    public class ShipConfiguration
    {
        public readonly IInputAdapter Input;
        public readonly ICheckLimits CheckLimits;
        public readonly Vector2 Speed;
        public readonly int Health;
        public readonly float FireRate;
        public readonly BulletConfiguration DefaultProjectileId;
        public readonly TEAMS Team;
        public readonly int Score;

        public ShipConfiguration(
            IInputAdapter input, ICheckLimits checkLimits,
            Vector2 speed,int health, float fireRate, BulletConfiguration defaultProjectileId , TEAMS team , int score)
        {

            Input = input;
            CheckLimits = checkLimits;
            Speed = speed;
            Health = health;
            FireRate = fireRate;
            DefaultProjectileId = defaultProjectileId;
            Team = team;
            Score = score;
        }
    }
}