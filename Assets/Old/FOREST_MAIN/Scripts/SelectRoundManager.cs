using System;
using UnityEngine;

public class SelectRoundManager : MonoBehaviour
{
    private SaveDataPlayer _data;
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _selectRound;
    [SerializeField] private GameObject _buttonSetting;
    [SerializeField] private GameObject _buttonShop;
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _upHealth;
    [SerializeField] private GameObject _upDamage;
    [SerializeField] private GameObject _upEnegy;

    private void Start()
    {
        _data = GameObject.Find("Data").GetComponent<SaveDataPlayer>();
    }

    public void OnShop()
    {
        _shop.SetActive(true);
        _selectRound.SetActive(false);
        _buttonSetting.SetActive(false);
        _buttonShop.SetActive(false);
        _key.SetActive(false);
        _coin.SetActive(false);
    }

    public void Back()
    {
        _shop.SetActive(false);
        _selectRound.SetActive(true);
        _buttonSetting.SetActive(true);
        _buttonShop.SetActive(true);
        _key.SetActive(true);
        _coin.SetActive(true);
    }

    public void UpHealth()
    {
        if (_data.Value(2) > 0)
        {
            float newValue = _data.Value(2) - 1;
            _data.Save(2, newValue);
            newValue = _data.Value(20) + _data.Value(20) * 20 / 100;
            _data.Save(20, newValue);
        }
    }

    public void UpDamage()
    {
        if (_data.Value(2) > 0)
        {
            float newValue = _data.Value(2) - 1;
            _data.Save(2, newValue);
            newValue = _data.Value(21) + _data.Value(21) * 14 / 100;
            _data.Save(21, newValue);
        }
    }

    public void UpEnegy()
    {
        if (_data.Value(2) > 0)
        {
            float newValue = _data.Value(2) - 1;
            _data.Save(2, newValue);
            newValue = _data.Value(23) + _data.Value(23) * 28 / 100;
            _data.Save(23, newValue);
        }
    }

    public void OnSetting()
    {
        UIController uiController = GameObject.Find("UIController").GetComponent<UIController>();
        uiController.Pause();
    }
}
