﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{


    public void popUp()
    {
        if (!EntitasDetail.inspectPopUp2)
        {
            EntitasDetail.inspectPopUp = true;
            Time.timeScale = 0.1f;
            SceneManager.LoadScene("Popup 1", LoadSceneMode.Additive);
        }
    }
    public void popPopUp()
    {
        EntitasDetail.inspectPopUp2 = true;
        SceneManager.LoadScene("Popup 2", LoadSceneMode.Additive);
    }
    public void unPopPopUp()
    {
        EntitasDetail.inspectPopUp2 = false;
        SceneManager.UnloadScene("Popup 2");
    }
    public void unPopUp()
    {
        EntitasDetail.inspectPopUp = false;
        Time.timeScale = 1f;
        SceneManager.UnloadScene("Popup 1");
    }
    public void loadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
