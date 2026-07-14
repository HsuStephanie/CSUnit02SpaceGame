using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    /// <summary>
    /// Queue and Stack are like inverses of each other
    /// Queue is an ordered sequence.
    /// Like a line at the store. You add to the "back of the line", and pull from the "front"
    /// 
    /// must be initialized
    /// </summary>
    public class QueueExample : MonoBehaviour
    {
        public GameObject testObject;
        public Queue<GameObject> myQueue = new Queue<GameObject>();

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            myQueue.Enqueue(testObject); //adding to the queue at end of the line
            myQueue.Dequeue(); //removing the first item in line

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
