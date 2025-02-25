using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasStartGame : CanvasBase
{
    // Start is called before the first frame update
    public void StartGame(string nameScene)
    {
        Debug.Log("Happy new year" + ", I will have a game programming job"+ ", Lucky" + ", My family is always healthy" + ", Lucky");
        SceneController.Instance.LoadScene(nameScene, true, true);
    }
}
