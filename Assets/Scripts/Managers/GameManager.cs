using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceGame
{
    /// <summary>
    /// A singleton can be present throughout the whole game.
    /// Only one can exist at runtime. If another one is created, the old one is destroyed
    /// </summary>
    public class GameManager : MonoBehaviour
    {
       

        [Header("Entities")]
        [SerializeField] private GameObject[] enemyPrefab;
        [SerializeField] private Transform[] spawnPoints;

        /// <summary>
        /// Thigs that affect fun of gameplay.
        /// </summary>
        [Header("Game Variables")]
        [SerializeField] private float enemySpawnRate;
        // [SerializeField] private Weapon enemyWeapon = new Weapon("Melee", 1f, 0f);
        [SerializeField] private float powerUpSpawnRate;

        [Header("Game Logic Control")]
        private GameObject _tempEnemy;
        private bool _isEnemySpawning;
        // private bool _isPowerUpSpawning;
        private bool _isPlaying;

        [Header("Unity Actions")]
        public Action OnGameStart;
        public Action OnGameOver;


        [SerializeField] private Player player;
        [SerializeField] private UIManager uIManager;
        [SerializeField] private AudioManager audioManager;

        public PickUpSpawner pickUpSpawner;
        public ScoreManager scoreManager;


        #region Pseudo code
        //public ScoreManager scoreManager; DONE
        //Bullet- BulletCount. fireRate DONE
        //obstacles - asteroids
        //power ups DONE
        //score- scoreManager -> enemies destroyed DONE
        //enemies ->spawn Rate -> enemy Type -> enemy prefab -> Bosses.
        //UI Manager -> GameOver method -> GameOverScreen DONE
        //Particle effect Manager -> VFX Graph (isn't supported by webGL)
        //Animation Manager -> Enemy change to attack state
        //Sound Manager

        #endregion

        #region Singleton
        public static GameManager instance;

        public static GameManager getInstance()
        {
            return instance;
        }

        void SetSingleton()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            instance = this;
        }

        #endregion

        //Awake comes after region because it is MonoBehavior
        private void Awake()
        {
            SetSingleton();

        }

        private void Start()
        {
            StartGame();
        }
        //----------------//
        public bool IsPlaying() //for encapsulation, if something needs to check if the game is playing
        {
            return _isPlaying;
        }

        public Player GetPlayer()
        {
            return player;
        }

        //--Public Methods--//
        public void StartGame()
        {
            _isPlaying = true;
            _isEnemySpawning = true;
            StartCoroutine(EnemySpawner());
            //you could create player here

            player.OnDealth += StopGame;//Subscribing to Health OnDeath Action
            OnGameStart?.Invoke(); //broadcasting that the game is starting and calling to subscribed methods
        }
        public void StopGame()
        {
            _isEnemySpawning = false;
            StartCoroutine(GameStopper());
        }

        public void RestartGame()
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        public void NotifyDeath(Enemy enemy)
        {
            pickUpSpawner.SpawnPickUp(enemy.transform.position);
        }
        //--Private Methods--//
        IEnumerator GameStopper()
        {
            yield return new WaitForSeconds(2.0f);
            _isPlaying = false;

            foreach (Enemy item in FindObjectsByType(typeof(Enemy)))
            {
                Destroy(item.gameObject);
            }

            OnGameOver?.Invoke();

        }

        void CreateEnemy()
        {
            _tempEnemy = Instantiate(enemyPrefab[UnityEngine.Random.Range(0, enemyPrefab.Length)]);
            _tempEnemy.transform.position = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].position;
            // _tempEnemy.GetComponent<Enemy>().weapon = enemyWeapon;
            // _tempEnemy.GetComponent<MeleeEnemy>().SetMeleeEnemy(2f, 1f);
        }

        IEnumerator EnemySpawner()
        {
            while (_isEnemySpawning)
            {
                yield return new WaitForSeconds(3.0f / enemySpawnRate);
                CreateEnemy();
            }
        }


    }
}
