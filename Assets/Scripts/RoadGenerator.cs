using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _roadPrefabs;
    [SerializeField] private GameObject _startRoad;
    [SerializeField] private float _maxRoadCount;
    [SerializeField] private GameStart _start;
    [SerializeField] private PlayerMover _player;
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private Torch _torch;

    private float _startRoadPosition = 0;
    private float _currentRoadPosition = 0;
    private float _roadLength = 16.8f;
    private Vector3 _startPlayerPosition;

    private List<GameObject> _roads = new List<GameObject>();

    private void Start()
    {
        _startRoadPosition = _player.transform.position.z + 5;

        StartGame();
    }

    private void LateUpdate()
    {
        SheckForSpawn();
    }

    private void SheckForSpawn()
    {
        if (_roads[0].transform.position.z - _player.transform.position.z < -25)
        {
            SpawnRoad();
            
            Destroy(_roads[0]);
            _roads.RemoveAt(0);
        }
    }

    public void ResetLevel()
    {
        _panelGameOver.SetActive(false);
        _player.PlayMove();
        _start.IsGameStarted = true;
        _torch.ResetFire();
        
        _currentRoadPosition = _startRoadPosition;
        _player.transform.position = _startPlayerPosition;

        foreach (GameObject road in _roads) 
            Destroy(road);
        
        _roads.Clear();
        
        for (int i = 0; i < _maxRoadCount; i++) 
            SpawnRoad();
    }

    private void StartGame()
    {
        for (int i = 0; i < _maxRoadCount; i++) 
            SpawnRoad();
    }

    private void SpawnRoad()
    {
        GameObject road = Instantiate(_roadPrefabs[Random.Range(0, _roadPrefabs.Length)], transform);
        Vector3 roadPosition;
        
        if (_roads.Count > 0)
            roadPosition = _roads[_roads.Count - 1].transform.position + new Vector3(0, 0, _roadLength);
        else
            roadPosition = new Vector3(0, 0, _startRoadPosition);
        
        road.transform.position = roadPosition;
        road.transform.SetParent(transform);
        
        _roads.Add(road);
    }
}