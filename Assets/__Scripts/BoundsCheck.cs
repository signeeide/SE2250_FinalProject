using UnityEngine;

/// <summary>
/// Keeps a GameObject on screen.
/// Note that this ONLY works for an orthographic Main Camera at [ 0, 0, 0 ].
/// </summary>

public class BoundsCheck : MonoBehaviour {

    [Header("Set in Inspector")]
    public float radius = 1f;
    public bool keepOnScreen = true;

    [Header("Set Dynamically")]
    public bool isOnScreen = true;
    public float sceneRight;
    public float sceneTop;
    public float sceneLeft;
    public float sceneBottom;

    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown;

    // Update is called after other Update's
    void LateUpdate() {
        Vector3 pos = transform.position;
        isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;

        if (pos.x > sceneRight - radius) {
            pos.x = sceneRight - radius;
            isOnScreen = false;
            offRight = true;
        }

        if (pos.x < sceneLeft + radius) {
            pos.x = sceneRight + radius;
            isOnScreen = false;
            offLeft = true;
        }

        if (pos.y > sceneTop - radius) {
            pos.y = sceneTop - radius;
            isOnScreen = false;
            offUp = true;
        }

        if (pos.y < sceneBottom + radius) {
            pos.y = sceneBottom + radius;
            isOnScreen = false;
            offDown = true;
        }

        if (keepOnScreen && !isOnScreen) {  
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }
    }

    void OnDrawGizmos() {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(sceneRight * 2, sceneTop * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
