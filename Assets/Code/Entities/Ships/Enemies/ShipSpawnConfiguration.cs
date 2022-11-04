using Code.Entities.Projectiles;
using Code.Entities.Ships.Configurations;
using UnityEngine;

namespace Code.Entities.Ships.Enemies
{
    [CreateAssetMenu(menuName = "Create Ship To spawn", fileName = "Create Ship To spawn", order = 0)]
    public class ShipSpawnConfiguration : ScriptableObject
    {
        [SerializeField] Vector2 _speed;
        [SerializeField] ShipId _shipId;
        [SerializeField] BulletConfiguration _defaultProjectileId;
        [SerializeField] float _fireRate;
        [SerializeField] int _health;
        [SerializeField] int _score;


        public Vector2 Speed => _speed;
        public ShipId ShipId => _shipId;
        public BulletConfiguration DefaultProjectileId => _defaultProjectileId;
        public float FireRate => _fireRate;
        public int Health => _health;
        public int Score => _score;


    }

}