using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 참조 : https://github.com/silverlybee/farm-game-tutorial

public class Plot : MonoBehaviour
{
    bool isTaken = false;

    float timer;
    int plantStage = 0;

    private Plant myPlant;

    [SerializeField] private SpriteRenderer plant;
    [SerializeField] private BoxCollider2D plantCollider;
    // event로 수정 요함.
    [SerializeField] private FarmingManager farmingManager;

    void UpdatePlant()
    {
        //Debug.Log(myPlant.growthSpeed);
        plant.sprite = myPlant.plantStages[plantStage];
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0, plant.bounds.size.y / 2);
    }

    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        farmingManager = FindObjectOfType<FarmingManager>();
    }

    void Update()
    {
        if (isTaken)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantStage < myPlant.plantStages.Length - 1)
            {
                timer = myPlant.growthSpeed;
                plantStage++;
                UpdatePlant();
            }
        }
    }

    private void OnMouseDown()
    {
        if (isTaken)
        {
            if (plantStage == myPlant.plantStages.Length - 1)
            {
                Harvesting();
            }
        }
        else
        {
            Planting();
        }
    }

    void Planting()
    {
        myPlant = farmingManager.selectedPlant;
        farmingManager.usePlant();
        isTaken = true;
        plantStage = 0;
        plant.gameObject.SetActive(true);
        UpdatePlant();
        timer = myPlant.growthSpeed;
    }

    void Harvesting()
    {
        isTaken = false;
        plant.gameObject.SetActive(false);
        farmingManager.addPlant(myPlant);
    }
}
