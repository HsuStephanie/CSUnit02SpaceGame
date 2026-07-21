using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


namespace SpaceGame
{
    /// <summary>
    /// Player prefs is a dictionary. Some data can be stored in Player prefs.
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        private int _score;
        private int _highScore;

        public UnityEvent OnScoreUpdate;
        public UnityEvent OnHighScoreUpdate;

        private void Start()
        {
            _highScore = PlayerPrefs.GetInt("Highscore", 0);
            OnHighScoreUpdate?.Invoke(); //used to retrieve the high score
            GameManager.getInstance().OnGameStart += OnGameStart;
        }

        public void OnGameStart()
        {
            _score = 0;
        }

        public void SetHighScore()
        {
            PlayerPrefs.SetInt("Highscore", _highScore);
        }

        /// <summary>
        /// Method to retrieve information
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {
            return _highScore;
        }

        public int GetHighScore()
        {
            return _highScore;
        }
        /// <summary>
        /// Score increases evety time enemy is killed. And check high score
        /// </summary>
        public void IncrementScore()
        {
            _score++;
            OnScoreUpdate?.Invoke();

            if (_score > _highScore)
            {
                _highScore = _score;
                OnHighScoreUpdate?.Invoke();
            }
        }

        
    }
}
