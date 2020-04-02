using UnityEngine;

public class DialogCanvas : MonoBehaviour
{
    public static bool gameIsPausedFrog = false; //This can be accessed elsewhere
    public GameObject pauseMenuUI1;
    public GameObject pauseMenuUI2;
    public GameObject pauseMenuUI3;
    public GameObject pauseMenuUI4;
    public GameObject pauseMenuUI5;


    // Update is called once per frame
    void Update()
    {
        if (gameIsPausedFrog) Pause();

        if (Input.GetKeyDown(KeyCode.X)) Resume();

        Debug.Log("Dialogs progress: " + Main.progress);
    }

    public void Resume()
    {
        if (Main.progress == 1) pauseMenuUI1.SetActive(false);
        else if (Main.progress == 2 || Main.progress == 3) pauseMenuUI2.SetActive(false);
        else if (Main.progress == 4) pauseMenuUI3.SetActive(false);
        else if (Main.progress == 5) pauseMenuUI4.SetActive(false);
        else if (Main.progress == 6) pauseMenuUI5.SetActive(false);
        Time.timeScale = 1f; //At 1f time will runn as normal
        gameIsPausedFrog = false;
    }

    void Pause()
    {
        if (Main.progress == 1)
        {
            pauseMenuUI1.SetActive(true);
        }

        else if (Main.progress == 3)
        {
            pauseMenuUI2.SetActive(true);
        }

        else if (Main.progress == 4)
        {
            pauseMenuUI3.SetActive(true);
        }

        else if (Main.progress == 5)
        {
            pauseMenuUI4.SetActive(true);
        }

        else if (Main.progress == 6)
        {
            pauseMenuUI5.SetActive(true);
        }

        Time.timeScale = 0f; //Pauses the in game time!
        gameIsPausedFrog = true;
    }
}
