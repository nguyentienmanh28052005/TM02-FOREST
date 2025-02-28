using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShadow1_Attack2_Controller : MonoBehaviour
{
    private Animator _anim;
    
    void Start()
    {
        _anim = GetComponent<Animator>();
        StartCoroutine(WaitDestroy(0.5f));
    }

    private IEnumerator WaitDestroy(float time)
    {
        yield return new WaitForSeconds(2f);
        _anim.SetTrigger("End");
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
