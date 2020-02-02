using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{

    public void popUp()
    {
        EntitasDetail.inspectPopUp = true;
        Time.timeScale = 0.01f;
        SceneManager.LoadScene("Popup 1", LoadSceneMode.Additive);
    }
    public void popPopUp()
    {
        EntitasDetail.inspectPopUp = true;
        SceneManager.LoadScene("Popup 2", LoadSceneMode.Additive);
    }
    public void unPopPopUp()
    {
        EntitasDetail.inspectPopUp = false;
        SceneManager.UnloadScene("Popup 2");
    }
    public void unPopUp()
    {
        HaluMeter.instance.addingScore(120);
        EntitasDetail.inspectPopUp = false;
        Time.timeScale = 1f;
        SceneManager.UnloadScene("Popup 1");
    }
    public void loadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void loadThisScene()
    {
        SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void quitApp()
    {
        Application.Quit();
    }
    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void loadGameplayScene()
    {
        unPopUp();
    }
}
