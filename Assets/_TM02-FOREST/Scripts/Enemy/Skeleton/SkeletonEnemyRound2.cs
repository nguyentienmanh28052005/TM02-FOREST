using System;
using System.Collections;
using UnityEngine;

public class SkeletonEnemyRound2 : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    private bool isfacingRight = true;
    private int _horizontal = -1;
    //private int scale;
    public float rangeXR;
    public float rangeXL;
    public float rangeY;
    private Animator _anim;
    public int atState = 1;
    public BoxCollider2D _box;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log(atState);
    }

    public float GetrangeXL()
    {
        return rangeXL;
    }

    public void SetState(int state)
    {
        atState = state;
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
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bound")
        {
            Flip();
        }
        if (other.gameObject.tag == "Skill")
        {
            if (atState == 1)
            {
                _anim.SetBool("StateShield", true);
                TimeState2(2f);
            }
            if (atState == 2)
            {
                _anim.SetTrigger("shield");
            }
        }
    }
    

    public void TimeState2(float time)
    {
        StartCoroutine(WaitSetState2(time));
    }

    private IEnumerator WaitSetState2(float time)
    {
        yield return new WaitForSeconds(time);
        _anim.SetBool("StateShield", false);
        SetState(1);
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
}
