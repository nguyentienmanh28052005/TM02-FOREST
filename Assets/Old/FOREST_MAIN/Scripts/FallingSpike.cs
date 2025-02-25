using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float _time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
