using System;
using UnityEngine;

public interface IObserver
{
    public void OnNotify(String action);
}
