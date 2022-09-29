using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LinearProjectile : Projectile
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _seconds;


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
