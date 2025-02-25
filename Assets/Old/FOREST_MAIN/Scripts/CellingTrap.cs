using System;
using UnityEngine;

public class CellingTrap : MonoBehaviour
{
    [SerializeField] private GameObject _cam;
    [SerializeField] private GameObject _player;

    private CameraShake _shake;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _shake = _cam.GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Map")
        {
            if (Vector2.Distance(_player.transform.position, transform.position) < 30)
            {
                _shake.ShakeCamera(5);
            }
        }
    }
}
