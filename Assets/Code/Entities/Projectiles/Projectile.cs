using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] BulletConfiguration _id;
    [SerializeField] private float _seconds;
    public string Id => _id.Value;
    protected Transform _mTransform;

    private void Start()
    {
        _mTransform = transform;
        DoStart();
        StartCoroutine(DestroyIn());
    }
    protected abstract void DoStart();


    private void FixedUpdate()
    {
        DoMove();
    }

    protected abstract void DoMove();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyProjectile();
    }

    IEnumerator DestroyIn()
    {
        yield return new WaitForSeconds(_seconds);
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        DoDestroy();
        Destroy(gameObject);
    }

    protected abstract void DoDestroy();

}