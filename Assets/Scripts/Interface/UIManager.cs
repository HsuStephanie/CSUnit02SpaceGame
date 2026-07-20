using TMPro;
using UnityEngine;

namespace SpaceGame
{
    public class UIManager : MonoBehaviour
    {
        
        [Header("GamePLay")]
        [SerializeField] private TextMeshProUGUI textHealth;
        private Player player;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            GameManager.getInstance().OnGameStart += GameStarted;
            GameManager.getInstance().OnGameOver += GameOver;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void GameStarted()
        {
            Debug.Log("Game STarted");
            player = GameManager.getInstance().GetPlayer();
            player.health.OnHealthUpdate += UpdateHealth;
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
