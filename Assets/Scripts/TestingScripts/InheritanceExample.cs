using UnityEngine;


    /// <summary>
    /// Classes inherit everything from the parent class
    /// All classes we've created so far inherit from MonoBehavior
    /// </summary>
    public class InheritanceExample : MonoBehaviour
    {


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //creating a class within a class.
        public class Animal //parent class. other classes can inherit from it.
        {
            public GameObject legs;
            public float speed;
            public AudioClip audioClip;
            public float scratchDamage;
            public float currentHealth;
            
        }

        public class Cat : Animal //inhert everything from Animal
        {
            void Start()
            {
                speed = 4f;

            }
            void OnAttack(float health, float damage)
            {
                currentHealth -= scratchDamage;
            }



        }

        public class Kitten : Cat //inherit everything from Cat, and subsequently Animal
        {
            void Start()
            {

            }

            void OnAttack()
            {

            }
        }
        public class Bird : Animal
        {

        }

    }

