using UnityEngine;

namespace SpaceGame
{
    public class ShooterEnemy : Enemy
    {
        [SerializeField] private float attackRange = 0.5f;
        [SerializeField] private float attackTime = 0.1f;

        // private Weapon meleeWeapon = new Weapon("Melee", 1f, 0f);

        private float timer = 0f;
        private float setSpeed = 3f;

        protected override void Start()
        {
            base.Start();
            health = new Health (1f, 0f, 1f);// very low health
            setSpeed = speed; //gets speed from playable object
            // weapon = meleeWeapon;
            
        }
        protected override void Update()
        {
            base.Update();
            if (_target == null)
            {
                return;
            }
            if (Vector2.Distance(transform.position, _target.position) < attackRange)
            {
                speed = 0f;
                Attack(attackTime);
            }
            else
            {
                speed = setSpeed;
            }
        }

        public override void Attack(float interval)
        {
           if (timer <= interval)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0f;
                var damageable = _target.GetComponent<IDamageable>();
                Debug.Log(damageable);

                damageable?.GetDamage(weapon.GetDamage());
                _target.GetComponent<IDamageable>().GetDamage(weapon.GetDamage()); //this should damage the player
            }
        }

        public void SetMeleeEnemy(float _attackRange, float _attackTime)
        {
            attackRange = _attackRange;
            attackTime = _attackTime;
        }



    }
}
