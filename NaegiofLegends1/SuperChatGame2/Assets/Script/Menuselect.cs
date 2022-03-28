﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuselect : MonoBehaviour
{
    GameController gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void StartGame(int index)
    {
        SceneManager.sceneLoaded += SceneLoaded;
        SceneManager.LoadScene(index);
    }
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameController.StartingScenarioSet();
    }
}