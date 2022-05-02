using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ÂüÁ¶ : https://github.com/silverlybee/farm-game-tutorial

public class Plot : MonoBehaviour
{
    bool isTaken = false;

    SpriteRenderer plant;
    BoxCollider2D plantCollider;

    public Sprite[] plantStages;
    int plantStage = 0;
    float timeBtwStages = 2f;
    float timer;

    void UpdatePlant()
    {
        plant.sprite = plantStages[plantStage];
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0, plant.bounds.size.y / 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTaken)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantStage < plantStages.Length - 1)
            {
                timer = timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }
    }

    private void OnMouseDown()
    {
        if (isTaken)
        {
            if (plantStage == plantStages.Length - 1)
            {
                Harvest();
            }
        }
        else
        {
            Plant();
        }
    }

    void Plant()
    {
        isTaken = true;
        plantStage = 0;
        UpdatePlant();
        timer = timeBtwStages;
        plant.gameObject.SetActive(true);
    }

    void Harvest()
    {
        isTaken = false;
        plant.gameObject.SetActive(false);
    }
}
