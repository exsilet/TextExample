using UnityEngine;

public class RoadBlock : MonoBehaviour
{
    private Vector3 _moveVector;
    private GameStart _gameStart;

    private void Start()
    {
        _gameStart = FindObjectOfType<GameStart>();
        _moveVector = Vector3.back;
    }

    private void Update()
    {
        if(_gameStart.CanPlay)
            transform.Translate(_moveVector * Time.deltaTime * _gameStart.MoveSpeed);
    }
}