using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false; //This can now be accessed elsewhere. Like turning the volume down while the game is paused ect.

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
        Time.timeScale = 1f; //At 1f time will runn as normal. Here its posible to add slow motion or something
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //Pauses the in game time!
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu..");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game.");
    }
}
