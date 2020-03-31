using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main S;  //A singleton for Main

    [Header("Set in Inspectior")]
    public GameObject[] prefabEnemies; //Array on posible enemies
    public float enemySpawnPerSecond = 1f;
    public int numberOfEnemies = 5;
    public static int enemiesDestroied = 0;
    static public int progress = 0;

    void Awake()
    {
        S = this;
        //Waiting 5 sec to spawn the first one
        Invoke("SpawnEnemy", 2f / enemySpawnPerSecond);
    }

    private void Update()
    {
        Debug.Log(enemiesDestroied);
        if(enemiesDestroied == 5)
        {
            //Spawn boss + cutscene
            progress = 1;
        }
    }

    public void SpawnEnemy()
    {
        //Pick a random Enemy prefab to initiate
        int idx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[idx]);

        // Set the initial position for the spawned Enemy
        Vector3 pos = Vector3.zero;
        pos.x = 64.96f;
        pos.y = 1.69f;
        go.transform.position = pos;

        numberOfEnemies--;

        if (numberOfEnemies > 0)
        {
            // Invoke SpawningEnemy() again
            Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
        }
    }

    public void DelayedRestart(float delay)
    {
        //Invoke the Restart() method in delay seconds
        Invoke("Restart", delay);
    }

    public void Restart()
    {
        //Reload scene_0 to restart the game
        ChangeScene("Scene1");
    }

    public static void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
}

