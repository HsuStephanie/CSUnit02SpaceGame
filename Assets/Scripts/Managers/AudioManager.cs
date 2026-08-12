using UnityEngine;

namespace SpaceGame
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] AudioClip enemyShootClip;
        [SerializeField]  AudioClip exploderEnemy;
        [SerializeField] AudioClip exploderEnemyCountDown;
        [SerializeField] AudioClip playerShootClip;
        
        [SerializeField] AudioClip playerDieClip;
        [SerializeField] AudioClip enemyDieClip;

        [SerializeField] AudioSource audioSource;


        public void PlayerShooting()
        {
            audioSource.PlayOneShot(playerShootClip);
        }

        public void PlayerDying()
        {
             audioSource.PlayOneShot(playerDieClip);
        }
          public void ExploderEnemyDying()
        {
             audioSource.PlayOneShot(exploderEnemy);
        }
        public void ExploderEnemyCountDown()
        {
             audioSource.PlayOneShot(exploderEnemyCountDown);
        }
        

          public void EnemyShooting()
        {
             audioSource.PlayOneShot(enemyShootClip);
        }
        public void EnemyDying()
        {
            audioSource.PlayOneShot(enemyDieClip);
        }

    }
}
