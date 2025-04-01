using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInventory : CanvasBase
{
    [SerializeField] private List<GameObject> _gem;
    [SerializeField] private List<GameObject> _description;
    [SerializeField] private List<Slot> _slot;

    private Dictionary<string, bool> _stateGem = new Dictionary<string, bool>();
    
    private void Start()
    {
        _stateGem.Add(DefineValue.GEM_ARMOR, false);
        _stateGem.Add(DefineValue.GEM_LIFESTEAL, false);
        _stateGem.Add(DefineValue.GEM_SPEED, false);
        _stateGem.Add(DefineValue.GEM_SPIRIT, false);
        _stateGem.Add(DefineValue.GEM_CRITICAL, false);
        _stateGem.Add(DefineValue.GEM_STRENGTH, false);

    }

    public void Select(string name)
    {
        foreach (var des in _description)
        {
            if(des.name == name) des.SetActive(true);
            else des.SetActive(false);
        }
    }
    
    public void Equip(string name)
    {
        foreach (var slot in _slot)
        {
            if (slot.gameObject.name == "none")
            {
                foreach (var gem in _gem)
                {
                    if (gem.name == name && !_stateGem[name])
                    {
                        _stateGem[name] = !_stateGem[name];
                        Debug.Log(_stateGem[name]);
                        gem.GetComponent<Button>().interactable = false;
                        slot.Equip(name);
                        break;
                    }
                }
                
            }
        }
    }

    public void UnEquip(string name)
    {
        foreach (var slot in _slot)
        {
            if (slot.gameObject.name == name)
            {
                foreach (var gem in _gem)
                {
                    if (gem.name == name && _stateGem[name])
                    {
                        _stateGem[name] = !_stateGem[name];
                        gem.GetComponent<Button>().interactable = true;
                        slot.UnEquip(name);
                        break;
                    }
                }
                
            }
        }
    }
}
