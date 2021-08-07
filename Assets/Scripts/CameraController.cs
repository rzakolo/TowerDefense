using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 mousePos;
    GameManager gameManager;
    float boundX;
    float boundY;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GetTilemapBound();
            mousePos.x -= Input.GetAxis("Mouse X") / 4;
            if (mousePos.x > boundX || mousePos.x < -boundX)
            {
                mousePos.x += Input.GetAxis("Mouse X") / 4;
            }
            mousePos.y -= Input.GetAxis("Mouse Y") / 4;
            if (mousePos.y > boundY || mousePos.y < -boundY)
            {
                mousePos.y += Input.GetAxis("Mouse Y") / 4;
            }
            mousePos.z = transform.position.z;
            Camera.main.transform.position = mousePos;
        }
    }
    private void GetTilemapBound()
    {
        float mainCameraSize = Camera.main.orthographicSize;
        float height = 2f * mainCameraSize;
        float width = height * Camera.main.aspect;
        boundX = (gameManager.gameMapSize.x - width) / 2;
        boundY = (gameManager.gameMapSize.y - height) / 2;
    }
}
