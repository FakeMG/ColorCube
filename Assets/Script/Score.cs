using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Script {
    public class Score : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private UnityEvent onWin;
        private int _currentScore;

        private void Update() {
            UpdateScoreText();
            if (_currentScore == 10)
                onWin?.Invoke();
        }

        public void AddScore(int score) {
            _currentScore += score;
        }

        private void UpdateScoreText() {
            scoreText.text = $"Score: {_currentScore}";
        }
    }
}