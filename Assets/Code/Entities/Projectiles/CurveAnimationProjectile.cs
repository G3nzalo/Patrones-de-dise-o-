using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CurveAnimationProjectile : Projectile
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private AnimationCurve _horizontalPosition;
    [SerializeField] private float _seconds;
    [SerializeField] private float _currentTime;

    private Transform _mTransform;
    private Vector3 _currentPosition;

    private void Start()
    {
        _currentTime = 0f;
        _mTransform = transform;
        _currentPosition = _mTransform.position;

        StartCoroutine(DeleteBullet(_seconds));
    }


    private void FixedUpdate()
    {
        _currentPosition += _mTransform.up * (_speed * Time.fixedDeltaTime);

        var horizontalPosition = _mTransform.right*(_horizontalPosition.Evaluate(_currentTime));

        _rb.MovePosition(_currentPosition + horizontalPosition);
        _currentTime += Time.fixedDeltaTime;

    }

    IEnumerator DeleteBullet(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}