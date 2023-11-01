using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Torch : MonoBehaviour
{
    [SerializeField] private TorchView _torchView;
    [SerializeField] private int _countFire;
    [SerializeField] private float _secondBurningTorch;

    private int _currentFire;
    public int CurrentFire => _currentFire;
    public event UnityAction<int> FireChanged;
    public event UnityAction Died;

    private void Start()
    {
        _currentFire = _countFire;
        _torchView.IconFire();
    }

    public void ResetFire()
    {
        _currentFire = _countFire;
    }

    public void ExtinguishingFire(int countWater)
    {
        if (_currentFire > 0)
            StartCoroutine(Extinguishing(countWater));

        if (_currentFire <= 0)
            Die();
    }

    public void AddFire(int fire)
    {
        if (_countFire <= _torchView.maxFire) 
            _currentFire += fire;
        
        FireChanged?.Invoke(_currentFire);
    }

    private void Die()
    {
        StopCoroutine(Extinguishing(_currentFire));
        Died?.Invoke();
    }

    private IEnumerator Extinguishing(int countWater)
    {
        yield return new WaitForSeconds(_secondBurningTorch);
        _currentFire -= countWater;
        FireChanged?.Invoke(_currentFire);
    }
}