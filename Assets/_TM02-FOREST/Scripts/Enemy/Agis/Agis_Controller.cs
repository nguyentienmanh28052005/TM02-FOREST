using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agis_Controller : MonoBehaviour
{
    [SerializeField] private StateManager _stateManager;
    [SerializeField] private Agis_Manager _agisManager;
    void Start()
    {
        _stateManager = GetComponent<StateManager>();
    }
    
    void Update()
    {
       
    }
}
