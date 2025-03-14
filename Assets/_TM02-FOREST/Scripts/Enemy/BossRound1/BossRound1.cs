using System;
using UnityEngine;

public class BossRound1 : MonoBehaviour
{
    public Transform player;
        public bool isFlipped = false;
        private bool isfacingRight = true;
        private int _horizontal = 1;
        public float rangeXR;
        public float rangeXL;
        private Animator _anim;
        [SerializeField] private GameObject _limit;
    
        private void Start()
        {
            _anim = GetComponent<Animator>();
        }
    
        public float GetrangeXL()
        {
            return rangeXL;
        }
    
        public float GetrangeXR()
        {
            return rangeXR;
        }
        
        public void LookAtPlayer()
        {
            Vector3 flipped = transform.localScale;
            flipped.z *= -1f;
    
            if (transform.position.x > player.position.x && isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            else if (transform.position.x < player.position.x && !isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }
        }
        
        
        void Flip()
        {
            isFlipped = !isFlipped;
            _horizontal *= -1;
            Vector3 kich_thuoc = transform.localScale;
            kich_thuoc.x = -1 * kich_thuoc.x;
            transform.localScale = kich_thuoc;
        }
    
        public int GetHorizontal()
        {
            return _horizontal;
        }
        
        public bool GetDirection()
        {
            return isFlipped;
            
        }

        private void Update()
        {
            if (Vector2.Distance(player.position, transform.position) < 10f)
            {
                _limit.SetActive(true);
                _anim.SetBool("Spawn",true);
            }
        }
}
