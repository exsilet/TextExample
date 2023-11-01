using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private RoadGenerator _generator;
    [SerializeField] private GameStart _start;
    [SerializeField] private Score _score;

    public void ResetGame()
    {
        _panel.SetActive(false);
        _start.IsGameStarted = false;
        _generator.ResetLevel();
        _start.MovePlay();
        _score.ResetScore();
    }

    public void ReturnMenu()
    {
        _start.IsGameStarted = false;
    }
}