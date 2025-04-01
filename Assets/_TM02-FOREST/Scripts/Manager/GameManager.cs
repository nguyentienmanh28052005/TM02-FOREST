using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            GameCanvasManager.Instance.CanvasList[DefineValue.CANVAS_INVENTORY].Show();
    }
}
