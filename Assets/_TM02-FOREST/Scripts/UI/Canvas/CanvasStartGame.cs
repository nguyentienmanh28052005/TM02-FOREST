using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasStartGame : CanvasBase
{
    // Start is called before the first frame update
    public void StartGame(string nameScene)
    {
        MessageManager.Instance.SendMessage(new Message(ManhMessageType.OnGameStart));
        SceneController.Instance.LoadScene(nameScene, true, true);
    }
}
