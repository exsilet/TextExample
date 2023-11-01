using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private GameObject _panelUiGame;
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private float _currentMoveSpeed;

    public bool CanPlay = true;
    public bool IsGameStarted;
    public bool Halt;
    public float MoveSpeed => _currentMoveSpeed;
    private float _baseMoveSpeed;

    public void Start()
    {
        Time.timeScale = 0;
        IsGameStarted = false;
        _panelMenu.SetActive(true);
        _panelUiGame.SetActive(false);
        _panelGameOver.SetActive(false);
        _baseMoveSpeed = _currentMoveSpeed;
    }

    public void Update()
    {
        if (IsGameStarted == true)
        {
            _panelMenu.SetActive(false);
        }

        if (Halt)
        {
            SpeedIncrease();
        }
    }

    public void StarGame()
    {
        IsGameStarted = true;
        Time.timeScale = 1;
        CanPlay = true;
    }

    public void MoveStop()
    {
        _currentMoveSpeed = 0;
        Halt = false;
    }

    public void MovePlay()
    {
        _currentMoveSpeed = _baseMoveSpeed;
        Halt = true;
    }

    private void SpeedIncrease()
    {
        _currentMoveSpeed += 0.1f * Time.deltaTime;
        _currentMoveSpeed = Mathf.Clamp(_currentMoveSpeed, 1, 20);
    }
}