using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static int health = 4;
    public int numberOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Update()
    {
        if(health > numberOfHearts)
        {
            health = numberOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Bee")) health--;

        if (other.gameObject.tag.Equals("Eagle")) health--;

        if (other.gameObject.tag.Equals("Boss")) health--;

        if (other.gameObject.tag.Equals("BossProjectile")) health--;

        if (other.gameObject.name.Equals("OutsideLv")) health--;
        
        if (health < 1)
        {
            Debug.Log("Player eliminated");
            DeathMenu.isDefeated = true;
            health = 4;
        }
    }
}
