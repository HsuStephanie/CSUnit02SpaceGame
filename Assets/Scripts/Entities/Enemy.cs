
using UnityEngine;
using System;

namespace SpaceGame
{
    public class Enemy : PlayableObject, IDamageable
    {
        private EnemyType _enemyType;
        protected Transform _target; //this is currently null


        /// <summary>
        /// Find player dynamically
        /// </summary>
        protected virtual void Start() //children of Enemy class will be able to use this version of "Start" method
        {
            //Enemy will try to find the player target. If there's no player target, the enemy will be destroyed
            try
            {
                _target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            catch (NullReferenceException)
            {
                Debug.Log("Enemy could not find target player");
                Destroy(gameObject);
            }

        }
        protected virtual void Update()
        {
            if (_target != null) //checking if player is the target
            {
                //move towards player
                Move(_target.position);
            }
            else
            {
                //move without target
                Move(speed);
            }
        }

        public override void Move(Vector2 direction, Vector2 target)
        {

        }

        /// <summary>
        /// Moves linearly
        /// </summary>
        /// <param name="speed"></param>
        public override void Move(float speed)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
        /// <summary>
        /// Rotating enemy to look at _target, then moving in linear fashion.
        /// </summary>
        /// <param name="direction">Where the enemy is moving to. </param>
        public override void Move(Vector2 direction)
        {
            Vector2 toTarget = (Vector2)_target.position - (Vector2)transform.position;

            if (toTarget != Vector2.zero)
            {
                float angle = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
            }

            transform.position += (Vector3)(toTarget.normalized * speed * Time.deltaTime);


        }

        public override void Attack(float interval)
        {
            Debug.Log("Attacking");
        }

        public override void Shoot()
        {
        }

        public override void GetDamage(float damage)
        {
            health.RemoveHealth(damage);
            if (health.GetHealth() <= 0)
                Die();
        }

        public override void Die()
        {
            Debug.Log("Enemy Died");
            GameManager.getInstance().NotifyDeath(this);//calls the method when this gameObject dies
            Destroy(gameObject);
        }

        //Not from abstract classes
        public virtual void EnemyAttack(float interval, float radius, float damage)
        {
            Debug.Log("Enemy attacking!");
        }
        public void SetEnemyType(EnemyType enemyType)
        {
            this._enemyType = enemyType;
        }
    }

}
