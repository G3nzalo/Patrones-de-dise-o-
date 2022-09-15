using System.Linq;
using UnityEngine;

public class WeaponController :MonoBehaviour
{
    [SerializeField] BulletConfiguration _bullet1IdConfiguration;
    [SerializeField] BulletConfiguration _bullet2IdConfiguration;
    [SerializeField] FactoryConfiguration _factoryBuletsConfiguration;
    [SerializeField] Transform _bulletSpawnTransform;


    [SerializeField] private float _fireRateInSeconds;
    private float _remainingSecondsToBeAbleToShoot;

    private BulletFactory _mFactory;

    private IShip _shipMediator;

    private void Awake()
    {
        var instanceConfiguration = Instantiate(_factoryBuletsConfiguration);
        _mFactory = new BulletFactory(instanceConfiguration);
    }

    public void Configure(IShip mediator)
    {
        _shipMediator = mediator;
    }

    public void TryShoot()
    {
        _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
        if (_remainingSecondsToBeAbleToShoot > 0)
        {
            return;
        }

        Shoot();
    }

    private void Shoot()
    {
        _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;

        if (Input.GetKey(KeyCode.R))
        {
            _mFactory.Create(_bullet1IdConfiguration.Value , _bulletSpawnTransform.position, _bulletSpawnTransform.rotation);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            _mFactory.Create(_bullet2IdConfiguration.Value, _bulletSpawnTransform.position, _bulletSpawnTransform.rotation);
        }
    }
}

