using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceGame
{
    public class PickUpSpawner : MonoBehaviour
    {
        [SerializeField] private PickUpSpawn[] pickUps; //All of prefab pickups will populate into this array
        [Range(0,1)]
        [SerializeField] private float pickupProbability;
        List<Pickup> pickUpPool = new List<Pickup>(); 
        Pickup chosenPickup; //the pickup that is spawned by the enemy
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //populate a pool of pickups based on prefabs
            foreach(PickUpSpawn spawn in pickUps)
            {
                for (int i = 0; i < spawn.spawnWeight; i ++)
                {
                    pickUpPool.Add(spawn.pickup);
                }
            }
        }
        /// <summary>
        /// Where the pick up will spawn on screen. Pick up is randomly spawned from the pickUpPool list
        /// </summary>
        /// <param name="position"></param>
        public void SpawnPickUp(Vector2 position)
        {
            if (pickUpPool.Count <=0)
            {
                return;
            }
            if (Random.Range(0.0f, 1.0f) < pickupProbability)
            {
                chosenPickup = pickUpPool[Random.Range(0,pickUpPool.Count)];
                Instantiate(chosenPickup, position, Quaternion.identity);
            }
        }
       
    }
    /// <summary>
    /// Outside of the first class, you can add other classes, structs, and enums
    /// </summary>
    [System.Serializable]
    public struct PickUpSpawn
    {
        public Pickup pickup;
        public int spawnWeight; //these pick ups will spawn off of probability
    }

}
