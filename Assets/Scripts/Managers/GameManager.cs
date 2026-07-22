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
        private Weapon peaShooter = new Weapon();

        [Header("Entities")]
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Transform[] spawnPoints; //this also could be a list

        /// <summary>
        /// Thigs that affect fun of gameplay.
        /// </summary>
        [Header("Game Variables")]
        [SerializeField] private float enemySpawnRate;
        [SerializeField] private Weapon enemyWeapon = new Weapon("Melee", 1f, 0f);
        [SerializeField] private float powerUpSpawnRate;
        
        [Header("Game Logic Control")]
        private GameObject _tempEnemy;
        private bool _isEnemySpawning;
        private bool _isPowerUpSpawning;
        private bool _isPlaying;

        [Header("Unity Actions")]
        public Action OnGameStart;
        public Action OnGameOver;


        [SerializeField] private Player player;

        [SerializeField] public ScoreManager scoreManager;
        [SerializeField] private UIManager uIManager;
        
        #region Pseudo code
        //public ScoreManager scoreManager;
        //Bullet- BulletCount. fireRate
        //obstacles - asteroids
        //power ups
        //score- scoreManager -> enemies destroyed
        //enemies ->spawn Rate -> enemy Type -> enemy prefab -> Bosses.
        //UI Manager -> GameOver method -> GameOverScreen
        //Particle effect Manager -> VFX Graph (isn't supported by webGL)
        //Animaation Manager -> Enemy change to attack state
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
        //for encapsulation, if something needs to check if the game is playing
        public bool IsPlaying()
        {
            return _isPlaying;
        }

        public Player GetPlayer()
        {
            return player;
        }
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

        IEnumerator GameStopper()
        {
            yield return new WaitForSeconds(2.0f);
            _isPlaying = false;
            
            foreach(Enemy item in FindObjectsByType(typeof(Enemy)))
            {
                Destroy(item.gameObject);
            }

            OnGameOver?.Invoke();
            
        }

        void CreateEnemy()
        {
            _tempEnemy = Instantiate(enemyPrefab);
            _tempEnemy.transform.position = spawnPoints[UnityEngine.Random.Range(0,spawnPoints.Length)].position;
            _tempEnemy.GetComponent<Enemy>().weapon = enemyWeapon;
            _tempEnemy.GetComponent<MeleeEnemy>().SetMeleeEnemy(2f, 1f);
        }

        IEnumerator EnemySpawner()
        {
            while (_isEnemySpawning)
            {
                yield return new WaitForSeconds( 1.0f/enemySpawnRate);
                CreateEnemy();   
            }
        }


    }
}
