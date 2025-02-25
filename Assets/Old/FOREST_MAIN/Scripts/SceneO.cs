using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneO : MonoBehaviour
{
    public int _scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // private void Awake()
    // {
    //     SceneManager.LoadScene(2);
    // }

    public int Name()
    {
        return _scene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
