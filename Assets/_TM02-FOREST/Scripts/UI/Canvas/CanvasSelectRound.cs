using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSelectRound : CanvasBase
{
    
    public void LoadScene(string _nameScene)
    {
        switch(_nameScene)
        {
            case "Round_1":
                MessageManager.Instance.SendMessage(new Message(ManhMessageType.OnRound1));
                break;
        }
        SceneController.Instance.LoadScene(_nameScene);
    }
}
