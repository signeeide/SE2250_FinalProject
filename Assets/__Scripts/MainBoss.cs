using UnityEngine;

public class MainBoss : MiniBoss
{
    private int health = 800;

    public override void Update()
    {
        transform.position = Vector3.Lerp(new Vector3(52.42f, 2.3f, 0f), new Vector3(50f, 2.3f, 0f), (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;

        if (tag.Equals("ProjectilePlayer")) health -= 30;
    
        if (tag.Equals("SlicePlayer")) health -= 100;

        if (health <= 0)
        {
            Destroy(this.gameObject);
            Main.ChangeScene("Endscene");
        }
    }
}
