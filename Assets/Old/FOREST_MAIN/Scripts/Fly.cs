using System;
using System.Collections;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] private GameObject _bomb;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _posiCam;
    [SerializeField] private GameObject _beeGFX;
    private Rigidbody2D _rb;
    private int _cnt = 0;
    private bool _check = true;
    private bool _checkDoubleTrigger = false;
    private bool _canFlip = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _posiCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        ResetPosi();
    }

    private void Update()
    {
        if (_rb.position.x - _target.position.x < 2f && _cnt == 0) //  
        {
            GameObject bomb = Instantiate(_bomb, transform.position, transform.rotation);
            bomb.SetActive(true);
            _cnt++;
            _check = false;
            _checkDoubleTrigger = true;
        }
        if (_check)
        {
            Vector2 target = new Vector2(_target.position.x, _rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(_rb.position, target, 20f * Time.fixedDeltaTime);
            _rb.MovePosition(newPos);
        }
        else
        {
            Vector2 _direction = new Vector2(-1, _rb.velocity.y);
            if (_canFlip)
            {
                transform.Rotate(0f, 180f, 0f);
                _canFlip = !_canFlip;
            }
            transform.Translate(_direction * Time.deltaTime * 20f);
        }
    }

    private void ResetPosi()
    {
        transform.position = new Vector3(_posiCam.position.x + 30f, _posiCam.position.y + 5f, 0f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "RangeCam")
        {
            if (_checkDoubleTrigger)
            {
                _checkDoubleTrigger = !_checkDoubleTrigger;
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
        _cnt = 0;
        _check = true;
        ResetPosi();
        _canFlip = !_canFlip;
        _beeGFX.SetActive(true);
    }
}
