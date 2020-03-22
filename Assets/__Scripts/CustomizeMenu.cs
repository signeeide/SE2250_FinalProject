using UnityEngine;

public class CustomizeMenu : MonoBehaviour
{
    public static bool isAttack = false;
    public static bool isHealth = false;
    public static bool isSpeed = false;
    public static bool isNormal = true;

    public GameObject CustomizeMenuUI;


    public void AttackButton()
    {
        isAttack = true;
        isHealth = isSpeed = isNormal = false;
        Debug.Log("Attak!");
    }

    public void HealthButton()
    {
        isHealth = true;
        isAttack = isSpeed = isNormal = false;
        Debug.Log("Health!");
    }

    public void SpeedButton()
    {
        isSpeed = true;
        isAttack = isHealth = isNormal = false;
        Debug.Log("Speed!");
    }

    public void NormalButton()
    {
        isNormal = true;
        isAttack = isHealth = isSpeed = false;
        Debug.Log("Normal!");
    }

    public void BackButton()
    {
        Debug.Log("Back!");
        Main.ChangeScene("Scene1");
    }
}
