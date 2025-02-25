using System;
using UnityEngine;

public class TaiSao : MonoBehaviour
{
    private GameObject _fullSetting;
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _key;

    private GameObject _cam;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _fullSetting = GameObject.FindWithTag("Test");
            _cam = GameObject.FindWithTag("CamTest");
            _fullSetting.SetActive(false);
            _cam.SetActive(false);
        }

        private void Update()
        {
            
        }

        // Update is called once per frame
        public void On()
        {
            _cam.SetActive(true);
            _fullSetting.SetActive(true);
            _coin.SetActive(false);
            _key.SetActive(false);
        }
}
