using UnityEngine;


namespace SpaceGame
{
    public class NukePickup : Pickup, IDamageable
    {
       
        [SerializeField] InventoryManager inventoryManager;
        public GameObject nuke;

        void Start()
        {
            inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        }
        public override void OnPicked()
        {
            
            inventoryManager.AddItem(nuke);
            base.OnPicked();
        }
        public void GetDamage(float damage)
        {
            OnPicked();
        }


    }
}
