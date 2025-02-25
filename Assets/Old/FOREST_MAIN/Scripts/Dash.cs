using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DashEnemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;
    [SerializeField] private TrailRenderer tr;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private IEnumerator Dash()
    {
        // _rb.sharedMaterial.friction = 100f;
        // yield return new WaitForSeconds(1f);
        canDash = false;
        isDashing = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        _rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        //_rb.sharedMaterial.friction = 0.01f;
        canDash = true;

    }
}
