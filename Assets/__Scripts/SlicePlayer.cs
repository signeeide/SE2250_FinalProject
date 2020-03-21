using UnityEngine;

public class SlicePlayer : MonoBehaviour
{
    public GameObject slice;

    public SlicePlayer(GameObject GO)
    {
        slice = GO;
    }
    /*
    private void Awake()
    {
        if (SP == null)
        {
            SP = this;
        }
        else
        {
            Debug.LogError("Hello.Awake() - Attempted to assign second SlicePlayer.SP!");
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
