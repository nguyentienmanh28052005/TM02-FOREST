using UnityEngine;

public class DonDestroy : MonoBehaviour
{
    public GameObject _hi;
    void Start()
    {
        DontDestroyOnLoad(_hi);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
