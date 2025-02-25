using System;
using System.Collections;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] private GameObject _bomb;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _posiCam;
    [SerializeField] private GameObject _beeGFX;
    private Rigidbody2D rb;
    private int cnt = 0;
    private bool check = true;
    private bool checkDoubleTrigger = false;
    private bool canFlip = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetPosi();
    }

    private void Update()
    {
        if (rb.position.x - _target.position.x < 2f && cnt == 0) //  
        {
            GameObject bomb = Instantiate(_bomb, transform.position, transform.rotation);
            bomb.SetActive(true);
            cnt++;
            check = false;
            checkDoubleTrigger = true;
        }
        if (check)
        {
            Vector2 target = new Vector2(_target.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, 20f * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        else
        {
            Vector2 _direction = new Vector2(-1, rb.velocity.y);
            if (canFlip)
            {
                transform.Rotate(0f, 180f, 0f);
                canFlip = !canFlip;
            }
            transform.Translate(_direction * Time.deltaTime * 20f);
        }

        // if (Vector2.Distance(transform.position, _posiCam.position) > 20f)
        // {
        //     
        // }
    }

    private void ResetPosi()
    {
        transform.position = new Vector3(_posiCam.position.x + 30f, _posiCam.position.y + 5f, 5f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "RangeCam")
        {
            if (checkDoubleTrigger)
            {
                checkDoubleTrigger = !checkDoubleTrigger;
                Debug.Log("hi");
                _beeGFX.SetActive(false);
                StartCoroutine(ReStart());
            }
        }
    }

    private IEnumerator ReStart()
    {
        yield return new WaitForSeconds(1f);
        transform.Rotate(0f, 180f, 0f);
        cnt = 0;
        check = true;
        ResetPosi();
        canFlip = !canFlip;
        _beeGFX.SetActive(true);
    }
}
