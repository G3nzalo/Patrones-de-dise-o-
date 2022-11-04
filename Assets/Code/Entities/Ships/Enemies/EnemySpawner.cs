using Code.Entities.Ships.Configurations;
using Code.Inputs;
using Code.Level;
using Code.Viewport;
using UnityEngine;
using Code.Entities.Ships.Common;
using System.Collections.Generic;

namespace Code.Entities.Ships.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] Transform[] _spawnTansform;
        [SerializeField] LevelConfiguration _levelConfiguration;

        [SerializeField] FactoryShipConfiguration _shipConfiguration;

        private float _currentTimeInSeconds;
        private int _currentConfigurationIndex;
        private bool _canSpawn = false;
        private ShipFactory _shipFactory;
        private List<ShipMediator> _shipEnemies;

        private void Awake()
        {
            _shipFactory = new ShipFactory(Instantiate(_shipConfiguration));
            _shipEnemies = new List<ShipMediator>();
        }

        private void Update()
        {
            if (!_canSpawn) return;

            if (_currentConfigurationIndex >= _levelConfiguration.SpawnConfiguration.Length)
            {
                return;
            }
            _currentTimeInSeconds += Time.deltaTime;

            var spawnConfiguration = _levelConfiguration.SpawnConfiguration[_currentConfigurationIndex];

            if (spawnConfiguration.TimeToSpawn > _currentTimeInSeconds)
            {
                return;
            }

            SpawnShips(spawnConfiguration);
            _currentConfigurationIndex += 1;
        }

        private void SpawnShips(SpawnConfiguration spawnConfiguration)
        {

            for (int i = 0; i < spawnConfiguration.ShipSpawnConfiguration.Length; i++)
            {
                var shipConfiguration = spawnConfiguration.ShipSpawnConfiguration[i];
                var spawnPositions = _spawnTansform[_currentConfigurationIndex];

               var shipBuilder = _shipFactory.Create(shipConfiguration.ShipId.Value);

                var ship = shipBuilder
                      .WithPosition(spawnPositions.position)
                      .WithRotation(spawnPositions.rotation)
                      .WithInputMode(ShipBuilder.InputMode.Ai)
                      .WithCheckLimitsType(ShipBuilder.CheckLimitsTypes.InitialPosition)
                      .WithConfiguration(shipConfiguration)
                      .WithTeam(TEAMS.ENEMY)
                      .Build();

                _shipEnemies.Add(ship);

            }
        }

        public void Create()
        {
            _canSpawn = true;
        }

        public void QuitGame()
        {
            _canSpawn = false;
            _currentConfigurationIndex = 0;
            _currentTimeInSeconds = 0.0f;

            foreach (var item in _shipEnemies)
            {
                if (item.Equals(null)) continue;
                Destroy(item.gameObject);
            }

            _shipEnemies.Clear();

        }

    }

}