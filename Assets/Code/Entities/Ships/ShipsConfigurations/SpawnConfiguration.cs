using System;
using Code.Entities.Ships.Enemies;
using UnityEngine;

namespace Code.Entities.Ships.Configurations
{
    [Serializable]
    public class SpawnConfiguration
    {
        [SerializeField] ShipSpawnConfiguration[] _shipSpawnConfiguration;
        [SerializeField] float _timeToSpawn;

        public ShipSpawnConfiguration[] ShipSpawnConfiguration => _shipSpawnConfiguration;
        public float TimeToSpawn => _timeToSpawn;
    }
}
