using UnityEngine;

public class ProjectilePlayer : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.name.Equals("Player"))
            Destroy(this.gameObject);
    }
}
