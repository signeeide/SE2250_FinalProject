using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main S;  //A singleton for Main

    [Header("Set in Inspectior")]
    public GameObject[] prefabEnemies; //Array on posible enemies
    private int numberOfEnemies = 0;
    public static int enemiesDestroied = 0;
    static public int progress = 0;
    public static bool spawn = true;

    void Awake()
    {
        S = this;
    }

    private void Update()
    {
        Debug.Log(progress);
        Debug.Log(spawn);

        if (progress == 1 && spawn)
        {
            SpawnEnemy();
            spawn = false;
        }

        if (enemiesDestroied == 5)
        {
            //Cutscene
            progress = 2;
        }
    }

    public void SpawnEnemy()
    {
        //Pick a random Enemy prefab to initiate
        int idx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[idx]);

        // Set the initial position for the spawned Enemy
        Vector3 pos = Vector3.zero;
        pos.x = 56.0f;
        pos.y = 0.6f;
        go.transform.position = pos;
        numberOfEnemies++;

        if(numberOfEnemies < 5) Invoke("SpawnEnemy", 2f);
    }

    public void DelayedRestart(float delay)
    {
        //Invoke the Restart() method in delay seconds
        Invoke("Restart", delay);
    }

    public void Restart()
    {
        //Reload scene_0 to restart the game
        ChangeScene(SceneManager.GetActiveScene().name);
    }

    public static void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
}

