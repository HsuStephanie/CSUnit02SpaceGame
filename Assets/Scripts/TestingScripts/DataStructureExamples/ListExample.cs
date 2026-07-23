using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace SpaceGame
{
    /// <summary>
    /// Lists are similar to arrays but are dynamic and can grow in size at run time. Each index item will "point"/reference to the next space in the memory.
    /// If you destroy a game object, it creates a hole in the memory. Lists can clean up these holes as they go, but costs performance.
    /// 
    /// Lists must be instantiated
    /// 
    /// Lists can have null spaces. If you remove 
    /// </summary>
    public class ListExample : MonoBehaviour
    {
        // public GameObject testObject;
        // public List <GameObject> listGameobjects; //<T> means "generic"
        // public List<GameObject> workingList = new List<GameObject>();


        
        // // Start is called once before the first execution of Update after the MonoBehaviour is created
        // void Start()
        // {
            
        //     GameObject tempObject;
        //     tempObject = Instantiate(testObject);
        //     tempObject.transform.position = new Vector3(0,0,0);
        //     workingList.Add(tempObject); //will add this tempObject to the list after the last index, which is at [0]

        //     tempObject = Instantiate(testObject);
        //     tempObject.transform.position = new Vector3(0,0,0);
        //     workingList.Add(tempObject); //will add this tempObject to the list after the last index. which is at [1]

        //     workingList.RemoveAt(2); //there's nothing at Index 2 right now.
        //     workingList.Clear(); //empty the list 
            
        //     for (int i = 0; i <= workingList.Count; i ++) //this is a dynamic for each loop that will go through all the idexes in your list by counting
        //     {
        //         Debug.Log("do something");
        //     }


        // }

       
    }
}
