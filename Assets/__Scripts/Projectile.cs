using UnityEngine;

public class Projectile : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.name.Equals("MiniBoss"))
        {
            Debug.Log("Projectile: " + other);
            Destroy(gameObject);
        }
    }
}
