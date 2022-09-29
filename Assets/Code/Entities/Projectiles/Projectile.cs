using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] BulletConfiguration _id;
    public string Id => _id.Value;
}