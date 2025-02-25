using System;
using System.Collections;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class Hooded_ParticleEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem PS;
    private Hooded_Controller _player;

    public void PlayParticle(float time)
    {
        // Vector2 updatePosi = new Vector2(_posi.position.x, _posi.position.y);
        // transform.position = updatePosi;
        PS.Play();
        StartCoroutine(WaitStop(time));
    }

    public void Stop()
    {
        PS.Stop();
    }
    
    private IEnumerator WaitStop(float time)
    {
        yield return new WaitForSeconds(time);
        PS.Stop();

    }
    
}
