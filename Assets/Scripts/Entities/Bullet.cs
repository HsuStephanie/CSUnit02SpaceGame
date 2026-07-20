using UnityEngine;
namespace SpaceGame
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage;

        private string targetTag = "Enemy";

        //Bullet is going to be a trigger.

        void Start()
        {
            SetBullet(damage, "Enemy", speed);
            Invoke("TimeToDestroy", 5f);
            
        }
        private void Update()
        {
            Move();
        }

        void TimeToDestroy()
        {
            Destroy(gameObject);
        }
        void Move()
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime); //This could be a single static method and use it in other classes in order to save performance
    
        }

        public void SetBullet(float _damage, string _targetTag, float _speed = 10f)
        {
            this.damage = _damage;
            this.speed = _speed;
            this.targetTag = _targetTag = string.Empty;
        }

        void Damage(IDamageable damageable)
        {
            if (damageable != null)//null check for Idamageable
            {
                Debug.Log("Damaged object");
                damageable.GetDamage(damage);
                Destroy(gameObject); //destroy bullet
            }
            else
            {
                //do nothing :P
            }

            
        }
        void OnTriggerEnter2D(Collider2D collision) //Bullet or object will need a rigidbody. We put it on the bullet
        {
            Debug.Log(collision.gameObject.name);
            
            if(!collision.gameObject.CompareTag(targetTag))
            return;

            IDamageable damageable = collision.GetComponent<IDamageable>();
            Damage(damageable);

        }
    }

}
