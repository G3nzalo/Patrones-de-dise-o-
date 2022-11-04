using UnityEngine;

namespace Code.Entities.Ships.Configurations
{
    [CreateAssetMenu(menuName = "Factory/Ship ID Configuration", fileName = "Ship ID Configuration", order = 0)]
    public class ShipId : ScriptableObject
    {
        [SerializeField] private string _value;
        public string Value => _value;
    }
}