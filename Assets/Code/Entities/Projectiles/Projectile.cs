using System.Collections;
using Code.Entities.Ships.Common;
using UnityEngine;

namespace Code.Entities.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour , IDamageable
    {
        [SerializeField] protected Rigidbody2D _rb;
        [SerializeField] BulletConfiguration _id;

        [SerializeField] private float _seconds;
        public string Id => _id.Value;

        public TEAMS Team { get; set; }

        public void Configure(TEAMS team)
        {
            Team = team;
        }

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
            var damageable = collision.GetComponent<IDamageable>();

            if(damageable.Team == Team)
            {
                return;
            }

            damageable.ApplyDamage(1);

            Debug.Log("Projectile colision:" + collision.name);
        }

        public void ApplyDamage(int amount)
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
}