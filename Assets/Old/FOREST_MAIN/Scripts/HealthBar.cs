using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _player;
    [SerializeField] private Image FrameBar;
    
    public void OnNotify(PlayerAction action)
    {
        
    }
    
    public void UpdateBar(float currentHealth, float maxHealth)
    {
        FrameBar.fillAmount = currentHealth / maxHealth;
    }

    private void OnEnable()
    {
        _player.AddObserver(this);
    }

    private void OnDisable()
    {
        _player.RemoveObserver(this);
    }
}
