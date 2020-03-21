using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main S;  //A singleton for Main


    private BoundsCheck bndCheck;

    void Awake()
    {
        S = this;
        // Set bndCheck to referende the BoundsCheck component on this GameObject
        bndCheck = GetComponent<BoundsCheck>();
    }

    public void DelayedRestart(float delay)
    {
        //Invoke the Restart() method in delay seconds
        Invoke("Restart", delay);
    }

    public void Restart()
    {
        //Reload scene_0 to restart the game
        //SceneManager.LoadScene("Scene0");
    }
}

