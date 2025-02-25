using UnityEngine;

public class SetEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _fly;
    [SerializeField] private Transform _playerPosi;

    // Update is called once per frame
    void Update()
    {
        if (_playerPosi.position.x > 44f )
        {
            _fly.SetActive(true);
        }
        else if (_playerPosi.position.x > 147f)
        {
            _fly.SetActive(false);
        }
    }
}
