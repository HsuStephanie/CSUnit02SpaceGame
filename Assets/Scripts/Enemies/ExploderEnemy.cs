using UnityEngine;

namespace SpaceGame
{
    public class ExploderEnemy : Enemy
    {
        [SerializeField] private float explodeRadius;
        [SerializeField ]private int explodeDamage;

        //don't need to call Move() because they exist in the parent Enemy
        // you can type override
        public override void EnemyAttack(float interval, float radius, float damage)
        {
            base.EnemyAttack(interval, explodeRadius, explodeDamage);
        }

        

    }
}
