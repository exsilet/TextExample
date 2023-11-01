using System;
using UnityEngine;
using UnityEngine.UI;

public class TorchView : MonoBehaviour
{
    [SerializeField] private Image[] _emptyIcons;
    [SerializeField] private Sprite _fillIcon;
    [SerializeField] private Sprite _emptyIcon;
    [SerializeField] private Torch _torch;

    public int maxFire;

    private void Start()
    {
        maxFire = _emptyIcons.Length;
    }

    private void OnEnable()
    {
        _torch.FireChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _torch.FireChanged -= OnValueChanged;
    }
    
    public void IconFire()
    {
        for (int i = 0; i < _emptyIcons.Length; i++)
        {
            if (_torch.CurrentFire > i)
            {
                _emptyIcons[i].overrideSprite = _fillIcon;
            }
        }
    }

    private void OnValueChanged(int countFire)
    {
        for (int i = 0; i < _emptyIcons.Length; i++)
        {
            if (i < countFire)
                _emptyIcons[i].overrideSprite = _fillIcon;
            else
                _emptyIcons[i].overrideSprite = _emptyIcon;
        }
    }
}