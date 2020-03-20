using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object
    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    private BoundsCheck bndCheck;

    [Header("Set in Inspector")]
    public float radius;
    public bool keepOnScreen = true;
    public bool isOnScreen = true;

    public float sceneRight;
    public float sceneTop;
    public float sceneLeft;
    public float sceneBottom;

    // Use this for initialization
    void Awake()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        bndCheck = GetComponent<BoundsCheck>();
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (bndCheck.isOnScreen)
        {
            transform.position = player.transform.position + offset;
        }
        else
        {
            Debug.Log(bndCheck.offLeft);
            Debug.Log(bndCheck.offRight);
        }

        Debug.Log("X : " + transform.position.x);
        Debug.Log("Y : " + transform.position.y);
    }

}