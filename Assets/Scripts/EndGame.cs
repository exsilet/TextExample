using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Torch _player;
    [SerializeField] private Transform _gameOverPanel;

    private void Start()
    {
        _gameOverPanel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _player.Died += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.Died -= OnValueChanged;
    }

    private void OnValueChanged()
    {
        _gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}