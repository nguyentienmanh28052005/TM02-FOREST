using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCrystal_Portal : MonoBehaviour
{
    [SerializeField] private List<GameObject> _portals;
    [SerializeField] private GameObject _ice;
    public void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1)) LookAtObject2D(_portals[0]);
        if (Input.GetKey(KeyCode.Alpha2)) LookAtObject2D(_portals[1]);
        if (Input.GetKey(KeyCode.Alpha3)) LookAtObject2D(_portals[2]);
        if(Input.GetKeyDown(KeyCode.Alpha5)) Instantiate(_ice, transform.position, transform.rotation);
    }

    protected void LookAtObject2D(GameObject _object)
    {
        Vector2 direction = (_object.transform.position - transform.position).normalized;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle -180);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
    }
    
    
}
