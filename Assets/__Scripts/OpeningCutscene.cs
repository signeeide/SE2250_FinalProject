using UnityEngine;

public class OpeningCutscene : MonoBehaviour
{
    public float delayedStart = 10f;

    void Start()
    {
        Debug.Log("Invoke start");
        Invoke("StartGame", delayedStart);
    }

    private void StartGame()
    {
        Debug.Log("Trying to start game");
        Main.ChangeScene("Scene0");
    }
}
