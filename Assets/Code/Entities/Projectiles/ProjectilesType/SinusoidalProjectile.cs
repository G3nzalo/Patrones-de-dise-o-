using System.Collections;
using UnityEngine;

namespace Code.Entities.Projectiles.Type
{
    public class SinusoidalProjectile : Projectile
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _amplitude;
        [SerializeField] private float _frequency;

        [SerializeField] private float _currentTime;
        private Vector3 _currentPosition;

        protected override void DoStart()
        {
            _currentTime = 0f;
            _currentPosition = _mTransform.position;
        }

        protected override void DoMove()
        {
            _currentPosition += _mTransform.up * (_speed * Time.fixedDeltaTime);

            //horizontal position = amplitude * sin (x * frequency)
            var horizontalPosition = _mTransform.right * (_amplitude * Mathf.Sin(_currentTime * _frequency));
            _rb.MovePosition(_currentPosition + horizontalPosition);
            _currentTime += Time.fixedDeltaTime;
        }

        protected override void DoDestroy()
        {
        }
    }
}