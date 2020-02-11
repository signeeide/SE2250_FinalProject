using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;              //Floating point variable to store the player's movement speed.

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        GetComponent<Rigidbody2D>().AddForce(movement * speed);
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log("Collision detected!");
    }
}
