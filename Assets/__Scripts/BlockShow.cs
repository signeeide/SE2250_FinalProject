using UnityEngine;

public class BlockShow : MonoBehaviour
{
    public static bool isVisible = false;
    public GameObject blockObject1;
    public GameObject blockObject2;
    public GameObject blockObject3;

    // Update is called once per frame
    void Update()
    {
        if (isVisible)
        {
            blockObject1.SetActive(true);
            blockObject2.SetActive(true);
            blockObject3.SetActive(true);
        }
        else
        {
            blockObject1.SetActive(false);
            blockObject2.SetActive(false);
            blockObject3.SetActive(false);
        }
    }
}
