using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace SpaceGame
{
    /// <summary>
    /// Data structure is like stack of plates. When items are added, they are added on top.
    /// When you take a plate off, you take it from the top of the stack as well.
    /// To get to the "bottom plate" you have to pop the stack.
    /// 
    /// must be initialized
    /// </summary>
    public class StackExample : MonoBehaviour
    {
        public GameObject testObject;
        public Stack<GameObject> stack = new Stack<GameObject>();
        

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            GameObject tempObject = Instantiate(testObject);
            tempObject.transform.position = new Vector3 (0,0,0);

            stack.Push(tempObject); //Adding the item to the top

            GameObject peekObject = stack.Peek(); //this will not REMOVE the item, but let us look at the "top" of the stack
            stack.Pop(); //removes item from the index. Other indexes are moved up.
            //Pop removes at index [0]. what was index [1] becomes index[0]

        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
