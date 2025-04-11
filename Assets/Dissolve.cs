using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;



public class Dissolve : MonoBehaviour
{
    [SerializeField] private float _dissolveTime = 10000f;

    private SpriteRenderer[] _spriteRenderers;
    private Material[] _materials;

    private int _dissolveAmount = Shader.PropertyToID("_DissolveAmount");
    private int _verticalDissolveAmount = Shader.PropertyToID("_VerticalDissolve");


    private void Start()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        _materials = new Material[_spriteRenderers.Length];
        for (int i = 0; i < _spriteRenderers.Length; i++)
        {
            _materials[i]= _spriteRenderers[i].material;
        }
        // StartCoroutine(Vanis(true, false));
        
        
    }
    bool n=true;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            StartCoroutine(Vanis(false, true));
        }
        if(Input.GetKeyDown(KeyCode.D)){
            StartCoroutine(Appear(false, true));
        }
        // if(n)
        // {
        //     StartCoroutine(Appear(true, false));n=false;
        // }
    }


    public IEnumerator Vanis(bool useDissolve, bool useVertical)
    {
        float elapsetTime = 0f;
        while(elapsetTime < _dissolveTime)
        {
            elapsetTime += Time.deltaTime;
            float lerpedDissolve = Mathf.Lerp(0f, 1.1f, (elapsetTime / _dissolveTime));
            float lerpedVerticalDissolve = Mathf.Lerp(0.5f, 1.1f, (elapsetTime / _dissolveTime));

            for (int i = 0; i < _materials.Length; i++)
            {  
                if(useDissolve) 
                    _materials[i].SetFloat(_dissolveAmount, lerpedDissolve);

                if(useVertical)
                    _materials[i].SetFloat(_verticalDissolveAmount, lerpedVerticalDissolve);
            }
            yield return null;
        }

    }

   public IEnumerator Appear(bool useDissolve, bool useVertical)
    {
        float elapsetTime = 0f;
        while(elapsetTime < _dissolveTime)
        {
            elapsetTime += Time.deltaTime;
            float lerpedDissolve = Mathf.Lerp(1.1f, 0f, (elapsetTime / _dissolveTime));
            float lerpedVerticalDissolve = Mathf.Lerp(1.1f, 0f, (elapsetTime / _dissolveTime));

            for (int i = 0; i < _materials.Length; i++)
            {
                if(useDissolve)
                    _materials[i].SetFloat(_dissolveAmount, lerpedDissolve);

                if(useVertical)
                    _materials[i].SetFloat(_verticalDissolveAmount, lerpedVerticalDissolve);
            }

            yield return null;
        }

    }
}
