using System.Collections;

using UnityEngine;

namespace SpaceGame
{
    public class ShooterEnemy : Enemy
    {
       
        [SerializeField] private Transform shootPosition;
        [SerializeField] private Bullet bulletPrefab;


        private Weapon shooterWeapon = new Weapon("Shooter", 1f, 5f);

        private LineRenderer lineRenderer;

        //private variables
        private float _setSpeed;
        private bool _isShooting;

        protected override void Start()
        {
            base.Start();
            health = new Health(5f, 0f, 5f);// very low health
            // _setSpeed = speed; //gets speed from playable object
            weapon = shooterWeapon;
            lineRenderer = gameObject.GetComponent<LineRenderer>();
            _target = GameObject.FindGameObjectWithTag("Player").transform;

            SetLine();

        }
        protected override void Update()
        {
            UpdateLine();
            base.Update();
            if (_target == null)

                return;

            if (!_isShooting)
                StartCoroutine(WaitToShoot(1.5f));

        }
        public override void Shoot()
        {
            weapon.Shoot(bulletPrefab, shootPosition, "Player");
        }
        public override void Attack(float interval)
        {
            var damageable = _target.GetComponent<IDamageable>();
            _target.GetComponent<IDamageable>().GetDamage(weapon.GetDamage());
        }

        public override void GetDamage(float damage)
        {
            health.RemoveHealth(damage);//Enemy receive damage
            if (health.GetHealth() <= 0)
                Die();
        }


        //create a line between shooter and player

        IEnumerator WaitToShoot(float delayTime)
        {
            _isShooting = true;
            yield return new WaitForSeconds(delayTime);
           
            Shoot();
    
            _isShooting = false;

        }

        void SetLine()
        {
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

            // Set the color
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.red;

            // Set the width
            lineRenderer.startWidth = 0.05f;
            lineRenderer.endWidth = 0.05f;

            // Set the number of vertices
            lineRenderer.positionCount = 2;

        }

        void UpdateLine()
        {
            // Set the positions of the vertices
            lineRenderer.SetPosition(0, shootPosition.position);
            lineRenderer.SetPosition(1, _target.position);
        }


    }
}
