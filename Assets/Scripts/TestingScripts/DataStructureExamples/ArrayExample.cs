using UnityEngine;
//no additional using statement

namespace SpaceGame
{
    public class ArrayExample : MonoBehaviour
    {
        public GameObject testObject;
        public GameObject [] testArray; //non initialized and length = 0. it won't cause a crash
        public GameObject[] array = new GameObject[2]; //array start at 0, therefore index will be 0 & 1. Computer initializes the space in the memory as this length. Computer can't allocate new memory while the game is running for Arrays
        //arrays are more performant if you know it will be a constant size but not by much

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            array[0] = Instantiate(testObject, transform);// create a gameobject and store it in the array at index 0
            array[0].transform.position = new Vector2(0,0); //will look for gameobject at array[0]
            

            array[1] = Instantiate(testObject, transform);
            array[1].transform.position = new Vector2(1,0);

            array[2] =Instantiate(testObject, transform); //this will error out. In memory where array[2] would be, there may be something else taking up the slot.
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
