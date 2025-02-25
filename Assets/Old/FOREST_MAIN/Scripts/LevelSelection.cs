using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] _button;
    private float _levelAt;
    private GameObject _data;

    private void Awake()
    {
        _data = GameObject.Find("Data");
    }

    void Start()
    {
        _levelAt = _data.GetComponent<SaveDataPlayer>().Value(30);
        for (int i = 0; i < _button.Length; i++)
        {
            if (i > _levelAt)
            {
                _button[i].interactable = false;
            }
        }
    }
}
