using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneDelay = 2f;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        if (scoreKeeper != null)
            scoreKeeper.Reset();
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitToLoad("GameOver", sceneDelay));
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
