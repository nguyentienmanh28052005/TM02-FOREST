using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSelectRound : CanvasBase
{
    public void LoadScene(string _nameScene)
    {
        SceneController.Instance.LoadScene(_nameScene);
    }
}
