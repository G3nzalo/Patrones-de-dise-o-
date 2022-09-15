using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Factory/EnemyFactoryConfig", fileName = "EnemyFactoryConfig", order = 0)]
public class FactoryConfiguration : ScriptableObject
{
    [SerializeField] Bullet[] _bulletsPrefabs;

    Dictionary<string, Bullet> _bulletsConfiguration;

    private void Awake()
    {
        _bulletsConfiguration = new Dictionary<string, Bullet>();

        foreach (var item in _bulletsPrefabs)
        {
            _bulletsConfiguration.Add(item.Id, item);
        }
    }
    public Bullet GetBulletId(string id)
    {
        if (_bulletsConfiguration.TryGetValue(id, out var bullet))
        {
            return bullet;
        }

        else throw new Exception($"Projectile {id} not found");
    }

}