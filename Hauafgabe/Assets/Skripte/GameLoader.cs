using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour
{
    [SerializeField]
    Image _loadingBar;


    public void StartGame()
    {
        //SceneManager.LoadScene("Gameplay");
        StartCoroutine(LoadGameplay());
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Bye");
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Auf zur scene");
        }
    }

  

    IEnumerator LoadGameplay()
    {
        AsyncOperation loadGame = SceneManager.LoadSceneAsync("GamePlay");

        while (!loadGame.isDone)
        {
            _loadingBar.fillAmount = Mathf.Clamp01(loadGame.progress / .9f);
            yield return null;
        }
        Debug.Log("Ich passiere");
    }

    /*public void StartGame()
    {
       
    }
    */
}
