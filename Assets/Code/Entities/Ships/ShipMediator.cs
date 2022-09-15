using System;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(WeaponController))]
public class ShipMediator : MonoBehaviour , IShip
{

    [SerializeField] MovementController _movementController;
    [SerializeField] WeaponController _weaponController;

    private InputAdapter _input;

    public void Configure(InputAdapter adapter, ICheckLimits strategySimits)
    {
        _input = adapter;
        _movementController.Configure(this, strategySimits);
        _weaponController.Configure(this);
    }


    private void Update()
    {
        var dir = _input.GetDirection();
        _movementController.Move(dir);
        TryShoot();
    }

    private void TryShoot()
    {
        if(_input.IsFireActionPressed())
        {
            _weaponController.TryShoot();
        }
    }

}
