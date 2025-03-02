using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BossCrystal_Manager))]
public class BossCrystal_Controller : MonoBehaviour
{
    [SerializeField] private BossCrystal_Manager _manager;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GetComponent<BossCrystal_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Q)) LookAtPlayer();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _manager.Jump();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(_manager.Attack2());
        }
    }
}
