using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantItem : MonoBehaviour
{
    [SerializeField] private Plant plant;
    FarmingManager farmingManager;

    // Start is called before the first frame update
    void Start()
    {
        farmingManager = FindObjectOfType<FarmingManager>();
    }

    public void onClick()
    {
        Debug.Log(plant.name);
        farmingManager.selectPlant(plant);
    }
}
