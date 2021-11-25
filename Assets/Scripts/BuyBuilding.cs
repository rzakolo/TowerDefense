using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBuilding : MonoBehaviour
{
    [SerializeField] BaseAttack building;
    public BaseAttack GetBuilding()
    {
        return building;
    }
}
