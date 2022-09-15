using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] BulletConfiguration _id;

    [SerializeField] Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _seconds;

    public string Id => _id.Value;

    private void SetForce() => _rb.velocity = transform.up * _speed;

    private void Start()
    {
        SetForce();
        StartCoroutine(DeleteBullet(_seconds));
    }

    IEnumerator DeleteBullet(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
