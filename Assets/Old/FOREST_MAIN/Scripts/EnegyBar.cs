using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class EnegyBar : MonoBehaviour
{
    [SerializeField] private Image FrameBar;
    public float _maxEnegy = 100;
    private float _currentEnegy = 0;

    private void Start()
    {
        FrameBar.fillAmount = 0;
    }

    public void UpdateBar(float update)
    {
        _currentEnegy += update;
        if (_currentEnegy > _maxEnegy) _currentEnegy = _maxEnegy;
        FrameBar.fillAmount = _currentEnegy / _maxEnegy;
    }

    public float GetCurrentEnegy()
    {
        return _currentEnegy;
    }
}
