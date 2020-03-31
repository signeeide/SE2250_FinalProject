using UnityEngine;

public class OpeningCutscene : MonoBehaviour
{
    public float delayedStart = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Invoke start");
        Invoke("StartGame", delayedStart);
    }

    private void StartGame()
    {
        Debug.Log("Trying to start game");
        //TO DO: Change to scene0 when that scene is done
        Main.ChangeScene("Scene1");
    }
}
