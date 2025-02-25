using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coin;

    public int round;

    private GameObject _data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _data = GameObject.Find("Data");
        if (_data.GetComponent<SaveDataPlayer>().Value(100 + coin * 10 + round) != 0)
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
            float newCoin = _data.GetComponent<SaveDataPlayer>().Value(2) + 1;
            _data.GetComponent<SaveDataPlayer>().Save(2, newCoin);
            _data.GetComponent<SaveDataPlayer>().Save(100 + coin * 10 + round, 1);
            gameObject.SetActive(false);
        }
    }
}
