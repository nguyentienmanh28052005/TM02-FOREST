using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BossCrystal_Manager))]
public class BossCrystal_Controller : MonoBehaviour
{
    [SerializeField] private BossCrystal_Manager _manager;
    [SerializeField] private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GetComponent<BossCrystal_Manager>();
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Test();
        
    }

    public void Test()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(_manager.Attack1());
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(_manager.Attack2());
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(_manager.Attack3());
        }
    }
}
