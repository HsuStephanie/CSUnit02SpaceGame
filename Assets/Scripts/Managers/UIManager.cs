using TMPro;
using UnityEngine;

namespace SpaceGame
{
    public class UIManager : MonoBehaviour
    {

        [Header("GamePlay")]
        [SerializeField] private TMP_Text textHealth;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text highscoreText;

        [Header("Menus")]
        [SerializeField] private GameObject menuObject;
        [SerializeField] private GameObject gameOverObject;

        private ScoreManager scoreManager;
        private Player player;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            scoreManager = GameManager.getInstance().scoreManager;
            GameManager.getInstance().OnGameStart += GameStarted;
            GameManager.getInstance().OnGameOver += GameOver;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void GameStarted()
        {

            Debug.Log("Game Started");
            menuObject.SetActive(false);
            gameOverObject.SetActive(false);
            player = GameManager.getInstance().GetPlayer();
            player.health.OnHealthUpdate += UpdateHealth;
            UpdateHealth(player.health.GetHealth());
        }

         public void UpdateScore() //used in Unity event
        {
            scoreText.SetText(scoreManager.GetScore().ToString());
        }
        public void UpdateHighScore() //used in Unity Event
        {
            highscoreText.SetText(scoreManager.GetHighScore().ToString());
        }
        public void GameOver()
        {


        }

        public void UpdateHealth(float currentHealth)
        {
            textHealth.SetText(currentHealth.ToString());
        }

       
        


    }
}
