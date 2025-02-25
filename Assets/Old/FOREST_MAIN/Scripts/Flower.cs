using System;
using System.Collections;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private Animator _anim;

    private float time;

    private float delayTime = 5f;

    private bool check = true;

    [SerializeField] private GameObject _light;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RangeCamFlower")
        {
            _anim.SetBool("Bloom", true);
            if (check)
            {
                StartCoroutine(WaitLight());
            }
        }
    }

    private IEnumerator WaitLight()
    {
        yield return new WaitForSeconds(0.8f);
        _light.SetActive(true);
        check = false;
    }
    
}
