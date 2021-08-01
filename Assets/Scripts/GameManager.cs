using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<EnemyController> enemys;
    private GameObject[] temp;
    [SerializeField] GameObject gameMap;
    float boundX;
    float boundY;
    GameObject targetObject;
    RaycastHit2D ray;
    private void Start()
    {
        gameMap = GameObject.Find("Environment");
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
