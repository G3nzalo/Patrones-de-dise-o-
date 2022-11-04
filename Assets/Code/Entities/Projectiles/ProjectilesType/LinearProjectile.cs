using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Entities.Projectiles.Type
{
    public class LinearProjectile : Projectile
    {
        [SerializeField] private float _speed;

        protected override void DoStart()
        {
            SetForce();
        }

        protected override void DoMove()
        {

        }

        protected override void DoDestroy()
        {
        }


        private void SetForce() => _rb.velocity = transform.up * _speed;


    }
}