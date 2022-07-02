using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingData : MonoBehaviour
{
    public struct BuildingDictionary
    {
        public Building building;   // 지으려는 건축물
        public List<Items> materials;   // 건축물을 만드는데 필요한 재료 데이터

        public BuildingDictionary(Building _building, List<Items> _materials)
        {
            building = _building;
            materials = _materials;
        }
    }

    public struct Items
    {
        public Item item;   // 필요한 재료 아이템
        public int num { get; set; }      // 필요한 재료 아이템 갯수

        public Items(Item _item, int _num)
        {
            item = _item;
            num = _num;
        }
    }

    private List<BuildingDictionary> buildingData;        // 건축물 데이터 저장하는 dictionary 변수

    void Awake()
    {
        GenerateData(buildingData);
    }

    void GenerateData(List<BuildingDictionary> buildingData)
    {
        buildingData = new List<BuildingDictionary>();
        // 건축물 데이터 리스트들 (예시)
        buildingData.Add(new BuildingDictionary(
            Resources.Load<Building>("Building/Fence"),
            new List<Items> {
                new Items(Resources.Load<Item>("Item/Food/Apple"), 1),
                new Items(Resources.Load<Item>("Item/Food/Banana"), 2)
            }));
    }

    public List<Items> GetBuildingMaterialsData(Building _building)         // 건축물 건설에 필요한 재료 아이템 데이터 리턴
    {
        foreach (BuildingDictionary dict in buildingData)
            if (dict.building == _building)
                return dict.materials;
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
