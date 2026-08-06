using UnityEngine;
using System.Collections.Generic;


namespace SpaceGame
{
    public class InventoryManager : MonoBehaviour
    {
        public List<GameObject> inventory = new List<GameObject>();
        public bool hasInventory;
        [SerializeField] int maxInventory = 3;

        [SerializeField] Transform inventoryPanel;
        [SerializeField] GameObject nukeIcon;
        private List<GameObject> nukeIconInstances = new List<GameObject>();

        void Update()
        {
            if (inventory.Count < 1)
            {
                hasInventory = false;
            }
            else
                hasInventory = true;
        }

        public void AddItem(GameObject item)
        {
            inventory.Add(nukeIcon);
            GameObject iconInstance = Instantiate(nukeIcon, inventoryPanel);
            nukeIconInstances.Add(iconInstance);
            Debug.Log("Item added to inventory: " + item.name);



        }

        public void RemoveItem()
        {
            if (inventory.Count > 0)
                inventory.RemoveAt(inventory.Count - 1);

            if (nukeIconInstances.Count > 0)
            {
                int lastIndex = nukeIconInstances.Count - 1;
                GameObject iconToDestroy = nukeIconInstances[lastIndex];
                nukeIconInstances.RemoveAt(lastIndex);
                Destroy(iconToDestroy);
            }
        }


    }
}

