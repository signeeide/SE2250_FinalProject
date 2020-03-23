using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false; //This can be accessed elsewhere
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //At 1f time will runn as normal
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //Pauses the in game time!
        gameIsPaused = true;
    }

    public void Customize()
    {
        Debug.Log("Customize");
        string scene = "CustomizeScene";
        Main.ChangeScene(scene); //Takes player to the customize scene.

    }

    public void ReturnToCastle()
    {
        string scene = "Scene1";
        Main.ChangeScene(scene); //Takes player back home.
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game.");
        Application.Quit();
        //This will not show anything in the editor, so we'll keep the log for now to know that something happens.
    }
}
