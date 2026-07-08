using Unity.Mathematics;
using UnityEngine;

namespace SpaceGame
{
    public class Enemy : PlayableObject
    {
        private EnemyType _enemyType;
        private Transform _target; //this is currently null


        /// <summary>
        /// Find player dynamically
        /// </summary>
        protected virtual void Start() //children of Enemy class will be able to use this version of "Start" method
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;
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
            direction.x -= transform.position.x;
            direction.y -= transform.position.y;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //rotating enemy to look at player, then translating line
            transform.rotation = quaternion.Euler(0,0,(angle -90f));
            Move(speed);

        }

        public override void Attack(float interval)
        {
            Debug.Log("Attacking");
        }
        public override void Shoot(Vector3 direction, float speed)
        {
        }

        public override void GetDamage(float damage)
        {
        }

        public override void Die()
        {
            Debug.Log("Enemy Died");
            Destroy(gameObject);
        }

        public void SetEnemyType(EnemyType enemyType)
        {
            this._enemyType = enemyType;
        }
    }

}
