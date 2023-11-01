using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _scoreTextGameOver;
    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private float _scoreBaseValue;
    [SerializeField] private float _scoreMultiplayer;
    [SerializeField] private GameStart _gameStart;

    private float _score;
    private bool _endScore = true;

    private void Start()
    {
        _bestScoreText.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }

    private void Update()
    {
        if (_endScore)
        {
            ScoreUp();
        }
    }

    private void ScoreUp()
    {
        _score += _scoreBaseValue * _scoreMultiplayer * Time.deltaTime;
        _scoreMultiplayer += 0.05f * Time.deltaTime;
        _scoreMultiplayer = Mathf.Clamp(_scoreBaseValue, 1, 20);

        _scoreText.text = ((int)_score).ToString();
    }

    public void ResetScore()
    {
        _score = 0;
        _endScore = true;
        _scoreText.text = ((int)_score).ToString();
    }

    public void UpdateScore()
    {
        _endScore = false;
        _scoreTextGameOver.text = ((int)_score).ToString();

        if (_score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", _score);
            _bestScoreText.text = ((int)_score).ToString();
        }
    }
}