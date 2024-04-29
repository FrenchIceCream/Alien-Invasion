using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneDelay = 2f;
    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadGameOver()
    {
        WaitToLoad("GameOver", sceneDelay);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitToLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
