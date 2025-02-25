using System;
using System.Collections;
using UnityEngine;

public class TrapWorm1 : MonoBehaviour
{
    [SerializeField] private GameObject _worm1;
    [SerializeField] private GameObject _worm2;
    [SerializeField] private GameObject _worm3;
    // [SerializeField] private GameObject _worm4;
    // [SerializeField] private GameObject _worm5;
    private float delayTime = 4f;
    float time = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(delayWorm());
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > delayTime)
        {
            StartCoroutine(delayWorm());
            time = 0;
        }

    }

    private IEnumerator delayWorm()
    {
        _worm1.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        _worm1.SetActive(false);
        _worm2.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        _worm2.SetActive(false);
        _worm3.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        _worm3.SetActive(false);
        
    }
}
