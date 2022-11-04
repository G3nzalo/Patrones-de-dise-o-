using UnityEngine;

namespace Code.Entities.Projectiles
{
    [CreateAssetMenu(menuName = "Factory/Bullet ID Configuration", fileName = "Bullet ID Configuration", order = 0)]
    public class BulletConfiguration : ScriptableObject
    {
        [SerializeField] private string _value;
        [SerializeField] private int _damage;

        public string Value => _value;
        public int Damage => _damage;

    }
}