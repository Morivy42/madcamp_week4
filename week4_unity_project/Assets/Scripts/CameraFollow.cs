using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float minX = -4f;
    public float maxX = 100f;
    public float minY = 0f;
    public float maxY = 4f;

    public GameObject player;
    private bool isCameraMoveEnabled = true;
    void Start(){
    }

    private void Update()
    {
        if (isCameraMoveEnabled)
        {
            float clampedX = Mathf.Clamp(player.transform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(player.transform.position.y, minY, maxY);
            Vector3 dir = new Vector3(clampedX-this.transform.position.x, clampedY-this.transform.position.y, 0f);
            transform.Translate(dir);
        }
    }

    public void SetCameraMoveEnabled(bool isEnabled)
    {
        isCameraMoveEnabled = isEnabled;
    }
}
