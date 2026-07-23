using UnityEngine;

namespace SpaceGame
{
    public class MachineGunEnemy : Enemy
    {
       [SerializeField] private float attackRange = 5f;
       [SerializeField] private float attackTime = 2f;
       [SerializeField] private Bullet bulletPrefab;
       [SerializeField] private Transform bulletSpawnPoint;
       private Weapon machineGunWeapon = new Weapon("MachineGun", 1f, 0f);

     


        protected override void Start()
        {
            base.Start();
            health = new Health (1f, 0f, 1f);
            
        }

        protected override void Update()
        {
            base.Update();
            if (_target == null)
            return;

            if (Vector2.Distance(transform.position, _target.position) < attackRange)
            {
                Shoot();
            }
        }

        public override void Shoot()
        {
            weapon.Shoot(bulletPrefab, bulletSpawnPoint, _target.tag);
        }
        public void SetMachineGunEnemy(float _attackRange, float _attackTime)
        {
            attackRange = _attackRange;
            attackTime = _attackTime;
        }

    }
}
