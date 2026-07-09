using UnityEngine;
namespace SpaceGame
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage;


        //Bullet is going to be a trigger.

        void Start()
        {
            Invoke("TimeToDestroy", 5f);
        }
        private void Update()
        {
            Move();
        }

        void TImeToDestroy()
        {
            Destroy(gameObject);
        }
        void Move()
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime); //This could be a single static method and use it in other classes in order to save performance

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
            
            
            IDamageable damageable = collision.GetComponent<IDamageable>();
            Damage(damageable);

        }

        


    }

}
