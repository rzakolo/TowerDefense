using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int money = 0;
    public List<EnemyController> enemys;
    private GameObject[] temp;
    public Vector3Int gameMapSize;
    public bool gameOver = false;
    private bool moveBuilding = false;
    [SerializeField] Tilemap tilemap;
    GameObject targetObject;
    BaseAttack movingBuilding;
    RaycastHit2D ray;
    Camera mainCamera;

    [SerializeField] TextMeshProUGUI moneyCounterText;
    [SerializeField] Button sellButton;
    [SerializeField] Button moveButton;
    Vector3 offset = new Vector2(0.40f, 0);
    [SerializeField] Canvas canvas;

    private void Start()
    {
        mainCamera = Camera.main;
        gameMapSize = GameObject.Find("Environment").GetComponent<Tilemap>().cellBounds.size;
        Debug.Log("x: " + tilemap.cellBounds.size.x + " y: " + tilemap.cellBounds.size.y);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            mousePos.z = 0;
            ray = Physics2D.Raycast(mousePos, Vector2.zero);
            if (ray.transform == null)
            {
                ClearTarget();
                return;
            }
            if (ray.transform.gameObject.CompareTag("Buy") && !moveBuilding)
            {
                BuyBuilding(ray.transform.gameObject.GetComponent<BuyBuilding>().GetBuilding());
                return;
            }
            if (!moveBuilding)
                SetToTarget(ray.transform.gameObject);
        }
        if (moveBuilding)
        {
            Vector3 mousePos = (mainCamera.ScreenToWorldPoint(Input.mousePosition));
            ray = Physics2D.Raycast(mousePos, Vector2.zero);
            if (ray.transform == null)
                return;
            movingBuilding.transform.position = ray.point;
            if (Input.GetMouseButtonDown(1))
                SetBuildingPos(ray.point);
        }
        moneyCounterText.text = $"{money}$";
    }
    private void ClearTarget()
    {
        if (targetObject != null)
        {
            targetObject.transform.GetChild(0).gameObject.SetActive(false);
            sellButton.gameObject.SetActive(false);
            moveButton.gameObject.SetActive(false);
        }
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
            worldToUISpace();
            sellButton.gameObject.SetActive(true);
            moveButton.gameObject.SetActive(true);
        }
    }
    public Vector3 worldToUISpace(Canvas parentCanvas, Vector3 worldPos)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
        return parentCanvas.transform.TransformPoint(movePos);
    }
    public void worldToUISpace()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(targetObject.transform.position);
        Vector2 movePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPos, canvas.worldCamera, out movePos);
        sellButton.transform.position = targetObject.transform.position + offset;
        moveButton.transform.position = targetObject.transform.position - offset;
    }
    public void SetMoney(int value)
    {
        money += value;
        moneyCounterText.text = $"{money}$";
    }
    public void SellBuilding()
    {
        if (targetObject != null)
        {
            BaseAttack temp = targetObject.GetComponent<BaseAttack>();
            money += temp.cost;
            ClearTarget();
            Destroy(temp.gameObject);
        }
    }
    public void MoveBuilding()
    {
        movingBuilding = targetObject.GetComponent<BaseAttack>();
        movingBuilding.enabled = false;
        sellButton.gameObject.SetActive(false);
        moveButton.gameObject.SetActive(false);
        moveBuilding = true;
    }
    private void SetBuildingPos(Vector2 position)
    {
        movingBuilding.transform.position = position;
        movingBuilding.enabled = true;
        moveBuilding = false;
        movingBuilding = null;
    }
    public void BuyBuilding(BaseAttack building)
    {
        if (money - building.cost >= 0)
        {
            money -= building.cost;
            targetObject = Instantiate(building.gameObject);
            MoveBuilding();
        }
        else
        {
            Destroy(building.gameObject);
        }
    }
    public void GameOver()
    {

    }
    public void GamePaused()
    {

    }
}
