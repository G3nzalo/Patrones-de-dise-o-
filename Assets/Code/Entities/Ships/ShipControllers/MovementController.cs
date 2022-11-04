using Code.Viewport;
using UnityEngine;

namespace Code.Entities.Ships.Controllers
{
    public class MovementController : MonoBehaviour
    {
        private Vector2 _speed;
        private Rigidbody2D _rb;
        private Vector2 _currentPosition;

        private IShip _shipMediator;
        private ICheckLimits _strategyLimits;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _currentPosition = _rb.position;
        }

        public void Configure(IShip shipMediator, ICheckLimits checkLimits, Vector2 speed)
        {
            _shipMediator = shipMediator;
            _strategyLimits = checkLimits;
            _speed = speed;

        }
        public void Move(Vector2 direction)
        {
            _currentPosition += direction * (_speed * Time.fixedDeltaTime);
            _currentPosition = _strategyLimits.ClampFinalPosition(_currentPosition);
            _rb.MovePosition(_currentPosition);
        }

    }
}
