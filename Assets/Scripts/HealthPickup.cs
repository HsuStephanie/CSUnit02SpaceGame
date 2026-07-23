using UnityEngine;

namespace SpaceGame
{
    public class HealthPickup : Pickup, IDamageable
    {
        [SerializeField] private float healthMin = 5f;
        [SerializeField] private float healthMax = 20f;
        
        public override void OnPicked()
        {
            base.OnPicked();
            float health = Random.Range(healthMax, healthMax);
            Player player = GameManager.getInstance().GetPlayer();
            player.health.AddHealth(health);
        }
        
        public void GetDamage(float damage)
        {
            OnPicked();
        }
    }

}
