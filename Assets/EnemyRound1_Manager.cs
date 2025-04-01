using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRound1_Manager : MonoBehaviour
{
    [SerializeField] private GameObject _flyPrefab;

    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(_player.transform.position.x < 85f + 0.1f &&
           _player.transform.position.x > 85f - 0.1f) _flyPrefab.SetActive(true);
            
    }
}
