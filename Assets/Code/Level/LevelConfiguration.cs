using Code.Entities.Ships.Configurations;
using UnityEngine;

namespace Code.Level
{

    [CreateAssetMenu(menuName = "Create Level Configuration", fileName = "Level Configuration", order = 0)]
    public class LevelConfiguration : ScriptableObject
    {

        [SerializeField] SpawnConfiguration[] _spawnConfiguration;

        public SpawnConfiguration[] SpawnConfiguration => _spawnConfiguration;
    }
}