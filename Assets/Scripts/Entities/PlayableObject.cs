using UnityEngine;

namespace SpaceGame
{
    //Abstract classes are a way to structure your project by making a contract to force iherrited objects to implement SOME version of abstract method
    //Abstraction hides details about how things are working. makes code easier to maintain
    //Inherited objects to implement SOME version of the abstract methods
    public abstract class PlayableObject : MonoBehaviour, IDamageable //inherited Interface
    {
        public Health health = new Health();
        public Weapon weapon;
        [SerializeField] protected string nickName;
        [SerializeField] protected float speed = 5f;


        //Virtual keyword allows subclasses to override the method with it's own version if needed

        public virtual void InitVariables(string nickName, float speed)
        {
            this.nickName = nickName; //this referring to the object at the top
            this.speed = speed;
        }
        public virtual void Move(Vector2 direction) { } //not part of abstraction "contract"
        public virtual void Move(float speed) { } //not part of abstraction "contract"
        
        //Abstract classes
        public abstract void Move(Vector2 direction, Vector2 target); //method must be used by inherited scripts

        public abstract void Shoot();
        public abstract void Attack(float interval);
        public abstract void Die();
        public abstract void GetDamage(float damage);
    }
}
