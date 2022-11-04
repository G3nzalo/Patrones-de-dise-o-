using System.Collections;
using UnityEngine;

namespace Code.Entities.Projectiles.Type
{
    public class CurveAnimationProjectile : Projectile
    {
        [SerializeField] private float _speed;
        [SerializeField] private AnimationCurve _horizontalPosition;

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
            var horizontalPosition = _mTransform.right * (_horizontalPosition.Evaluate(_currentTime));

            _rb.MovePosition(_currentPosition + horizontalPosition);
            _currentTime += Time.fixedDeltaTime;
        }

        protected override void DoDestroy()
        {
        }
    }
}