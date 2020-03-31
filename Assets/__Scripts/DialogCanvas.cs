using UnityEngine;

public class DialogCanvas : MonoBehaviour
{
    public static bool gameIsPausedFrog = false; //This can be accessed elsewhere
    public GameObject pauseMenuUI1;
    public GameObject pauseMenuUI2;
    public GameObject pauseMenuUI3;

    // Update is called once per frame
    void Update()
    {
        if (gameIsPausedFrog) Pause();

        if (Input.GetKeyDown(KeyCode.X)) Resume();
    }

    public void Resume()
    {
        if (Main.progress == 0) pauseMenuUI1.SetActive(false);
        else if (Main.progress == 1) pauseMenuUI2.SetActive(false);
        else if (Main.progress == 2) pauseMenuUI3.SetActive(false);
        Time.timeScale = 1f; //At 1f time will runn as normal
        gameIsPausedFrog = false;
    }

    void Pause()
    {
        if (Main.progress == 0) pauseMenuUI1.SetActive(true);
        else if (Main.progress == 1)
        {
            pauseMenuUI2.SetActive(true);
            Main.progress = 2;
        }
        else if (Main.progress == 2) pauseMenuUI3.SetActive(true);
        Time.timeScale = 0f; //Pauses the in game time!
        gameIsPausedFrog = true;
    }
}
