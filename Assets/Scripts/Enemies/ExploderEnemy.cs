using System.Collections;
using UnityEngine;

namespace SpaceGame
{
    public class ExploderEnemy : Enemy
    {
        [SerializeField] private float explodeRadius = 5f;
        [SerializeField] private int explodeDamage;
        [SerializeField] private float timeToExplode = 10f;

        [SerializeField] private GameObject explosionBlast;

        //don't need to call Move() because they exist in the parent Enemy
        // you can type override

        protected override void Start()
        {
            base.Start();
            health = new Health(1f, 0f, 5f);

            StartCoroutine(Explode(timeToExplode));

        }

        protected override void Update()
        {
            base.Update();
            if (_target == null)
            return;

        }

        IEnumerator Explode(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            Vector2 lastPosition = gameObject.transform.position;
            Instantiate(explosionBlast, lastPosition, Quaternion.identity);
            DoExplosionDamage();
            Destroy(gameObject);

        }

        private void DoExplosionDamage()
        {

            Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, explodeRadius);
            var damageable = hitCollider.GetComponent<IDamageable>();
            damageable?.GetDamage(explodeDamage);


        }

    }
}
