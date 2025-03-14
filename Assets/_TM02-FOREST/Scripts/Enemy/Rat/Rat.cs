using UnityEngine;

public class Rat : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    private bool isfacingRight = true;
    private int _horizontal = 1;
    private Animator _anim;
    private float _time = 0f;
    private float _randTime;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _randTime = Random.Range(4, 8);
    }


    private void Update()
    {
        _time += Time.deltaTime;
        if (_time > _randTime)
        {
            _anim.SetTrigger("ability");
            _time = 0;
            _randTime = Random.Range(4, 8);
        }
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
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
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
    
}
