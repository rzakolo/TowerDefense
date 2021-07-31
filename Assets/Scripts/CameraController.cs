using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 mousePos;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos.x -= Input.GetAxis("Mouse X")/2;
            mousePos.y -= Input.GetAxis("Mouse Y")/2;
            mousePos.z = -10;
            Camera.main.transform.position = mousePos;
        }
    }
}
