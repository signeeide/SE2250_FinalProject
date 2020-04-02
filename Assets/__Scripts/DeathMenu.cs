using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool isDefeated = false;

    private void Awake()
    {
        Debug.Log("AWAKE!");
        isDefeated = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("LOCAL: " + isDefeated);

        if (isDefeated)
        {
            Pause();
            isDefeated = false;
        }

        Debug.Log("LOCAL after: " + isDefeated);
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
        //This will not show anything in the editor, so we'll keep the log for now to know that something happens.
    }
}
