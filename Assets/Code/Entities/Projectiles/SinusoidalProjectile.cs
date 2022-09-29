using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SinusoidalProjectile : Projectile
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _seconds;
    [SerializeField] private float _amplitude;
    [SerializeField] private float _currentTime;
    [SerializeField] private float _frequency;

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

        //horizontal position = amplitude * sin (x * frequency)
        var horizontalPosition = _mTransform.right  * ( _amplitude * Mathf.Sin(_currentTime * _frequency));
        _rb.MovePosition(_currentPosition + horizontalPosition);
        _currentTime += Time.fixedDeltaTime;

    }

    IEnumerator DeleteBullet(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
