using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Entities.Ships.Configurations
{
    [CreateAssetMenu(menuName = "Factory/Ship FactoryConfig", fileName = "Ship FactoryConfig", order = 0)]
    public class FactoryShipConfiguration : ScriptableObject
    {
        [SerializeField] ShipMediator[] _shipsPrefabs;

        Dictionary<string, ShipMediator> _shipConfiguration;

        private void Awake()
        {
            _shipConfiguration = new Dictionary<string, ShipMediator>();

            foreach (var item in _shipsPrefabs)
            {
                _shipConfiguration.Add(item.Id, item);
            }
        }
        public ShipMediator GetShipId(string id)
        {
            if (_shipConfiguration.TryGetValue(id, out var ship))
            {
                return ship;
            }

            else throw new Exception($"Projectile {id} not found");
        }

    }
}