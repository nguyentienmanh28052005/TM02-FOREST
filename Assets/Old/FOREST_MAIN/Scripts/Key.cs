using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int round;
    private GameObject _data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _data = GameObject.Find("Data");
        if (_data.GetComponent<SaveDataPlayer>().Value(200 + round) != 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            float newCoin = _data.GetComponent<SaveDataPlayer>().Value(1) + 1;
            _data.GetComponent<SaveDataPlayer>().Save(1, newCoin);
            _data.GetComponent<SaveDataPlayer>().Save(200 + round, 1);
            gameObject.SetActive(false);
        }
    }
}