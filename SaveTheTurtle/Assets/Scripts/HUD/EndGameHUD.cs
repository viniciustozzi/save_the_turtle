using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameHUD : MonoBehaviour
{

    public void OnRestartClick()
    {
        SceneManager.LoadScene(Scenes.GameScene);
    }
}
