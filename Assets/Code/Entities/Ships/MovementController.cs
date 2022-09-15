using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] float _speed;
    private Transform _myTransform;

    private IShip _shipMediator;
    private ICheckLimits _strategyLimits;

    public void Configure(IShip shipMediator, ICheckLimits checkLimits)
    {
        _shipMediator = shipMediator;
        _strategyLimits = checkLimits;

    }
    private void Awake()
    {
        _myTransform = transform;
    }

    public void Move(Vector2 direction)
    {
        _myTransform.Translate(direction * (_speed * Time.deltaTime));
        _strategyLimits.ClampFinalPosition();
    }

}
