using UnityEngine;

[CreateAssetMenu(menuName = "Factory/Enemy ID Configuration", fileName = "Enemy ID Configuration", order = 0)]
public class BulletConfiguration : ScriptableObject
{
    [SerializeField] private string _value;
    public string Value => _value;
}