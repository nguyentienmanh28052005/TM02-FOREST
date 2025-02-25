using UnityEngine;

public class OffCam : MonoBehaviour
{
    public GameObject _cam;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
