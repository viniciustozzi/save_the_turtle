using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region Singleton

    private static GameManager mInstance;

    public static GameManager Instance
    {
        get
        {
            if (mInstance != null)
                return mInstance;
            else
            {
                mInstance = FindObjectOfType<GameManager>();

                if (mInstance == null)
                {
                    var go = new GameObject();
                    mInstance = go.AddComponent<GameManager>();
                }

                return mInstance;
            }
        }
    }

    public void OnVictory()
    {
        Debug.Log("VITÓRIA!!!!");
    }

    #endregion

    public GameObject turtlePrefab;
    public Transform startTransform;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {

    }

    private void InstantiatePlayer()
    {
        Instantiate(turtlePrefab, startTransform.position, Quaternion.identity);
    }

    public void OnPlayerDeath()
    {
        SceneManager.LoadScene(Scenes.GameScene);
    }

}
