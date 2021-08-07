using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public List<EnemyController> enemys;
    private GameObject[] temp;
    public Vector3 gameMapSize;
    [SerializeField] Tilemap tilemap;
    GameObject targetObject;
    RaycastHit2D ray;
    private void Start()
    {
        gameMapSize = GameObject.Find("Environment").GetComponent<Tilemap>().cellBounds.size;
        Debug.Log("x: " + tilemap.cellBounds.size.x + " y: " + tilemap.cellBounds.size.y);
        UpdateEnemyList();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            mousePos.z = 0;
            ray = Physics2D.Raycast(mousePos, Vector2.zero);
            if (ray.transform != null)
                SetToTarget(ray.transform.gameObject);
            else
                ClearTarget();
        }
    }

    public void UpdateEnemyList()
    {
        temp = GameObject.FindGameObjectsWithTag("Enemy");
        enemys.Clear();
        foreach (GameObject enemy in temp)
        {
            enemys.Add(enemy.GetComponent<EnemyController>());
        }
    }
    private void ClearTarget()
    {
        if (targetObject != null)
            targetObject.transform.GetChild(0).gameObject.SetActive(false);
        targetObject = null;
    }
    private void SetToTarget(GameObject target)
    {
        if (targetObject != null && !targetObject.Equals(target))
        {
            ClearTarget();
        }
        targetObject = target;

        if (targetObject.CompareTag("Enemy"))
        {

        }
        if (targetObject.CompareTag("Base"))
        {

        }
        if (targetObject.CompareTag("Building"))
        {
            targetObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
