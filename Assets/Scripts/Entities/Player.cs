using UnityEngine;

namespace SpaceGame
{
    public class Player : PlayableObject //relationship

    {
        [SerializeField] private Camera cam;
      

        private Rigidbody2D _playerRB;
        public Health health = new Health(); //calling the health class. Creates an instance of Health. Accesses player's version of Health class
                                             //Health() creates currentHealth, maxHealth, and regenRate, and gives access to AddHealth() and RemoveHealth()

        public Weapon weapon;
        //*public Weapon; <-- needs to be created*

        private void Start()
        {

            health = new Health(100, 0.5f);
            _playerRB = GetComponent<Rigidbody2D>();

        }

        //Player specific methods



        public void PlayerDeath()
        {
            Debug.Log("You're dead");
        }

        public override void Move(Vector2 direction, Vector2 target)
        {
            _playerRB.linearVelocity = direction * speed;
            Vector3 playerScreenPos = cam.WorldToScreenPoint(transform.position);
            target.x -= playerScreenPos.x;
            target.y -= playerScreenPos.y;
            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0,0, (angle -90f));
        }
        public override void Attack(float interval)
        {
        }
        public override void Die()
        {
        }
        public override void GetDamage(float damage)
        {
        }

        public override void Shoot(Vector3 direction, float speed)
        {
        }

    }


}
