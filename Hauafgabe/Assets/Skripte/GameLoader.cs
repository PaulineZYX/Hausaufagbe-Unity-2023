using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour
{
    [SerializeField]
    Image _loadingBar;


    //Kommentar: Ruft die funktion StartCoroutine auf
    public void StartGame()
    {
        //SceneManager.LoadScene("Gameplay");
        StartCoroutine(LoadGameplay());
    }

    //Kommentar: SChließt das spiel und ein debug log um zu überprüfen ob es ein input gibt/ es ausgeführt wird 
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Bye");
    }

    //Kommentar: Wenn der Esc button ein input bekommt wird man zurück in die MainMenu  scene gebracht und ein debug.log um zu prüfung ob wirklich was passiert
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Auf zur scene");
        }
    }


    //Kommentar: Sobald die funktion aufgerufen wird wird im hintergrund die scene "Gameplay" geladen. Mit einer while schleife wird dann geguckt wie weit es geladen ist bevor die scene vollständig geladen wird
    IEnumerator LoadGameplay()
    {
        AsyncOperation loadGame = SceneManager.LoadSceneAsync("GamePlay");

        while (!loadGame.isDone)
        {
            _loadingBar.fillAmount = Mathf.Clamp01(loadGame.progress / .9f);
            yield return null;
        }
        Debug.Log("Ich Lade");
    }

    /*public void StartGame()
    {
       
    }
    */
}
