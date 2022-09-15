using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class BulletFactory
{
    private FactoryConfiguration _factoryBuletsConfiguration;

    public BulletFactory(FactoryConfiguration factoryBuletsConfiguration)
    {
        _factoryBuletsConfiguration = factoryBuletsConfiguration;
    }

    public void Create(string id , Vector3 position , Quaternion rotation )
    {
        var bulletPrefab = _factoryBuletsConfiguration.GetBulletId(id);
        Object.Instantiate(bulletPrefab, position, rotation);
    }
}

