using System;
using UnityEngine;

public class BossRound1_Manager : AEnemy
{
        [SerializeField] private GameObject _limit;
    
        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _rb = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            MoveToObject(_player);
            if (Vector2.Distance(_player.transform.position, transform.position) < 10f)
            {
                _limit.SetActive(true);
                _anim.SetBool("Spawn",true);
            }
        }
}
