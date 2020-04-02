using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool isDefeated = false;

    private void Awake()
    {
        isDefeated = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDefeated)
        {
            Pause();
            isDefeated = false;
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //Pauses the in game time!
    }

    public void Continue()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //At 1f time will runn as normal
        Main.ChangeScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game.");
        Application.Quit();
        //This will not show anything in the editor, so we'll keep the log to know that something happend.
    }
}
