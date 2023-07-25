using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float cameraSpeed = 7.0f;
    private float minX = -13f; 
    private float maxX = 44f; 
    private float minY = -2f; 
    private float maxY = 20f; 

    public GameObject player;
    private bool isCameraMoveEnabled = true; 

    private void Update()
    {
        if (isCameraMoveEnabled)
        {
            Vector3 dir = player.transform.position - this.transform.position;
            float clampedX = Mathf.Clamp(dir.x * cameraSpeed * Time.deltaTime, minX, maxX);
            float clampedY = Mathf.Clamp(dir.y * cameraSpeed * Time.deltaTime, minY, maxY);

            Vector3 moveVector = new Vector3(clampedX, clampedY, 0.0f);
            this.transform.Translate(moveVector);
        }
    }

    public void SetCameraMoveEnabled(bool isEnabled)
    {
        isCameraMoveEnabled = isEnabled;
    }
}
