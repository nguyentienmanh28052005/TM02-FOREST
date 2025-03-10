using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gemList;

    public void Equip(string name)
    {
        foreach (var gem in _gemList)
        {
            if (gem.name == name)
            {
                gem.SetActive(true);
                gameObject.name = gem.name;
            }
            else gem.SetActive(false);
        }
    }

    public void UnEquip(string name)
    {
        foreach (var gem in _gemList)
        {
            if (gem.name == name)
            {
                gem.SetActive(false);
                gameObject.name = "none";
            }
        }
    }
}
