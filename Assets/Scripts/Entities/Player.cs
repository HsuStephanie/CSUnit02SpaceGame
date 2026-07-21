using UnityEngine;
using System;

namespace SpaceGame
{

    [DefaultExecutionOrder(-10)]
    public class Player : PlayableObject, IDamageable //PlayableObject is a Monobehavior, therefore Player will inhert from that too

    {

        [SerializeField] private Camera cam;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private string targetTag = "Enemy";

        [Header("Weapon stats")]
        [SerializeField] private float weaponDamage = 1f;
        
        [Header("Bullet stats")]
        [SerializeField] private float bulletSpeed = 10f;
        

        public Action OnDealth;

        private Rigidbody2D _playerRB;
        // public Health health = new Health(); //calling the health class. Creates an instance of Health. Accesses player's version of Health class
        //Health() creates currentHealth, maxHealth, and regenRate, and gives access to AddHealth() and RemoveHealth()
        
        [SerializeField] private UIManager uIManager;

        private void Start()
        {
         
            health = new Health(100, 0.5f);
            _playerRB = GetComponent<Rigidbody2D>();
            this.nickName = "Bob";
            this.speed = 2f;
            weapon = new Weapon("Player Weapon", weaponDamage, bulletSpeed); 


        }
        

        //Player specific methods
        //Overrides come from Playable Object class
        public override void Move(Vector2 direction, Vector2 target)
        {
            _playerRB.linearVelocity = direction * speed;
            Vector3 playerScreenPos = cam.WorldToScreenPoint(transform.position);
            target.x -= playerScreenPos.x;
            target.y -= playerScreenPos.y;
            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, (angle - 90f));
        }

        public override void Shoot()
        {
            weapon.Shoot(bulletPrefab, bulletSpawnPoint, targetTag);
        }
        public override void Attack(float interval)
        {
            //This is here bc the enmy needs to attack and abstract method is a contract. This will do nothing for the player, but prevent "red" errors
        }
        public override void Die()
        {
            //C# action
            OnDealth?.Invoke(); //when player dies, will call the Gameover condition
            //

            Destroy(gameObject);
            Debug.Log("You died!");
        }
        public override void GetDamage(float damage)
        {
            health.RemoveHealth(damage);//Player is receiving damage
           if (health.GetHealth() <=0)
            Die();
        }





    }


}
