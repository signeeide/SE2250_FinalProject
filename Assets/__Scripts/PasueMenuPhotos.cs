using UnityEngine;
using UnityEngine.UI;

public class PasueMenuPhotos : MonoBehaviour
{
    public Image[] clothes;
    public Sprite normalDress;
    public Sprite speedDress;
    public Sprite healthDress;
    public Sprite grayDress;

    private int checkpoint;

    private void Awake()
    {
        checkpoint = Player.checkpoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.gameIsPaused)
        {
            for (int i = 0; i < clothes.Length; i++)
            {
                if (i == 0)
                {
                    clothes[i].sprite = normalDress;
                }

                if (i == 1)
                {
                    clothes[i].sprite = speedDress;
                }

                if (i == 2)
                {
                    clothes[i].sprite = grayDress;
                }

            }
        }
    }
}
