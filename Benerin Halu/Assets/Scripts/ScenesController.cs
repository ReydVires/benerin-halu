using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{


    public void popUp()
    {
        EntitasDetail.inspectPopUp = true;
        Time.timeScale = 0.1f;
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }
    public void unPopUp()
    {
        EntitasDetail.inspectPopUp = false;
        Time.timeScale = 1f;
        SceneManager.UnloadScene(2);
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
