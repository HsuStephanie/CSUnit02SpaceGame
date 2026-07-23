using UnityEngine;

namespace SpaceGame
{
    public class ExploderEnemy : Enemy
    {
        [SerializeField] private float explodeRadius = 5f;
        [SerializeField ]private int explodeDamage;
        [SerializeField] private float timeToExplode = 2f;

        //don't need to call Move() because they exist in the parent Enemy
        // you can type override
        public override void Attack(float interval)
        {
            base.Attack(interval);
            //if distance to target is <= 5f
            //then 
        }



    }
}
