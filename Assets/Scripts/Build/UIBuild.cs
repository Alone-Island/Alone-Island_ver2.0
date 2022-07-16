using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBuild : MonoBehaviour
{
    /*
    // 필요한 컴포넌트
    [SerializeField]
    public BuildingManager BuildingManager;

    private void OnEnable()
    {
        Debug.Log("UIBuild 로그");
        for (int i = 0; i < BuildingManager.Instance().buildingData.Count; i++)
        {
            BuildingData.BuildingDictionary building = BuildingManager.buildingData[i];
            GameObject buildingItemList = PrefabUtility.InstantiatePrefab(Resources.Load("Prefabs/UI/Build/BuildingItemList") as GameObject) as GameObject;

            if (BuildingManager.Instance().CheckHaveBuildingMaterials(building.materials))
            {
                Debug.Log("건물 짓기 가능");
                buildingItemList.GetComponent<Button>().interactable = true;
            }
            else
            {
                Debug.Log("건물 짓기 불가능");
                buildingItemList.GetComponent<Button>().interactable = false;
            }
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < BuildingManager.Instance().buildingData.Count; i++)
        {
            BuildingData.BuildingDictionary building = BuildingManager.Instance().buildingData[i];
            GameObject buildingItemList = PrefabUtility.InstantiatePrefab(Resources.Load("Prefabs/UI/Build/BuildingItemList") as GameObject) as GameObject;
            buildingItemList.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = building.building.itemImage;
            buildingItemList.transform.SetParent(BuildingManager.Instance().BuildingContent.transform, false);      // ?

            for (int j = 0; j < building.materials.Count; j++)
            {
                GameObject material = PrefabUtility.InstantiatePrefab(Resources.Load("Prefabs/UI/Build/Material") as GameObject) as GameObject;
                material.transform.SetParent(buildingItemList.transform.GetChild(2), false);        // ?

                material.transform.GetChild(0).GetComponent<Image>().sprite = building.materials[j].item.itemImage;
                material.transform.GetChild(2).GetComponent<Text>().text = building.materials[j].num.ToString();

                if (j < building.materials.Count - 1)
                {
                    GameObject addMaterial = PrefabUtility.InstantiatePrefab(Resources.Load("Prefabs/UI/Build/AddMaterial") as GameObject) as GameObject;
                    addMaterial.transform.SetParent(buildingItemList.transform.GetChild(2), false);
                }
            }

            buildingItemList.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (BuildingManager.Instance().MakeNewBuilding(building))
                {
                    BuildingManager.Instance().BuildingFail.transform.GetChild(1).GetComponent<Image>().sprite = building.building.itemImage;
                    BuildingManager.Instance().SetActive(true);
                }
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
