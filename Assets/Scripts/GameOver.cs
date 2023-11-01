using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Torch _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private Score _score;
    [SerializeField] private GameStart _gameStart;

    private void OnEnable() => 
        _player.Died += OnPlayerDied;

    private void OnDisable() =>
        _player.Died -= OnPlayerDied;

    private void OnPlayerDied()
    {
        _panelGameOver.SetActive(true);
        _playerMover.StopMove();
        _score.UpdateScore();
        _gameStart.MoveStop();
    }
}