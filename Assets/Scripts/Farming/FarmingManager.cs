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

    private int berryNum = 5;
    private int wheatNum = 5;
    private int potatoNum = 5;
    private int cabbageNum = 5;
    private int mushroomNum = 5;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if (selectedPlant.name == "Berry")
        {
            berryNum--;
        }
        else if (selectedPlant.name == "Wheat")
        {
            wheatNum--;
        }
        else if (selectedPlant.name == "Potato")
        {
            potatoNum--;
        }
        else if (selectedPlant.name == "Cabbage")
        {
            cabbageNum--;
        }
        else if (selectedPlant.name == "Mushroom")
        {
            mushroomNum--;
        }
        updateNum(selectedPlant);
    }

    // 수확, 수확물 증가
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
        else if (plant.name == "Potato")
        {
            potatoNum++;
        }
        else if (plant.name == "Cabbage")
        {
            cabbageNum++;
        }
        else if (plant.name == "Mushroom")
        {
            mushroomNum++;
        }
        updateNum(plant);
    }

    // 수확 후 UI 업데이트
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
        else if (plant.name == "Potato")
        {
            potatoNumText.text = potatoNum.ToString();
        }
        else if (plant.name == "Cabbage")
        {
            cabbageNumText.text = cabbageNum.ToString();
        }
        else if (plant.name == "Mushroom")
        {
            mushroomNumText.text = mushroomNum.ToString();
        }
    }
}
