using System;
using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private GameObject _data;
    private SaveDataPlayer _dataPlayer;
    private float _key;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _door;
    private Animator _anim;
    private Vector3 _posiBoss;
    [SerializeField] private GameObject _boss;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _posiBoss = new Vector3(1056f, -1.67f, 10);
        _data = GameObject.Find("Data");
        _dataPlayer = _data.GetComponent<SaveDataPlayer>();
        _key = _dataPlayer.Value(1);
        _anim = _player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_key >= 1 && _dataPlayer.Value(301) == 0)
            {
                float _newKey = _dataPlayer.Value(1) - 1;
                _dataPlayer.Save(1, _newKey);
                _door.SetActive(false);
                _anim.SetTrigger("Shade");
                StartCoroutine(delayTele());
                _dataPlayer.Save(301, 1);
            }
            else if(_dataPlayer.Value(301) == 1)
            {
                _door.SetActive(false);
                _anim.SetTrigger("Shade");
                StartCoroutine(delayTele());
            }
        }
    }

    private IEnumerator delayTele()
    {
        yield return new WaitForSeconds(0.8f);
        _player.transform.position = _posiBoss;
        _boss.SetActive(true);
    }
}
