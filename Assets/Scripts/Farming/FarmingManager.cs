using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmingManager : MonoBehaviour
{
    public Text berryNumText;
    public Text wheatNumText;
    public Text potatoNumText;
    public Text cabbageNumText;
    public Text mushroomNumText;

    public Plant selectedPlant;

    // Start is called before the first frame update
    void Start()
    {
        // UI 초기화 필요
        updateNum(selectedPlant);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 작물 선택
    public void selectPlant(Plant plant)
    {
        selectedPlant = plant;
    }

    // 파종, 수확물 감소
    public void usePlant()
    {
        selectedPlant.num--;
        updateNum(selectedPlant);
    }

    // 수확, 수확물 증가
    public void addPlant(Plant plant)
    {
        plant.num++;
        updateNum(plant);
    }

    // UI 업데이트
    public void updateNum(Plant plant)
    {
        if (plant.name == "Berry")
        {
            berryNumText.text = plant.num.ToString();
        }
        else if (plant.name == "Wheat")
        {
            wheatNumText.text = plant.num.ToString();
        }
        else if (plant.name == "Potato")
        {
            potatoNumText.text = plant.num.ToString();
        }
        else if (plant.name == "Cabbage")
        {
            cabbageNumText.text = plant.num.ToString();
        }
        else if (plant.name == "Mushroom")
        {
            mushroomNumText.text = plant.num.ToString();
        }
    }
}
