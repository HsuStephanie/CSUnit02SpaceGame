using System.Collections;
using UnityEngine;

namespace SpaceGame
{
    public class MachineGunEnemy : Enemy
    {
       [SerializeField] private float attackRange = 10f;
    //    [SerializeField] private float attackTime = 2f;
    //    [SerializeField] private float rotationSpeed = 5f;
       [SerializeField] private Bullet bulletPrefab;
       [SerializeField] private Transform bulletSpawnPoint;
       private Weapon machineGunWeapon = new Weapon("MachineGun", 1f, 5f);

     


        protected override void Start()
        {
            base.Start();
            health = new Health (5f, 0f, 5f);
            weapon = machineGunWeapon;
            
        }

        protected override void Update()
        {
            // base.Update();
            if (_target == null)
            return;



            if (Vector2.Distance(transform.position, _target.position) < attackRange)
            {
                StartCoroutine(WaitToShoot());
            }
        }

        void FixedUpdate()
        {
            LookAtPlayer();
        }

        public override void Shoot()
        {
            
            weapon.Shoot(bulletPrefab, bulletSpawnPoint, _target.tag);
        }

        public override void Attack(float interval)
        {
            var damageable = _target.GetComponent<IDamageable>();
            damageable?.GetDamage(weapon.GetDamage());
            _target.GetComponent<IDamageable>().GetDamage(weapon.GetDamage());
        }
       
        void LookAtPlayer()
        {
            Vector2 lookDirection = _target.transform.position - transform.position;
            float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector2.right);


        }

        IEnumerator WaitToShoot()
        {
            Shoot();
            yield return new WaitForSeconds(2f);
        }

    }
}
