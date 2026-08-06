using System.Collections;
using UnityEngine;

namespace SpaceGame
{
    public class MachineGunEnemy : Enemy
    {
        [SerializeField] private float attackRange = 8f;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform bulletSpawnPoint;
        private Weapon machineGunWeapon = new Weapon("MachineGun", 1f, 5f);

        private bool _isShooting;




        protected override void Start()
        {
            base.Start();
            health = new Health(5f, 0f, 5f);
            weapon = machineGunWeapon;

        }

        protected override void Update()
        {
            // base.Update();
            if (_target == null)
                return;


            if (!_isShooting && Vector2.Distance(transform.position, _target.position) < attackRange)
            {
                StartCoroutine(WaitToShoot());
            }
        }



        public override void Shoot()
        {

            weapon.Shoot(bulletPrefab, bulletSpawnPoint, _target.tag);
        }

        public override void Attack(float interval)
        {
            var damageable = _target.GetComponent<IDamageable>();
            _target.GetComponent<IDamageable>().GetDamage(weapon.GetDamage());
        }

        IEnumerator WaitToShoot()
        {
            _isShooting = true;
            Shoot();
            yield return new WaitForSeconds(0.5f);
            _isShooting = false;
        }

        public override void GetDamage(float damage)
        {
            health.RemoveHealth(damage);//Enemy receive damage
            if (health.GetHealth() <= 0)
                Die();
        }

    }
}
