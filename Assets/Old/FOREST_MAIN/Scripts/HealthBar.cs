using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IObserver
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private Image FrameBar;
    
    public void OnNotify(string action)
    {
        if (action == DefineValue.TAKE_DAMAGE)
        {
           UpdateBar(_player.GetCurrentHealth(), SaveDataPlayer.Instance.Value(20));
        }
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
