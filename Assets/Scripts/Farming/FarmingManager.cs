using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmingManager : MonoBehaviour
{
    public Text berryNumText;
    public Text wheatNumText;
    public Plant selectedPlant;

    private int berryNum = 5;
    private int wheatNum = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectPlant(Plant plant)
    {
        selectedPlant = plant;
    }

    public void usePlant()
    {
        if (selectedPlant.name == "Berry")
        {
            berryNum--;
        }
        else if (selectedPlant.name == "Wheat")
        {
            wheatNum--;
        }
        updateNum(selectedPlant);
    }

    public void addPlant(Plant plant)
    {
        if (plant.name == "Berry")
        {
            berryNum++;
        }
        else if (plant.name == "Wheat")
        {
            wheatNum++;
        }
        updateNum(plant);
    }

    public void updateNum(Plant plant)
    {
        if (plant.name == "Berry")
        {
            berryNumText.text = berryNum.ToString();
        }
        else if (plant.name == "Wheat")
        {
            wheatNumText.text = wheatNum.ToString();
        }
    }
}
