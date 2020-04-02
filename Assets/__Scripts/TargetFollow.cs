using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    //What we are following
    public Transform target;

    //Zeros out the velocity
    Vector3 velocity = Vector3.zero;

    //Time to follor target
    public float smoothTime = .15f;

    //enable and set the maqimum y value
    public bool YMaxEnabled = false;
    public float YMaxValue = 0;

    //enable and set the min Y value
    public bool YMinEnabled = false;
    public float YMinValue = 0;

    //enable and set the maximum X value
    public bool XMaxEnabled = false;
    public float XMaxValue = 0;

    //enable and set the min X value
    public bool XMinEnabled = false;
    public float XMinValue = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        //targets position
        Vector3 targetPos = target.position;

        //vertical
        if (YMinEnabled && YMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, YMaxValue);

        else if (YMinEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, target.position.y);

        else if (YMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, YMaxValue);

        //horisontal
        if (XMinEnabled && XMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, XMaxValue);

        else if (XMinEnabled)
            targetPos.y = Mathf.Clamp(target.position.x, XMinValue, target.position.x);

        else if (XMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.x, target.position.x, XMaxValue);


        //align tha camera and the targets z position
        targetPos.z = transform.position.z;

        //Using smooth: gradually change the camera
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
