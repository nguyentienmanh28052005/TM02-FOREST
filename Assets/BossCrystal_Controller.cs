using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BossCrystal_Manager))]
public class BossCrystal_Controller : MonoBehaviour
{
    [SerializeField] private BossCrystal_Manager _manager;
    [SerializeField] private Transform _playerTrans;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GetComponent<BossCrystal_Manager>();
        _playerTrans = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Mathf.Abs(transform.position.x - _playerTrans.position.x));
        //if (Mathf.Abs(transform.position.x - _playerTrans.position.x) < 10f && BossCrystal_Manager.canAttack)
        
       if(Mathf.Abs(transform.position.x - _playerTrans.position.x) < 10f && Mathf.Abs(transform.position.x - _playerTrans.position.x) < 9f && !BossCrystal_Manager._busy)
        {
            //StartCoroutine(_manager.Attack2());
            StartCoroutine(_manager.Attack1());
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            _manager.InstanceBullet();
        }
    }
}
